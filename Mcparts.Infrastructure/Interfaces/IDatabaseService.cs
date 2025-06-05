using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Infrastructure.Interfaces
{
    public interface IDatabaseService
    {
        public Task<bool> OpenConnection();
        public Task<bool> CloseConnection();
        public NpgsqlConnection McPartsonnection { get; }
    }
}
