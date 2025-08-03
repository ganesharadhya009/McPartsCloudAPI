using AutoMapper;
using Mcparts.DataAccess.Commands;
using Mcparts.DataAccess.Dtos;
using Mcparts.DataAccess.Models;
using Mcparts.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
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
    public class ProductsGetSevice : IProductsGetSevice
    {
        private readonly McpartsDbContext _databaseContext;
        private readonly IMapper mapper;
        public ProductsGetSevice( McpartsDbContext context, IMapper mapper)
        {
            _databaseContext = context;
            this.mapper = mapper;
        }

        //private void AddParameters(NpgsqlCommand command, ProductsDto data)
        //{
        //    var parameters = command.Parameters;

        //    parameters.AddWithValue("@id", data.id);
        //    parameters.AddWithValue("@name", data.name ?? string.Empty);
        //    parameters.AddWithValue("@description", data.description ?? string.Empty);
        //}

        //public async Task<List<JObject>> GetAll()
        //{
        //    var dataList = new List<JObject>();
        //    using var cmd = databaseService.McPartsonnection.CreateCommand();
        //    cmd.CommandText = ProductsCommands.GetAll;
        //    cmd.Parameters.AddWithValue("@isdeleted", false);
        //    await databaseService.OpenConnection();
        //    using var reader = await cmd.ExecuteReaderAsync();

        //    if (reader is not null)
        //    {
        //        while (await reader.ReadAsync())
        //        {
        //            var data = new JObject();
        //            data.Add("id", Convert.ToString(reader["id"]));
        //            data.Add("partnumber", Convert.ToString(reader["partnumber"]));
        //            data.Add("name", Convert.ToString(reader["name"]));
        //            data.Add("description", Convert.ToString(reader["description"]));
        //            data.Add("additionaldescription", Convert.ToString(reader["additionaldescription"]));
        //            data.Add("note", Convert.ToString(reader["note"]));
        //            dataList.Add(data);
        //        }
        //    }
        //    return dataList;
        //}

        //public async Task<bool> Create(ProductsDtoPost data)
        //{
        //    using var cmd = databaseService.McPartsonnection.CreateCommand();
        //    cmd.CommandText = ProductsCommands.Insert;
        //    cmd.Parameters.AddWithValue("@id", data.id);
        //    cmd.Parameters.AddWithValue("@name", data.name ?? string.Empty);
        //    cmd.Parameters.AddWithValue("@description", data.description ?? string.Empty);
        //    await databaseService.OpenConnection();
        //    var rowAffected = await cmd.ExecuteNonQueryAsync();
        //    return rowAffected > 0;
        //}

        //public async Task<bool> Update(ProductsDto data)
        //{
        //    using var cmd = databaseService.McPartsonnection.CreateCommand();
        //    cmd.CommandText = ProductsCommands.Update;
        //    AddParameters(cmd, data);
        //    await databaseService.OpenConnection();
        //    var rowAffected = await cmd.ExecuteNonQueryAsync();
        //    return rowAffected > 0;
        //}

        //public async Task<JObject> GetById(string id)
        //{
        //    var itemCategory = new JObject();
        //    using var cmd = databaseService.McPartsonnection.CreateCommand();
        //    cmd.CommandText = ProductsCommands.GetById;
        //    cmd.Parameters.AddWithValue("@id", id);
        //    cmd.Parameters.AddWithValue("@isdeleted", false);
        //    await databaseService.OpenConnection();
        //    using var reader = await cmd.ExecuteReaderAsync();

        //    if (reader is not null)
        //    {
        //        while (await reader.ReadAsync())
        //        {
        //            itemCategory.Add("id", Convert.ToString(reader["id"]));
        //            itemCategory.Add("name", Convert.ToString(reader["name"]));
        //            itemCategory.Add("description", Convert.ToString(reader["description"]));
        //        }
        //    }
        //    return itemCategory;
        //}

        //public async Task<bool> Delete(string id)
        //{
        //    using var cmd = databaseService.McPartsonnection.CreateCommand();
        //    cmd.CommandText = ProductsCommands.Delete;
        //    cmd.Parameters.AddWithValue("@id", id);
        //    cmd.Parameters.AddWithValue("@isdeleted", true);
        //    await databaseService.OpenConnection();
        //    var rowAffected = await cmd.ExecuteNonQueryAsync();
        //    return rowAffected > 0;
        //}

        //public async Task<List<JObject>> Search(JObject filter)
        //{
        //    var dataList = new List<JObject>();
        //    string filterKey = "filters";
        //    string filterTypeKey = "type";
        //    string filterValuesKey = "values";
        //    string categoryKey = "category";
        //    string subcategoryKey = "subcategoryKey";
        //    string grouptypeKey = "grouptype";
        //    string groupsubtypeKey = "groupsubtype";
        //    string typeKey = "type";

        //    string materialKey = "material";
        //    string threadtypeKey = "threadtype";
        //    string headformKey = "headform";

        //    string drivetypeKey = "drivetype";
        //    string propertyclassKey = "propertyclass";
        //    string surfacefinishKey = "surfacefinish";
        //    string dimensionsKey = "dimensions";

        //    using var cmd = databaseService.McPartsonnection.CreateCommand();
        //    cmd.CommandText = ProductsCommands.Search;
        //    var baseCommand = ProductsCommands.Search + " where ";
        //    if (filter == null)
        //    {
        //    }
        //    else
        //    {
                
        //        if (filter.HasValues && filter.ContainsKey(filterKey) && filter[filterKey].HasValues)
        //        {
        //            var filterData = filter.GetValue(filterKey).Value<JArray>();
        //            if (filterData != null)
        //            {
        //                var filterQuery = "";
        //                List<string> queryList = new List<string>();
        //                foreach (JObject filterItem in filterData)
        //                {
        //                    var filterType = filterItem.GetValue(filterTypeKey).Value<string>();
        //                    var filterValues = filterItem.GetValue(filterValuesKey).Value<JArray>();
        //                    filterQuery = filterType;
        //                    string filterIn = "";
        //                    foreach (var filterValue in filterValues)
        //                    {
        //                        var value = filterValue.Value<string>();
        //                        filterIn = filterIn + $"{value},";
        //                    }
        //                    filterIn = filterIn.Substring(0, filterIn.Length - 1);
        //                    filterQuery = filterQuery + $" in ('{filterIn}')";
        //                    queryList.Add(filterQuery);

        //                    //var categorData = filterItem.GetValue(categoryKey).Value<JObject>();
        //                    //if (categorData != null)
        //                    //{
        //                    //    var categorDataArray = categorData.GetValue(filterKey).Value<JArray>();
        //                    //}
        //                    //var subcategoryData = filterItem.GetValue(subcategoryKey).Value<JObject>();
        //                    //if (subcategoryData != null)
        //                    //{

        //                    //}
        //                    //var grouptypeData = filterItem.GetValue(grouptypeKey).Value<JObject>();
        //                    //if (grouptypeData != null)
        //                    //{

        //                    //}
        //                    //var groupsubtypeData = filterItem.GetValue(groupsubtypeKey).Value<JObject>();
        //                    //if (groupsubtypeData != null)
        //                    //{

        //                    //}
        //                    //var typeData = filterItem.GetValue(typeKey).Value<JObject>();
        //                    //if (typeData != null)
        //                    //{

        //                    //}
        //                    //var materialData = filterItem.GetValue(materialKey).Value<JObject>();
        //                    //if (materialData != null)
        //                    //{

        //                    //}
        //                    //var threadtypeData = filterItem.GetValue(threadtypeKey).Value<JObject>();
        //                    //if (threadtypeData != null)
        //                    //{

        //                    //}
        //                    //var headformData = filterItem.GetValue(headformKey).Value<JObject>();
        //                    //if (headformData != null)
        //                    //{

        //                    //}
        //                    //var drivetypeData = filterItem.GetValue(drivetypeKey).Value<JObject>();
        //                    //if (drivetypeData != null)
        //                    //{

        //                    //}
        //                    //var propertyclassData = filterItem.GetValue(propertyclassKey).Value<JObject>();
        //                    //if (propertyclassData != null)
        //                    //{

        //                    //}
        //                    //var surfacefinishData = filterItem.GetValue(surfacefinishKey).Value<JObject>();
        //                    //if (surfacefinishData != null)
        //                    //{

        //                    //}
        //                    //var dimensionsData = filterItem.GetValue(dimensionsKey).Value<JObject>();
        //                    //if (dimensionsData != null)
        //                    //{

        //                    //}
        //                }

        //                int queryCount = 1;
        //                if (queryList.Count > 0)
        //                {
        //                    foreach (var query in queryList)
        //                    {
        //                        if (queryCount == 1)
        //                        {
        //                            baseCommand = $"{baseCommand}  {query}";
        //                        }
        //                        else
        //                        {
        //                            baseCommand = $"{baseCommand} and {query}";
        //                        }
        //                        queryCount++;
        //                    }

        //                }
        //            }

                    
        //        }
        //    }
        //    cmd.CommandText = baseCommand;
        //    await databaseService.OpenConnection();
        //    using var reader = await cmd.ExecuteReaderAsync();

        //    if (reader is not null)
        //    {
        //        while (await reader.ReadAsync())
        //        {
        //            var data = new JObject();
        //            data.Add("id", Convert.ToString(reader["id"]));
        //            data.Add("partnumber", Convert.ToString(reader["partnumber"]));
        //            data.Add("name", Convert.ToString(reader["name"]));
        //            data.Add("description", Convert.ToString(reader["description"]));
        //            data.Add("additionaldescription", Convert.ToString(reader["additionaldescription"]));
        //            data.Add("note", Convert.ToString(reader["note"]));
        //            dataList.Add(data);
        //        }
        //    }
        //    return dataList;
        //}

        public async Task<List<ProductGroupCategoriesDto>> GetProductsGroupCategory()
        {
            //var searchTerm = "Lorem ipsum";

            //var blogs = await context.Blogs
            //    .FromSql($"SELECT * FROM dbo.SearchBlogs({searchTerm})")
            //    .Include(b => b.Posts)
            //    .ToListAsync();

            //        var overAverageIds = await context.Database
            //.SqlQuery<int>($"SELECT [BlogId] AS [Value] FROM [Blogs]")
            //.Where(id => id > context.Blogs.Average(b => b.BlogId))
            //.ToListAsync();

            //using (var context = new BloggingContext())
            //{
            //    var rowsModified = context.Database.ExecuteSql($"UPDATE [Blogs] SET [Url] = NULL");
            //}

            var data = await _databaseContext.Database.SqlQueryRaw<ProductGroupCategoriesDto?>(ProductsCommands.GetProductGroupCategories).AsNoTracking().ToListAsync();
            return data;

        }

        public async Task<List<ProductDataByCategoryWithCount>> GetProductDataByCategoryWithCount()
        {
            var data = await _databaseContext.Database.SqlQueryRaw<ProductDataByCategoryWithCount?>(ProductsCommands.GetProductDataByCategoryWithCount).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<List<ProductDataByCategoryWithCount>> GetProductDataByCategoryWithCountForMetadata(string productcategoryid, List<string> productmetadataname,
            List<string> productmetadatavaluesname)
        {
            string query = ProductsCommands.GetProductDataBySubCategoryWithCountForMetadata.Replace("@productmetadataname", string.Join(",", productmetadataname)).
               Replace("@productmetadatavaluesname", string.Join(",", productmetadatavaluesname)).
           Replace("@productcategoryid", productcategoryid);
            var data = await _databaseContext.Database.SqlQueryRaw<ProductDataByCategoryWithCount?>(query).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<List<ProductDataBySubCategoryWithCount>> GetProductDataBySubCategoryWithCount(string productcategoryid)
        {
            string query = ProductsCommands.GetProductDataBySubCategoryWithCount.Replace("@productcategoryid", productcategoryid);
            var data = await _databaseContext.Database.SqlQueryRaw<ProductDataBySubCategoryWithCount?>(query).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<List<ProductDataBySubCategoryWithCountForMetadata>> GetProductDataBySubCategoryWithCountForMetadata(string productcategoryid, List<string> productmetadataname, 
            List<string> productmetadatavaluesname)
        {
            string query = ProductsCommands.GetProductDataBySubCategoryWithCountForMetadata.Replace("@productmetadataname", string.Join(",", productmetadataname)).
                Replace("@productmetadatavaluesname", string.Join(",", productmetadatavaluesname)).
            Replace("@productcategoryid", productcategoryid); 
            var data = await _databaseContext.Database.SqlQueryRaw<ProductDataBySubCategoryWithCountForMetadata?>(query).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<List<ProductDataBySubCategorySubsetWithCount>> GetProductDataBySubCategorySubsetWithCount(string productsubcategoryid)
        {
            string query = ProductsCommands.GetProductDataBySubCategorySubsetWithCount.Replace("@productsubcategoryid", productsubcategoryid);
            var data = await _databaseContext.Database.SqlQueryRaw<ProductDataBySubCategorySubsetWithCount?>(query).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<List<ProductDataBySubCategorySubsetWithCountForMetadata>> GetProductDataBySubCategorySubsetWithCountForMetadata(string productsubcategoryid, 
            List<string> productmetadataname, List<string> productmetadatavaluesname)
        {
            string query = ProductsCommands.GetProductDataBySubCategorySubsetWithCountForMetadata.Replace("@metdatavalueid", string.Join(",", productmetadataname)).
                Replace("@productmetadatavaluesname", string.Join(",", productmetadatavaluesname)).
                Replace("@productsubcategoryid", productsubcategoryid);
            var data = await _databaseContext.Database.SqlQueryRaw<ProductDataBySubCategorySubsetWithCountForMetadata?>(query).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<List<SearchFilterAll>> GetSearchFilterAllByCategory(string productcategoryid)
        {
            string query = ProductsCommands.GetSearchFilterAllByCategory.Replace("@productcategoryid", productcategoryid);
            var data = await _databaseContext.Database.SqlQueryRaw<SearchFilterAll?>(query).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<List<SearchFilterAll>> GetSearchFilterAllBySubCategory(string productsubcategoryid)
        {
            string query = ProductsCommands.GetSearchFilterAllBySubCategory.Replace("@productsubcategoryid", productsubcategoryid);
            var data = await _databaseContext.Database.SqlQueryRaw<SearchFilterAll?>(query).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<List<SearchFilterAll>> GetSearchFilterAllBySubCategorySubset(string productsubcategorysubsetid)
        {
            string query = ProductsCommands.GetSearchFilterAllBySubCategorySubset.Replace("@productsubcategorysubsetid", productsubcategorysubsetid);
            var data = await _databaseContext.Database.SqlQueryRaw<SearchFilterAll?>(query).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<List<productsdtoListing>> GetProductsByCategorySubCategory(string productcategoryid, string productsubcategoryid)
        {
            string query = ProductsCommands.GetProductsByCategorySubCategory.Replace("@productcategoryid", productcategoryid).
                Replace("@productsubcategoryid", productsubcategoryid);
            var data = await _databaseContext.Database.SqlQueryRaw<productsdtoListing?>(query).AsNoTracking().ToListAsync();
            return data;
        }

        public async Task<List<productsdtoListing>> GetProductsByCategorySubCategoryForMetadata(string productcategoryid, string productsubcategoryid,
            List<string> productmetadataname, List<string> productmetadatavaluesname)
        {
            string query = ProductsCommands.GetProductsByCategorySubCategoryForMetadata.Replace("@metdatavalueid", string.Join(",", productmetadataname)).
                Replace("@productmetadatavaluesname", string.Join(",", productmetadatavaluesname)).
                Replace("@productcategoryid", productcategoryid).
                Replace("@productsubcategoryid", productsubcategoryid);
            var data = await _databaseContext.Database.SqlQueryRaw<productsdtoListing?>(query).AsNoTracking().ToListAsync();
            return data;
        }


        //public async Task<List<JObject>> GetProductsFilterAllByCategory(string id)
        //{
        //    var dataList = new List<JObject>();
        //    using var cmd = databaseService.McPartsonnection.CreateCommand();
        //    cmd.CommandText = ProductsCommands.GetProductsFilterAllByCategory;
        //    cmd.Parameters.AddWithValue("@productcategoryid", id);
        //    await databaseService.OpenConnection();
        //    using var reader = await cmd.ExecuteReaderAsync();

        //    if (reader is not null)
        //    {
        //        while (await reader.ReadAsync())
        //        {
        //            var data = new JObject();
        //            data.Add("productgroupid", Convert.ToString(reader["productgroupid"]));
        //            data.Add("productgroupname", Convert.ToString(reader["productgroupname"]));
        //            data.Add("productcategoryid", Convert.ToString(reader["productcategoryid"]));
        //            data.Add("productcategoryname", Convert.ToString(reader["productcategoryname"]));
        //            dataList.Add(data);
        //        }
        //    }
        //    return dataList;
        //}

        //public async Task<List<JObject>> GetProductsFilterAllBySubCategory(string id)
        //{
        //    var dataList = new List<JObject>();
        //    using var cmd = databaseService.McPartsonnection.CreateCommand();
        //    cmd.CommandText = ProductsCommands.GetProductsFilterAllBySubCategory;
        //    cmd.Parameters.AddWithValue("@productsubcayegoryid", id);
        //    await databaseService.OpenConnection();
        //    using var reader = await cmd.ExecuteReaderAsync();

        //    if (reader is not null)
        //    {
        //        while (await reader.ReadAsync())
        //        {
        //            var data = new JObject();
        //            data.Add("productgroupid", Convert.ToString(reader["productgroupid"]));
        //            data.Add("productgroupname", Convert.ToString(reader["productgroupname"]));
        //            data.Add("productcategoryid", Convert.ToString(reader["productcategoryid"]));
        //            data.Add("productcategoryname", Convert.ToString(reader["productcategoryname"]));
        //            dataList.Add(data);
        //        }
        //    }
        //    return dataList;
        //}

        //public async Task<List<JObject>> GetProductsAllByCategory(string id)
        //{
        //    var dataList = new List<JObject>();
        //    using var cmd = databaseService.McPartsonnection.CreateCommand();
        //    cmd.CommandText = ProductsCommands.GetProductDataByCategory;
        //    cmd.Parameters.AddWithValue("@productcategoryid", id);
        //    await databaseService.OpenConnection();
        //    using var reader = await cmd.ExecuteReaderAsync();

        //    if (reader is not null)
        //    {
        //        while (await reader.ReadAsync())
        //        {
        //            var data = new JObject();
        //            data.Add("productid", Convert.ToString(reader["productid"]));
        //            data.Add("productname", Convert.ToString(reader["productname"]));
        //            data.Add("partnumber", Convert.ToString(reader["partnumber"]));
        //            data.Add("description", Convert.ToString(reader["description"]));
        //            data.Add("partnumber", Convert.ToString(reader["partnumber"]));
        //            data.Add("description", Convert.ToString(reader["description"]));
        //            dataList.Add(data);
        //        }
        //    }
        //    return dataList;
        //}

        //public async Task<List<JObject>> GetAllSearchFilterData()
        //{
        //    var filters = await GetSearchFilters();
        //    var filterData = await GetSearchData();
        //    var listFilters = new List<JObject>();
        //    foreach(var filter in filters)
        //    {
        //        var totalfilter = filter.DeepClone() as JObject;
        //        var tableName = filter.GetValue("category").Value<string>();
        //        var filterDataLocal = filterData.Where(p=>p.GetValue("tablename").Value<string>() == tableName);
        //        if (filterDataLocal != null)
        //        {
        //            totalfilter.Add("filterData", JArray.FromObject(filterDataLocal));
        //            listFilters.Add(totalfilter);
        //        }
        //    }
        //    return listFilters;
        //}

        //private async Task<List<JObject>> GetSearchData()
        //{
        //    var dataList = new List<JObject>();
        //    using var cmd = databaseService.McPartsonnection.CreateCommand();
        //    cmd.CommandText = ProductsCommands.GetSearcFilterData;
        //    await databaseService.OpenConnection();
        //    using var reader = await cmd.ExecuteReaderAsync();

        //    if (reader is not null)
        //    {
        //        while (await reader.ReadAsync())
        //        {
        //            var data = new JObject();
        //            data.Add("id", Convert.ToString(reader["id"]));
        //            data.Add("name", Convert.ToString(reader["name"]));
        //            data.Add("tablename", Convert.ToString(reader["tablename"]));
        //            dataList.Add(data);
        //        }
        //    }
        //    return dataList;
        //}

        //private async Task<List<JObject>> GetSearchFilters()
        //{
        //    var dataList = new List<JObject>();
        //    using var cmd = databaseService.McPartsonnection.CreateCommand();
        //    cmd.CommandText = ProductsCommands.GetSearchFilters;
        //    await databaseService.OpenConnection();
        //    using var reader = await cmd.ExecuteReaderAsync();

        //    if (reader is not null)
        //    {
        //        while (await reader.ReadAsync())
        //        {
        //            var data = new JObject();
        //            data.Add("id", Convert.ToString(reader["id"]));
        //            data.Add("controltype", Convert.ToString(reader["controltype"]));
        //            data.Add("issearchable", Convert.ToString(reader["issearchable"]));
        //            data.Add("ismultiselect", Convert.ToString(reader["ismultiselect"]));
        //            data.Add("isiconsupported", Convert.ToString(reader["isiconsupported"]));
        //            data.Add("category", Convert.ToString(reader["category"]));
        //            dataList.Add(data);
        //        }
        //    }
        //    return dataList;
        //}

        //Task<List<JObject>> IProductsGetSevice.Search(JObject filter)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<List<JObject>> IProductsSevice.GetSearchFilterAll()
        //{
        //    throw new NotImplementedException();
        //}

        //Task<List<JObject>> IProductsSevice.GetSearchFilterAllByCategory(string productcategoryid)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<List<JObject>> IProductsSevice.GetSearchFilterAllBySubCategory(string productsubcategoryid)
        //{
        //    throw new NotImplementedException();
        //}

        //Task<List<JObject>> IProductsSevice.GetSearchFilterAllBySubCategorySubset(List<string> ids)
        //{
        //    throw new NotImplementedException();
        //}


        //Task<List<JObject>> IProductsSevice.GetProductsAllBySubCategory(string id)
        //{
        //    throw new NotImplementedException();
        //}


    }
}
