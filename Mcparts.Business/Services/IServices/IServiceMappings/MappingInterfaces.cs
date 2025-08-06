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
        public usersdto GetUsersDtoFromCustomerDto(customerdto data);
    }

    public interface ICustomerCategoryService : IGenericServiceAsync<customercategory, customercategorydto>
    {
    }

    public interface IDeliveryOrderService : IGenericServiceAsync<deliveryorder, deliveryorderdto>
    {
    }

    public interface IGoodsReceiveService : IGenericServiceAsync<goodsreceive, goodsreceivedto>
    {
    }

    public interface IInventoryTransactionService : IGenericServiceAsync<inventorytransaction, inventorytransactiondto>
    {
    }

    public interface INumberSequenceService : IGenericServiceAsync<numbersequence, numbersequencedto>
    {
    }

    public interface IPurchaseOrderService : IGenericServiceAsync<purchaseorder, purchaseorderdto>
    {
    }

    public interface IPurchaseOrderItemService : IGenericServiceAsync<purchaseorderitem, purchaseorderitemdto>
    {
    }

    public interface IPurchaseReturnService : IGenericServiceAsync<purchasereturn, purchasereturndto>
    {
    }

    public interface IRolesService : IGenericServiceAsync<roles, rolesdto>
    {
    }

    public interface ISalesOrderService : IGenericServiceAsync<salesorder, salesorderdto>
    {
    }

    public interface ISalesOrderItemService : IGenericServiceAsync<salesorderitem, salesorderitemdto>
    {
    }

    public interface ISalesReturnService : IGenericServiceAsync<salesreturn, salesreturndto>
    {
    }

    public interface IScrappingService : IGenericServiceAsync<scrapping, scrappingdto>
    {
    }

    public interface IStockCountService : IGenericServiceAsync<stockcount, stockcountdto>
    {
    }

    public interface ITaxService : IGenericServiceAsync<tax, taxdto>
    {
    }

    public interface ITransferInService : IGenericServiceAsync<transferin, transferindto>
    {
    }

    public interface ITransferOutService : IGenericServiceAsync<transferout, transferoutdto>
    {
    }

    public interface IUnitMeasureService : IGenericServiceAsync<unitmeasure, unitmeasuredto>
    {
    }

    public interface IVendorService : IGenericServiceAsync<vendor, vendordto>
    {
    }

    public interface IVendorCategoryService : IGenericServiceAsync<vendorcategory, vendorcategorydto>
    {
    }

    public interface IVendorGroupService : IGenericServiceAsync<vendorgroup, vendorgroupdto>
    {
    }

    public interface IWarehouseService : IGenericServiceAsync<warehouse, warehousedto>
    {
    }

    public interface ICustomerGroupService : IGenericServiceAsync<customergroup, customergroupdto>
    {
    }

    public interface ICompanyService : IGenericServiceAsync<company, companydto>
    {
    }


}
