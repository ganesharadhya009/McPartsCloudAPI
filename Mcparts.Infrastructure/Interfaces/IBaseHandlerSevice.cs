using Mcparts.DataAccess.Dtos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Infrastructure.Interfaces
{
    public interface IBaseHandlerSevice
    {
        public Task<List<JObject>> GetAll();
        public Task<JObject> GetById(string id);
        public Task<bool> Delete(string id);
    }
}
