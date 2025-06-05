using Mcparts.DataAccess.Dtos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Infrastructure.Interfaces
{
    public interface IItemsSevice : IBaseHandlerSevice
    {
        public Task<bool> Create(ItemsDtoPost data);
        public Task<bool> Update(ItemsDto data);
        public Task<List<JObject>> Search(JObject filter);
        public Task<List<JObject>> GetAllSearchFilterData();
    }
}
