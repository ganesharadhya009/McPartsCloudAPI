using Mcparts.DataAccess.Commands;
using Mcparts.DataAccess.Dtos;
using Mcparts.Infrastructure.Interfaces;
using Newtonsoft.Json.Linq;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Infrastructure.Services
{
    public class ItemsSevice : IItemsSevice
    {
        IDatabaseService databaseService;
        public ItemsSevice(IDatabaseService databaseService) {
            this.databaseService = databaseService;
        }

        private void AddParameters(NpgsqlCommand command, ItemsDto data)
        {
            var parameters = command.Parameters;

            parameters.AddWithValue("@id", data.id);
            parameters.AddWithValue("@name", data.name ?? string.Empty);
            parameters.AddWithValue("@description", data.description ?? string.Empty);
        }

        public async Task<List<JObject>> GetAll()
        {
            var dataList = new List<JObject>();
            using var cmd = databaseService.McPartsonnection.CreateCommand();
            cmd.CommandText = Items.GetAll;
            cmd.Parameters.AddWithValue("@isdeleted", false);
            await databaseService.OpenConnection();
            using var reader = await cmd.ExecuteReaderAsync();

            if (reader is not null)
            {
                while (await reader.ReadAsync())
                {
                    var data = new JObject();
                    data.Add("id", Convert.ToString(reader["id"]));
                    data.Add("partnumber", Convert.ToString(reader["partnumber"]));
                    data.Add("name", Convert.ToString(reader["name"]));
                    data.Add("description", Convert.ToString(reader["description"]));
                    data.Add("additionaldescription", Convert.ToString(reader["additionaldescription"]));
                    data.Add("note", Convert.ToString(reader["note"]));
                    dataList.Add(data);
                }
            }
            return dataList;
        }

        public async Task<bool> Create(ItemsDtoPost data)
        {
            using var cmd = databaseService.McPartsonnection.CreateCommand();
            cmd.CommandText = Items.Insert;
            cmd.Parameters.AddWithValue("@id", data.id);
            cmd.Parameters.AddWithValue("@name", data.name ?? string.Empty);
            cmd.Parameters.AddWithValue("@description", data.description ?? string.Empty);
            await databaseService.OpenConnection();
            var rowAffected = await cmd.ExecuteNonQueryAsync();
            return rowAffected > 0;
        }

        public async Task<bool> Update(ItemsDto data)
        {
            using var cmd = databaseService.McPartsonnection.CreateCommand();
            cmd.CommandText = Items.Update;
            AddParameters(cmd, data);
            await databaseService.OpenConnection();
            var rowAffected = await cmd.ExecuteNonQueryAsync();
            return rowAffected > 0;
        }

        public async Task<JObject> GetById(string id)
        {
            var itemCategory = new JObject();
            using var cmd = databaseService.McPartsonnection.CreateCommand();
            cmd.CommandText = Items.GetById;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@isdeleted", false);
            await databaseService.OpenConnection();
            using var reader = await cmd.ExecuteReaderAsync();

            if (reader is not null)
            {
                while (await reader.ReadAsync())
                {
                    itemCategory.Add("id", Convert.ToString(reader["id"]));
                    itemCategory.Add("name", Convert.ToString(reader["name"]));
                    itemCategory.Add("description", Convert.ToString(reader["description"]));
                }
            }
            return itemCategory;
        }

        public async Task<bool> Delete(string id)
        {
            using var cmd = databaseService.McPartsonnection.CreateCommand();
            cmd.CommandText = Items.Delete;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@isdeleted", true);
            await databaseService.OpenConnection();
            var rowAffected = await cmd.ExecuteNonQueryAsync();
            return rowAffected > 0;
        }

        public async Task<List<JObject>> Search(JObject filter)
        {
            var dataList = new List<JObject>();
            string filterKey = "filters";
            string filterTypeKey = "type";
            string filterValuesKey = "values";
            string categoryKey = "category";
            string subcategoryKey = "subcategoryKey";
            string grouptypeKey = "grouptype";
            string groupsubtypeKey = "groupsubtype";
            string typeKey = "type";

            string materialKey = "material";
            string threadtypeKey = "threadtype";
            string headformKey = "headform";

            string drivetypeKey = "drivetype";
            string propertyclassKey = "propertyclass";
            string surfacefinishKey = "surfacefinish";
            string dimensionsKey = "dimensions";

            using var cmd = databaseService.McPartsonnection.CreateCommand();
            cmd.CommandText = Items.Search;
            var baseCommand = Items.Search + " where ";
            if (filter == null)
            {
            }
            else
            {
                
                if (filter.HasValues && filter.ContainsKey(filterKey) && filter[filterKey].HasValues)
                {
                    var filterData = filter.GetValue(filterKey).Value<JArray>();
                    if (filterData != null)
                    {
                        var filterQuery = "";
                        List<string> queryList = new List<string>();
                        foreach (JObject filterItem in filterData)
                        {
                            var filterType = filterItem.GetValue(filterTypeKey).Value<string>();
                            var filterValues = filterItem.GetValue(filterValuesKey).Value<JArray>();
                            filterQuery = filterType;
                            string filterIn = "";
                            foreach (var filterValue in filterValues)
                            {
                                var value = filterValue.Value<string>();
                                filterIn = filterIn + $"{value},";
                            }
                            filterIn = filterIn.Substring(0, filterIn.Length - 1);
                            filterQuery = filterQuery + $" in ('{filterIn}')";
                            queryList.Add(filterQuery);

                            //var categorData = filterItem.GetValue(categoryKey).Value<JObject>();
                            //if (categorData != null)
                            //{
                            //    var categorDataArray = categorData.GetValue(filterKey).Value<JArray>();
                            //}
                            //var subcategoryData = filterItem.GetValue(subcategoryKey).Value<JObject>();
                            //if (subcategoryData != null)
                            //{

                            //}
                            //var grouptypeData = filterItem.GetValue(grouptypeKey).Value<JObject>();
                            //if (grouptypeData != null)
                            //{

                            //}
                            //var groupsubtypeData = filterItem.GetValue(groupsubtypeKey).Value<JObject>();
                            //if (groupsubtypeData != null)
                            //{

                            //}
                            //var typeData = filterItem.GetValue(typeKey).Value<JObject>();
                            //if (typeData != null)
                            //{

                            //}
                            //var materialData = filterItem.GetValue(materialKey).Value<JObject>();
                            //if (materialData != null)
                            //{

                            //}
                            //var threadtypeData = filterItem.GetValue(threadtypeKey).Value<JObject>();
                            //if (threadtypeData != null)
                            //{

                            //}
                            //var headformData = filterItem.GetValue(headformKey).Value<JObject>();
                            //if (headformData != null)
                            //{

                            //}
                            //var drivetypeData = filterItem.GetValue(drivetypeKey).Value<JObject>();
                            //if (drivetypeData != null)
                            //{

                            //}
                            //var propertyclassData = filterItem.GetValue(propertyclassKey).Value<JObject>();
                            //if (propertyclassData != null)
                            //{

                            //}
                            //var surfacefinishData = filterItem.GetValue(surfacefinishKey).Value<JObject>();
                            //if (surfacefinishData != null)
                            //{

                            //}
                            //var dimensionsData = filterItem.GetValue(dimensionsKey).Value<JObject>();
                            //if (dimensionsData != null)
                            //{

                            //}
                        }

                        int queryCount = 1;
                        if (queryList.Count > 0)
                        {
                            foreach (var query in queryList)
                            {
                                if (queryCount == 1)
                                {
                                    baseCommand = $"{baseCommand}  {query}";
                                }
                                else
                                {
                                    baseCommand = $"{baseCommand} and {query}";
                                }
                                queryCount++;
                            }

                        }
                    }

                    
                }
            }
            cmd.CommandText = baseCommand;
            await databaseService.OpenConnection();
            using var reader = await cmd.ExecuteReaderAsync();

            if (reader is not null)
            {
                while (await reader.ReadAsync())
                {
                    var data = new JObject();
                    data.Add("id", Convert.ToString(reader["id"]));
                    data.Add("partnumber", Convert.ToString(reader["partnumber"]));
                    data.Add("name", Convert.ToString(reader["name"]));
                    data.Add("description", Convert.ToString(reader["description"]));
                    data.Add("additionaldescription", Convert.ToString(reader["additionaldescription"]));
                    data.Add("note", Convert.ToString(reader["note"]));
                    dataList.Add(data);
                }
            }
            return dataList;
        }

        public async Task<List<JObject>> GetAllSearchFilterData()
        {
            var filters = await GetSearchFilters();
            var filterData = await GetSearchData();
            var listFilters = new List<JObject>();
            foreach(var filter in filters)
            {
                var totalfilter = filter.DeepClone() as JObject;
                var tableName = filter.GetValue("category").Value<string>();
                var filterDataLocal = filterData.Where(p=>p.GetValue("tablename").Value<string>() == tableName);
                if (filterDataLocal != null)
                {
                    totalfilter.Add("filterData", JArray.FromObject(filterDataLocal));
                    listFilters.Add(totalfilter);
                }
            }
            return listFilters;
        }

        private async Task<List<JObject>> GetSearchData()
        {
            var dataList = new List<JObject>();
            using var cmd = databaseService.McPartsonnection.CreateCommand();
            cmd.CommandText = Items.GetSearcFilterData;
            await databaseService.OpenConnection();
            using var reader = await cmd.ExecuteReaderAsync();

            if (reader is not null)
            {
                while (await reader.ReadAsync())
                {
                    var data = new JObject();
                    data.Add("id", Convert.ToString(reader["id"]));
                    data.Add("name", Convert.ToString(reader["name"]));
                    data.Add("tablename", Convert.ToString(reader["tablename"]));
                    dataList.Add(data);
                }
            }
            return dataList;
        }

        private async Task<List<JObject>> GetSearchFilters()
        {
            var dataList = new List<JObject>();
            using var cmd = databaseService.McPartsonnection.CreateCommand();
            cmd.CommandText = Items.GetSearchFilters;
            await databaseService.OpenConnection();
            using var reader = await cmd.ExecuteReaderAsync();

            if (reader is not null)
            {
                while (await reader.ReadAsync())
                {
                    var data = new JObject();
                    data.Add("id", Convert.ToString(reader["id"]));
                    data.Add("controltype", Convert.ToString(reader["controltype"]));
                    data.Add("issearchable", Convert.ToString(reader["issearchable"]));
                    data.Add("ismultiselect", Convert.ToString(reader["ismultiselect"]));
                    data.Add("isiconsupported", Convert.ToString(reader["isiconsupported"]));
                    data.Add("category", Convert.ToString(reader["category"]));
                    dataList.Add(data);
                }
            }
            return dataList;
        }
    }
}
