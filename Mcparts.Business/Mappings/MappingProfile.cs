using AutoMapper;
using Mcparts.Business.Dtos;
using Mcparts.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Mcparts.Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<productgroup, productgroupdto>().ReverseMap();
            CreateMap<productgroup, productgroupdto>();
            CreateMap<productgroupdto, productgroupdtoGet>().ReverseMap();
            CreateMap<productgroupdto, productgroupdtoGet>();

            CreateMap<productcategory, productcategorydto>().ReverseMap();
            CreateMap<productcategory, productcategorydto>();
            CreateMap<productcategorydto, productcategorydtoGet>().ReverseMap();
            CreateMap<productcategorydto, productcategorydtoGet>();

            CreateMap<productmetadata, productmetadatadto>().ReverseMap();
            CreateMap<productmetadata, productmetadatadto>();
            CreateMap<productmetadatadto, productmetadatadtoGet>().ReverseMap();
            CreateMap<productmetadatadto, productcategorydtoGet>();

            CreateMap<productmetadatavalues, productmetadatavaluesdto>().ReverseMap();
            CreateMap<productmetadatavalues, productmetadatavaluesdto>();
            CreateMap<productmetadatavaluesdto, productmetadatavaluesdtoGet>().ReverseMap();
            CreateMap<productmetadatavaluesdto, productmetadatavaluesdtoGet>();

            CreateMap<productsubcategory, productsubcategorydto>().ReverseMap();
            CreateMap<productsubcategory, productsubcategorydto>();
            CreateMap<productsubcategorydto, productsubcategorydtoGet>().ReverseMap();
            CreateMap<productsubcategorydto, productsubcategorydtoGet>();

            CreateMap<productsubcategorysubset, productsubcategorysubsetdto>().ReverseMap();
            CreateMap<productsubcategorysubset, productsubcategorysubsetdto>();
            CreateMap<productsubcategorysubsetdto, productsubcategorysubsetdtoGet>().ReverseMap();
            CreateMap<productsubcategorysubsetdto, productsubcategorysubsetdtoGet>();

            CreateMap<products, productsdto>().ReverseMap();
            CreateMap<products, productsdto>();
            CreateMap<productsdto, productsdtoGet>().ReverseMap();
            CreateMap<productsdto, productsdtoGet>();

            CreateMap<productmapper, productmapperdto>().ReverseMap();
            CreateMap<productmapper, productmapperdto>();
            CreateMap<productmapperdto, productmapperdtoGet>().ReverseMap();
            CreateMap<productmapperdto, productmapperdtoGet>();

            CreateMap<customer, customerdto>().ReverseMap();
            CreateMap<customer, customerdto>();
            CreateMap<customerdto, customerdtoGet>().ReverseMap();
            CreateMap<customerdto, customerdtoGet>();

            CreateMap<customercategory, customercategorydto>().ReverseMap();
            CreateMap<customercategory, customercategorydto>();
            CreateMap<customercategorydto, customercategorydtoGet>().ReverseMap();
            CreateMap<customercategorydto, customercategorydtoGet>();

            CreateMap<customergroup, customergroupdto>().ReverseMap();
            CreateMap<customergroup, customergroupdto>();
            CreateMap<customergroupdto, customergroupdtoGet>().ReverseMap();
            CreateMap<customergroupdto, customergroupdtoGet>();

            CreateMap<users, usersdto>().ReverseMap();
            CreateMap<users, usersdto>();
            CreateMap<usersdto, usersdtoGet>().ReverseMap();
            CreateMap<usersdto, usersdtoGet>();
           

            CreateMap<deliveryorder, deliveryorderdto>().ReverseMap();
            CreateMap<deliveryorder, deliveryorderdto>();
            CreateMap<deliveryorderdto, deliveryorderdtoGet>().ReverseMap();
            CreateMap<deliveryorderdto, deliveryorderdtoGet>();

            CreateMap<goodsreceive, goodsreceivedto>().ReverseMap();
            CreateMap<goodsreceive, goodsreceivedto>();
            CreateMap<goodsreceivedto, goodsreceivedtoGet>().ReverseMap();
            CreateMap<goodsreceivedto, goodsreceivedtoGet>();

            CreateMap<goodsreceive, goodsreceivedto>().ReverseMap();
            CreateMap<goodsreceive, goodsreceivedto>();
            CreateMap<goodsreceivedto, goodsreceivedtoGet>().ReverseMap();
            CreateMap<goodsreceivedto, goodsreceivedtoGet>();

            CreateMap<inventorytransaction, inventorytransactiondto>().ReverseMap();
            CreateMap<inventorytransaction, inventorytransactiondto>();
            CreateMap<inventorytransactiondto, inventorytransactiondtoGet>().ReverseMap();
            CreateMap<inventorytransactiondto, inventorytransactiondtoGet>();

            CreateMap<numbersequence, numbersequencedto>().ReverseMap();
            CreateMap<numbersequence, numbersequencedto>();
            CreateMap<numbersequencedto, numbersequencedtoGet>().ReverseMap();
            CreateMap<numbersequencedto, numbersequencedtoGet>();

            CreateMap<purchaseorder, purchaseorderdto>().ReverseMap();
            CreateMap<purchaseorder, purchaseorderdto>();
            CreateMap<purchaseorderdto, purchaseorderdtoGet>().ReverseMap();
            CreateMap<purchaseorderdto, purchaseorderdtoGet>();

            CreateMap<purchaseorderitem, purchaseorderitemdto>().ReverseMap();
            CreateMap<purchaseorderitem, purchaseorderitemdto>();
            CreateMap<purchaseorderitemdto, purchaseorderitemdtoGet>().ReverseMap();
            CreateMap<purchaseorderitemdto, purchaseorderitemdtoGet>();

            CreateMap<purchasereturn, purchasereturndto>().ReverseMap();
            CreateMap<purchasereturn, purchasereturndto>();
            CreateMap<purchasereturndto, purchasereturndtoGet>().ReverseMap();
            CreateMap<purchasereturndto, purchasereturndtoGet>();

            CreateMap<roles, rolesdto>().ReverseMap();
            CreateMap<roles, rolesdto>();
            CreateMap<rolesdto, rolesdtoGet>().ReverseMap();
            CreateMap<rolesdto, rolesdtoGet>();

            CreateMap<salesorder, salesorderdto>().ReverseMap();
            CreateMap<salesorder, salesorderdto>();
            CreateMap<salesorderdto, salesorderdtoGet>().ReverseMap();
            CreateMap<salesorderdto, salesorderdtoGet>();

            CreateMap<salesorderitem, salesorderitemdto>().ReverseMap();
            CreateMap<salesorderitem, salesorderitemdto>();
            CreateMap<salesorderitemdto, salesorderitemdtoGet>().ReverseMap();
            CreateMap<salesorderitemdto, salesorderitemdtoGet>();

            CreateMap<salesreturn, salesreturndto>().ReverseMap();
            CreateMap<salesreturn, salesreturndto>();
            CreateMap<salesreturndto, salesreturndtoGet>().ReverseMap();
            CreateMap<salesreturndto, salesreturndtoGet>();

            CreateMap<scrapping, scrappingdto>().ReverseMap();
            CreateMap<scrapping, scrappingdto>();
            CreateMap<scrappingdto, scrappingdtoGet>().ReverseMap();
            CreateMap<scrappingdto, scrappingdtoGet>();

            CreateMap<stockcount, stockcountdto>().ReverseMap();
            CreateMap<stockcount, stockcountdto>();
            CreateMap<stockcountdto, stockcountdtoGet>().ReverseMap();
            CreateMap<stockcountdto, stockcountdtoGet>();

            CreateMap<tax, taxdto>().ReverseMap();
            CreateMap<tax, taxdto>();
            CreateMap<taxdto, taxdtoGet>().ReverseMap();
            CreateMap<taxdto, taxdtoGet>();

            CreateMap<transferin, transferindto>().ReverseMap();
            CreateMap<transferin, transferindto>();
            CreateMap<transferindto, transferindtoGet>().ReverseMap();
            CreateMap<transferindto, transferindtoGet>();

            CreateMap<transferout, transferoutdto>().ReverseMap();
            CreateMap<transferout, transferoutdto>();
            CreateMap<transferoutdto, transferoutdtoGet>().ReverseMap();
            CreateMap<transferoutdto, transferoutdtoGet>();

            CreateMap<unitmeasure, unitmeasuredto>().ReverseMap();
            CreateMap<unitmeasure, unitmeasuredto>();
            CreateMap<unitmeasuredto, unitmeasuredtoGet>().ReverseMap();
            CreateMap<unitmeasuredto, unitmeasuredtoGet>();

            CreateMap<vendor, vendordto>().ReverseMap();
            CreateMap<vendor, vendordto>();
            CreateMap<vendordto, vendordtoGet>().ReverseMap();
            CreateMap<vendordto, vendordtoGet>();

            CreateMap<vendorcategory, vendorcategorydto>().ReverseMap();
            CreateMap<vendorcategory, vendorcategorydto>();
            CreateMap<vendorcategorydto, vendorcategorydtoGet>().ReverseMap();
            CreateMap<vendorcategorydto, vendorcategorydtoGet>();

            CreateMap<vendorgroup, vendorgroupdto>().ReverseMap();
            CreateMap<vendorgroup, vendorgroupdto>();
            CreateMap<vendorgroupdto, vendorgroupdtoGet>().ReverseMap();
            CreateMap<vendorgroupdto, vendorgroupdtoGet>();

            CreateMap<warehouse, warehousedto>().ReverseMap();
            CreateMap<warehouse, warehousedto>();
            CreateMap<warehousedto, warehousedtoGet>().ReverseMap();
            CreateMap<warehousedto, warehousedtoGet>();

            CreateMap<company, companydto>().ReverseMap();
            CreateMap<company, companydto>();
            CreateMap<companydto, companydtoGet>().ReverseMap();
            CreateMap<companydto, companydtoGet>();



        }
    }
}
