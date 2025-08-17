using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.DataAccess.Dtos
{
    public record ProductGroupCategoriesDto
    {
        public string? productgroupid { get; set; }

        public string? productgroupname { get; set; }

        public string? productgroupdescription { get; set; }

        public string? productcategoryid { get; set; }

        public string? productcategoryname { get; set; }

        public string? productcategorydescription { get; set; }

        public string? productcategoryiconpath { get; set; }
    }

    public record ProductDataGetBase
    {
        public string? name { get; set; }

        public string? description { get; set; }

        public string? iconpath { get; set; }
    }

    public record ProductDataByCategoryWithCount : ProductDataGetBase
    {
        public int? count { get; set; }

        public string? productcategoryid { get; set; }
    }

    public record ProductDataBySubCategoryWithCount : ProductDataGetBase
    {
        public int? count { get; set; }

        public string? productsubcategoryid { get; set; }
    }

    public record ProductDataBySubCategorySubsetWithCount : ProductDataGetBase
    {
        public int? count { get; set; }

        public string? productsubcategoryid { get; set; }
    }

    public record ProductDataByCategoryWithCountForMetadata : ProductDataGetBase 
    {
        public int? count { get; set; }

        public string? productcategoryid { get; set; }
    }

    public record ProductDataBySubCategoryWithCountForMetadata : ProductDataGetBase
    {
        public int? count { get; set; }

        public string? productsubcategoryid { get; set; }
    }

    public record ProductDataBySubCategorySubsetWithCountForMetadata : ProductDataGetBase
    {
        public int? count { get; set; }

        public string? productsubcategoryid { get; set; }
    }

    public record SearchFilterAll
    {
        public string? metadataid { get; set; }

        public string? metadataname { get; set; }

        public string? controltype { get; set; }

        public bool? issearchable { get; set; }

        public bool? ismultiselect { get; set; }

        public bool? isiconsupported { get; set; }

        public string? metadatavalueid { get; set; }

        public string? metadatavaluename { get; set; }
    }

    public record SearchFilterInput
    {
        public string? categoryId { get; set; }

        public string? subcategoryId { get; set; }

        public List<string>? metadataName { get; set; }

        public List<string>? metadatavalueName { get; set; }
    }

    public record productsdtoListing
    {
        public string id { get; set; }

        public string? name { get; set; }

        public string? partnumber { get; set; }

        public string? description { get; set; }

        public double? unitprice { get; set; }

        public int? lotsize { get; set; }

        public string? note { get; set; }

        public string? additionaldescription { get; set; }
    }

    //public record ProductsDto : ProductsDtoBase
    //{
    //    public string id { get; set; }
    //}

    //public record ProductsDtoPost : ProductsDtoBase
    //{
    //    [JsonIgnore]
    //    public string id { get; set; } = Guid.NewGuid().ToString();
    //}

    //public record ProductsDtoBase
    //{
    //    public string? partnumber { get; set; }

    //    public string? name { get; set; }

    //    public string? description { get; set; }

    //    public bool? isdeleted { get; set; }

    //    public string? createdby { get; set; }

    //    public DateTime? createddate { get; set; }

    //    public string? updatedby { get; set; }

    //    public DateTime? updateddate { get; set; }

    //    public string? additionaldescription { get; set; }

    //    public string? note { get; set; }

    //    public string? itemcategoryid { get; set; }

    //    public string? itemsubcategoryid { get; set; }

    //    public string? itemgrouptypeid { get; set; }

    //    public string? itemsubgrouptypeid { get; set; }

    //    public string? itemtypeid { get; set; }

    //    public string? itemdrivetypeid { get; set; }

    //    public string? itemdimensiontypeid { get; set; }

    //    public string? itemheadformtypeid { get; set; }

    //    public string? itemmaterialtypeid { get; set; }

    //    public string? itempropertyclasstypeid { get; set; }

    //    public string? itemsurfacefinishtypeid { get; set; }

    //    public string? itemthreadtypeid { get; set; }
    //}
}
