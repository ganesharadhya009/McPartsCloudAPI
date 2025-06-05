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
    public class ItemCategorySevice : IItemCategorySevice
    {
        IDatabaseService databaseService;
        public ItemCategorySevice(IDatabaseService databaseService) {
            this.databaseService = databaseService;
        }

        private void AddParameters(NpgsqlCommand command, ItemCategoryDto itemCategory)
        {
            var parameters = command.Parameters;

            parameters.AddWithValue("@id", itemCategory.id);
            parameters.AddWithValue("@name", itemCategory.name ?? string.Empty);
            parameters.AddWithValue("@description", itemCategory.description ?? string.Empty);
        }

        public async Task<List<JObject>> GetAll()
        {
            var itemCategories = new List<JObject>();
            using var cmd = databaseService.McPartsonnection.CreateCommand();
            cmd.CommandText = ItemCategory.GetAll;
            cmd.Parameters.AddWithValue("@isdeleted", false);
            await databaseService.OpenConnection();
            using var reader = await cmd.ExecuteReaderAsync();

            if (reader is not null)
            {
                while (await reader.ReadAsync())
                {
                    var itemCategory = new JObject();
                    itemCategory.Add("id", Convert.ToString(reader["id"]));
                    itemCategory.Add("name", Convert.ToString(reader["name"]));
                    itemCategory.Add("description", Convert.ToString(reader["description"]));
                    itemCategories.Add(itemCategory);
                }
            }
            return itemCategories;
        }

        public async Task<bool> Create(ItemCategoryDtoPost itemCategory)
        {
            using var cmd = databaseService.McPartsonnection.CreateCommand();
            cmd.CommandText = ItemCategory.Insert;
            cmd.CommandType = System.Data.CommandType.Text;

            cmd.Parameters.AddWithValue("@id", itemCategory.id);
            cmd.Parameters.AddWithValue("@name", itemCategory.name ?? string.Empty);
            cmd.Parameters.AddWithValue("@description", itemCategory.description ?? string.Empty);
            await databaseService.OpenConnection();
            var rowAffected = await cmd.ExecuteNonQueryAsync();
            return rowAffected > 0;
        }

        public async Task<bool> Update(ItemCategoryDto itemCategory)
        {
            using var cmd = databaseService.McPartsonnection.CreateCommand();
            cmd.CommandText = ItemCategory.Update;
            AddParameters(cmd, itemCategory);
            await databaseService.OpenConnection();
            var rowAffected = await cmd.ExecuteNonQueryAsync();
            return rowAffected > 0;
        }

        public async Task<JObject> GetById(string id)
        {
            var itemCategory = new JObject();
            using var cmd = databaseService.McPartsonnection.CreateCommand();
            cmd.CommandText = ItemCategory.GetById;
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
            cmd.CommandText = ItemCategory.Delete;
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@isdeleted", true);
            await databaseService.OpenConnection();
            var rowAffected = await cmd.ExecuteNonQueryAsync();
            return rowAffected > 0;
        }
    }
}
