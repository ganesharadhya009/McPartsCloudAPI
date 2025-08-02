using Mcparts.DataAccess.Dtos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Infrastructure.Interfaces
{
    public interface IProductsGetSevice 
    {
        //public Task<bool> Create(ProductsDtoPost data);
        //public Task<bool> Update(ProductsDto data);
        //public Task<List<JObject>> GetProductsGroupCategory();

        public Task<List<ProductGroupCategoriesDto>> GetProductsGroupCategory();
        //public Task<List<JObject>> Search(JObject filter);
        

        //filer data
        //public Task<List<JObject>> GetSearchFilterAll();
        public Task<List<SearchFilterAll>> GetSearchFilterAllByCategory(string productcategoryid);
        public Task<List<SearchFilterAll>> GetSearchFilterAllBySubCategory(string id);
        public Task<List<SearchFilterAll>> GetSearchFilterAllBySubCategorySubset(string id);
        //public Task<List<JObject>> GetSearchFilterAllBySubCategorySubset(List<string> ids);

        //data
        public Task<List<ProductDataByCategoryWithCount>> GetProductDataByCategoryWithCount();
        public Task<List<ProductDataByCategoryWithCount>> GetProductDataByCategoryWithCountForMetadata(List<string> ids);
        public Task<List<ProductDataBySubCategoryWithCount>> GetProductDataBySubCategoryWithCount(string productcategoryid);
        public Task<List<ProductDataBySubCategoryWithCountForMetadata>> GetProductDataBySubCategoryWithCountForMetadata(List<string> ids, string productcategoryid);
        public Task<List<ProductDataBySubCategorySubsetWithCount>> GetProductDataBySubCategorySubsetWithCount(string productsubcategoryid);
        public Task<List<ProductDataBySubCategorySubsetWithCountForMetadata>> GetProductDataBySubCategorySubsetWithCountForMetadata(List<string> ids, string productsubcategoryid);

        //public Task<List<JObject>> GetProductsAllBySubCategory(string id);
    }
}
