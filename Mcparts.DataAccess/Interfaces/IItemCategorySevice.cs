using Mcparts.DataAccess.Dtos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Infrastructure.Interfaces
{
    public interface IItemCategorySevice : IBaseHandlerSevice
    {
        public Task<bool> Create(ItemCategoryDtoPost data);
        public Task<bool> Update(ItemCategoryDto data);
    }
}
