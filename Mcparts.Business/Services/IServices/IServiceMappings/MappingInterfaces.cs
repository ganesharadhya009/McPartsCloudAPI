using AutoMapper;
using Mcparts.Business.Dtos;
using Mcparts.DataAccess.Interfaces;
using Mcparts.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Business.Services.IServices.IServiceMappings
{
    public interface IProductGroupService : IGenericServiceAsync<productgroup, productgroupdto>
    {
    }

    public interface IProductCategoryService : IGenericServiceAsync<productcategory, productcategorydto>
    {
    }

    public interface IProductMetadataService : IGenericServiceAsync<productmetadata, productmetadatadto>
    {
    }

    public interface IProductMetadataValuesService : IGenericServiceAsync<productmetadatavalues, productmetadatavaluesdto>
    {
    }

    public interface IProductSubCategoryService : IGenericServiceAsync<productsubcategory, productsubcategorydto>
    {
    }

    public interface IProductSubCategorySubsetService : IGenericServiceAsync<productsubcategorysubset, productsubcategorysubsetdto>
    {
    }

    public interface IProductsService : IGenericServiceAsync<products, productsdto>
    {
    }

    public interface IProductMapperService : IGenericServiceAsync<productmapper, productmapperdto>
    {
    }

    public interface ICustomersService : IGenericServiceAsync<customer, customerdto>
    {
    }

    public interface IUsersService : IGenericServiceAsync<users, usersdto>
    {
    }


}
