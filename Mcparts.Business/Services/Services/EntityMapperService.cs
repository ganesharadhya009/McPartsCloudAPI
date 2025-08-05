using AutoMapper;
using Mcparts.Business.Dtos;
using Mcparts.Business.Services.IServices.IServiceMappings;
using Mcparts.DataAccess.Common;
using Mcparts.DataAccess.Interfaces;
using Mcparts.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Business.Services.Services
{
    public class ProductGroupService : GenericServiceAsync<productgroup, productgroupdto>, IProductGroupService
    {
        public ProductGroupService(IGenericRepository<productgroup, productgroupdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class ProductCategoryService : GenericServiceAsync<productcategory, productcategorydto>, IProductCategoryService
    {
        public ProductCategoryService(IGenericRepository<productcategory, productcategorydto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class ProductMetadataService : GenericServiceAsync<productmetadata, productmetadatadto>, IProductMetadataService
    {
        public ProductMetadataService(IGenericRepository<productmetadata, productmetadatadto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class ProductMetadataValuesService : GenericServiceAsync<productmetadatavalues, productmetadatavaluesdto>, IProductMetadataValuesService
    {
        public ProductMetadataValuesService(IGenericRepository<productmetadatavalues, productmetadatavaluesdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class ProductSubCategoryService : GenericServiceAsync<productsubcategory, productsubcategorydto>, IProductSubCategoryService
    {
        public ProductSubCategoryService(IGenericRepository<productsubcategory, productsubcategorydto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class ProductSubCategorySubsetService : GenericServiceAsync<productsubcategorysubset, productsubcategorysubsetdto>, IProductSubCategorySubsetService
    {
        public ProductSubCategorySubsetService(IGenericRepository<productsubcategorysubset, productsubcategorysubsetdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class ProductsService : GenericServiceAsync<products, productsdto>, IProductsService
    {
        public ProductsService(IGenericRepository<products, productsdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class ProductMapperService : GenericServiceAsync<productmapper, productmapperdto>, IProductMapperService
    {
        public ProductMapperService(IGenericRepository<productmapper, productmapperdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class CustomersService : GenericServiceAsync<customer, customerdto>, ICustomersService
    {
        public CustomersService(IGenericRepository<customer, customerdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }


    }

    public class UsersService : GenericServiceAsync<users, usersdto>, IUsersService
    {
        public UsersService(IGenericRepository<users, usersdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }

        public usersdto GetUsersDtoFromCustomerDto(customerdto data)
        {
            var userdata = new usersdto()
            {
                firstname = data.name,
                primarycontactnumber = data.number,
                secondarycontactnumber = data.phonenumber,
                email = data.emailaddress,
                usertype = ApplicationConstants.UserTypeMember,
                registereddate = DateTime.UtcNow,
                userstatusid = ApplicationConstants.UserStatusActive

            };
            return userdata;
        }
    }




}
