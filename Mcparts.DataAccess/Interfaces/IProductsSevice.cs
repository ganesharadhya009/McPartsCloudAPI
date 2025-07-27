using Mcparts.DataAccess.Dtos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Infrastructure.Interfaces
{
    public interface IProductsSevice : IBaseHandlerSevice
    {
        public Task<bool> Create(ProductsDtoPost data);
        public Task<bool> Update(ProductsDto data);
        public Task<List<JObject>> Search(JObject filter);
        public Task<List<JObject>> GetProductsGroupCategory();
       
        //filer data
        public Task<List<JObject>> GetSearchFilterAll();
        public Task<List<JObject>> GetSearchFilterAllByCategory(string productcategoryid);
        public Task<List<JObject>> GetSearchFilterAllBySubCategory(string productsubcategoryid);
        public Task<List<JObject>> GetSearchFilterAllBySubCategorySubset(List<string> ids);
        
        //data
        public Task<List<JObject>> GetProductDataByCategoryWithCount();
        public Task<List<JObject>> GetProductDataByCategoryWithCountForMetadata(List<string> ids);
        public Task<List<JObject>> GetProductDataBySubCategoryWithCountForMetadata(List<string> ids);
        public Task<List<JObject>> GetProductsAllBySubCategory(string id);
    }
}
