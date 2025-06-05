using Mcparts.DataAccess.Commands;
using Mcparts.DataAccess.Dtos;
using Mcparts.Infrastructure.Interfaces;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Infrastructure.Services
{
    public class DatabaseService : IDatabaseService, IDisposable
    {
        public NpgsqlConnection connection;

        public NpgsqlConnection McPartsonnection
        {
            get { 
             return connection;
            }
        }

        public DatabaseService(NpgsqlConnection connection) 
        {
            this.connection = connection;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> OpenConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open) 
            {
                return true;
            }
            await connection.OpenAsync();
            return true;
        }

        public async Task<bool> CloseConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                await connection.CloseAsync();
            }
           
            return true;
        }

        public async Task<bool> HandleWorkItem(ItemCategoryDto itemCategory, string commandText)
        {
            using var cmd = connection.CreateCommand();
            cmd.CommandText = commandText;
            await OpenConnection();
            var rowAffected = await cmd.ExecuteNonQueryAsync();
            return rowAffected > 0;
        }
    }
}
