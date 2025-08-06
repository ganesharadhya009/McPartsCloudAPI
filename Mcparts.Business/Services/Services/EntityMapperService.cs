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

    public class CustomerCategoryService : GenericServiceAsync<customercategory, customercategorydto>, ICustomerCategoryService
    {
        public CustomerCategoryService(IGenericRepository<customercategory, customercategorydto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class DeliveryOrderService : GenericServiceAsync<deliveryorder, deliveryorderdto>, IDeliveryOrderService
    {
        public DeliveryOrderService(IGenericRepository<deliveryorder, deliveryorderdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class GoodsReceiveService : GenericServiceAsync<goodsreceive, goodsreceivedto>, IGoodsReceiveService
    {
        public GoodsReceiveService(IGenericRepository<goodsreceive, goodsreceivedto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class InventoryTransactionService : GenericServiceAsync<inventorytransaction, inventorytransactiondto>, IInventoryTransactionService
    {
        public InventoryTransactionService(IGenericRepository<inventorytransaction, inventorytransactiondto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class NumberSequenceService : GenericServiceAsync<numbersequence, numbersequencedto>, INumberSequenceService
    {
        public NumberSequenceService(IGenericRepository<numbersequence, numbersequencedto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class PurchaseOrderService : GenericServiceAsync<purchaseorder, purchaseorderdto>, IPurchaseOrderService
    {
        public PurchaseOrderService(IGenericRepository<purchaseorder, purchaseorderdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class PurchaseOrderItemService : GenericServiceAsync<purchaseorderitem, purchaseorderitemdto>, IPurchaseOrderItemService
    {
        public PurchaseOrderItemService(IGenericRepository<purchaseorderitem, purchaseorderitemdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class PurchaseReturnService : GenericServiceAsync<purchasereturn, purchasereturndto>, IPurchaseReturnService
    {
        public PurchaseReturnService(IGenericRepository<purchasereturn, purchasereturndto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class RolesService : GenericServiceAsync<roles, rolesdto>, IRolesService
    {
        public RolesService(IGenericRepository<roles, rolesdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class SalesOrderService : GenericServiceAsync<salesorder, salesorderdto>, ISalesOrderService
    {
        public SalesOrderService(IGenericRepository<salesorder, salesorderdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class SalesOrderItemService : GenericServiceAsync<salesorderitem, salesorderitemdto>, ISalesOrderItemService
    {
        public SalesOrderItemService(IGenericRepository<salesorderitem, salesorderitemdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class SalesReturnService : GenericServiceAsync<salesreturn, salesreturndto>, ISalesReturnService
    {
        public SalesReturnService(IGenericRepository<salesreturn, salesreturndto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class ScrappingService : GenericServiceAsync<scrapping, scrappingdto>, IScrappingService
    {
        public ScrappingService(IGenericRepository<scrapping, scrappingdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class StockCountService : GenericServiceAsync<stockcount, stockcountdto>, IStockCountService
    {
        public StockCountService(IGenericRepository<stockcount, stockcountdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class TaxService : GenericServiceAsync<tax, taxdto>, ITaxService
    {
        public TaxService(IGenericRepository<tax, taxdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class TransferInService : GenericServiceAsync<transferin, transferindto>, ITransferInService
    {
        public TransferInService(IGenericRepository<transferin, transferindto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class TransferOutService : GenericServiceAsync<transferout, transferoutdto>, ITransferOutService
    {
        public TransferOutService(IGenericRepository<transferout, transferoutdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class UnitMeasureService : GenericServiceAsync<unitmeasure, unitmeasuredto>, IUnitMeasureService
    {
        public UnitMeasureService(IGenericRepository<unitmeasure, unitmeasuredto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class VendorService : GenericServiceAsync<vendor, vendordto>, IVendorService
    {
        public VendorService(IGenericRepository<vendor, vendordto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class VendorCategoryService : GenericServiceAsync<vendorcategory, vendorcategorydto>, IVendorCategoryService
    {
        public VendorCategoryService(IGenericRepository<vendorcategory, vendorcategorydto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class VendorGroupService : GenericServiceAsync<vendorgroup, vendorgroupdto>, IVendorGroupService
    {
        public VendorGroupService(IGenericRepository<vendorgroup, vendorgroupdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class WarehouseService : GenericServiceAsync<warehouse, warehousedto>, IWarehouseService
    {
        public WarehouseService(IGenericRepository<warehouse, warehousedto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class CustomerGroupService : GenericServiceAsync<customergroup, customergroupdto>, ICustomerGroupService
    {
        public CustomerGroupService(IGenericRepository<customergroup, customergroupdto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }

    public class CompanyService : GenericServiceAsync<company, companydto>, ICompanyService
    {
        public CompanyService(IGenericRepository<company, companydto> genericRepository, IMapper mapper, IUnitOfWork unitofwork) : base(unitofwork, mapper)
        {
        }
    }



}
