using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.DataAccess.Commands
{
    public class ProductsCommands
    {
        public static string GetAll = "select id,partnumber,name,description,additionaldescription,note from itemsviewall where isdeleted=@isdeleted";
        public static string GetById = "SELECT id, name, description FROM public.itemcategory where id=@id and isdeleted=@isdeleted";
        public static string Insert = "INSERT INTO itemcategory(id, name, description)VALUES(@id, @name, @description)";
        public static string Update = "UPDATE itemcategory set name=@name, description=@description where id=@id";
        public static string Delete = "UPDATE itemcategory set isdeleted=@isdeleted where id=@id";

        public static string GetSearchFilters = "select id,controltype, issearchable, ismultiselect, isiconsupported,category from searchfilters";
        public static string GetSearcFilterData = "select id,name,tablename from searchheadervalues";
        public static string Search = "SELECT id,partnumber,name,description,additionaldescription,note FROM itemsviewall";

        public static string GetProductGroupCategories = "select pg.id as productgroupid, pg.name as productgroupname, " +
            "pc.id as productcategoryid, pc.name as productcategoryname " +
            "from productgroup pg " +
            "left join productcategory pc on pg.id = pc.productgroupid";
        
        //filter data
        public static string GetSearchFilterAll = "select distinct pmd.id as metadataid, pmd.name as metadataname, pmd.controltype, " +
            "pmd.issearchable, pmd.ismultiselect, pmd.isiconsupported, pmdv.id as metadatavalueid, pmdv.name as metadatavaluename " +
            "from productmapper pm " +
            "left join productmetadata pmd on pm.productmetadataid = pmd.id " +
            "left join productmetadatavalues pmdv on pmdv.productmetdataid = pmd.id ";

        public static string GetSearchFilterAllByCategory = "select distinct pmd.id as metadataid, pmd.name as metadataname, pmd.controltype, " +
            "pmd.issearchable, pmd.ismultiselect, pmd.isiconsupported, pmdv.id as metadatavalueid, pmdv.name as metadatavaluename " +
            "from productmapper pm " +
            "left join productmetadata pmd on pm.productmetadataid = pmd.id "  +
            "left join productmetadatavalues pmdv on pmdv.productmetdataid = pmd.id " +
            "where pm.productcategoryid ='@productcategoryid'";

        public static string GetSearchFilterAllBySubCategory = "select distinct pmd.id as metadataid, pmd.name as metadataname, pmd.controltype, " +
           "pmd.issearchable, pmd.ismultiselect, pmd.isiconsupported, pmdv.id as metadatavalueid, pmdv.name as metadatavaluename " +
           "from productmapper pm " +
           "left join productmetadata pmd on pm.productmetadataid = pmd.id " +
           "left join productmetadatavalues pmdv on pmdv.productmetdataid = pmd.id " +
           "where pm.productsubcategoryid ='@productsubcategoryid'";

        public static string GetSearchFilterAllBySubCategorySubset = "select distinct pmd.id as metadataid, pmd.name as metadataname, pmd.controltype, " +
          "pmd.issearchable, pmd.ismultiselect, pmd.isiconsupported, pmdv.id as metadatavalueid, pmdv.name as metadatavaluename " +
          "from productmapper pm " +
          "left join productmetadata pmd on pm.productmetadataid = pmd.id " +
          "left join productmetadatavalues pmdv on pmdv.productmetdataid = pmd.id " +
          "where pm.productsubcategorysubsetid ='@productsubcategorysubsetid'";

        //get all product categories
        public static string GetProductsCategoryAll = "select id, name, description, iconpath from productcategory";
        

        // get search results

        public static string GetProductDataByCategoryWithCount = 
            "select COUNT(DISTINCT pm.productid) as count, pm.productcategoryid, pc.name, pc.description ,pc.iconpath " +
            "from productmapper pm " +
            "left join productcategory pc on pm.productcategoryid = pc.id " +
            "group by pm.productcategoryid, pc.id ";

        public static string GetProductDataByCategoryWithCountForMetadata = "select COUNT(DISTINCT pm.productid) as count, pm.productcategoryid, pc.name, pc.description ,pc.iconpath " +
            "from productmapper pm " +
            "left join productcategory pc on pm.productcategoryid = pc.id " +
            "left join productmetadatavalues pmdv on pmdv.productmetdataid = pmd.id " +
            "where pm.productcategoryid in('@productcategoryid') and pm.productmetadataname in('@productmetadataname') and  pm.productmetadatavaluesname in('@productmetadatavaluesname') " +
            "group by pm.productcategoryid, pc.id";

        public static string GetProductDataBySubCategoryWithCount = "select COUNT(DISTINCT pm.productid), pm.productsubcategoryid , psc.name, psc.description ,psc.iconpath " +
            "from productmapper pm " +
            "left join productsubcategory psc on pm.productsubcategoryid = psc.id " +
            "where pm.productcategoryid ='@productcategoryid' " +
            "group by pm.productsubcategoryid, psc.id";

        public static string GetProductDataBySubCategoryWithCountForMetadata = "select COUNT(DISTINCT pm.productid), pm.productsubcategoryid , psc.name, psc.description ,psc.iconpath " +
            "from productmapper pm " +
            "left join productsubcategory psc on pm.productsubcategoryid = psc.id " +
            "where pm.productcategoryid in('@productcategoryid') and pm.productmetadataname in('@productmetadataname') and  pm.productmetadatavaluesname in('@productmetadatavaluesname') " +
            "group by pm.productsubcategoryid, psc.id";

        public static string GetProductDataBySubCategorySubsetWithCount = "select COUNT(DISTINCT pm.productid), pm.productsubcategoryid , psc.name, psc.description ,psc.iconpath " +
           "from productmapper pm " +
           "left join productsubcategory psc on pm.productsubcategoryid = psc.id " +
           "where pm.productsubcategoryid ='@productsubcategoryid' " +
           "group by pm.productsubcategoryid, psc.id";

        public static string GetProductDataBySubCategorySubsetWithCountForMetadata = "select COUNT(DISTINCT pm.productid), pm.productsubcategoryid , psc.name, psc.description ,psc.iconpath " +
            "from productmapper pm " +
            "left join productmetadata pmd on pm.productmetadataid = pmd.id " +
            "left join productmetadatavalues pmdv on pmdv.productmetdataid = pmd.id " +
            "where pm.productsubcategoryid in('@productsubcategoryid') and pm.productmetadataname in('@productmetadataname') and  pm.productmetadatavaluesname in('@productmetadatavaluesname') " +
            "group by pm.productsubcategoryid, psc.id";
    }

   
}
