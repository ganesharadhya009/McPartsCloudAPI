using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.DataAccess.Dtos
{
    public record ProductsDto : ProductsDtoBase
    {
        public string id { get; set; }
    }

    public record ProductsDtoPost : ProductsDtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record ProductsDtoBase
    {
        public string? name { get; set; }

        public string? partnumber { get; set; }

        public string? description { get; set; }

        public double? unitprice { get; set; }

        public bool? physical { get; set; }

        public string? unitmeasureid { get; set; }

        public string? productgroupid { get; set; }

        public bool isdeleted { get; set; }

        public DateTime? createdatutc { get; set; }

        public string? createdbyid { get; set; }

        public DateTime? updatedatutc { get; set; }

        public string? updatedbyid { get; set; }

        public string? additionaldescription { get; set; }

        public string? note { get; set; }

        public string? itemcategoryid { get; set; }

        public string? itemsubcategoryid { get; set; }

        public string? itemgrouptypeid { get; set; }

        public string? itemsubgrouptypeid { get; set; }

        public string? itemtypeid { get; set; }

        public string? itemdrivetypeid { get; set; }

        public string? itemdimensiontypeid { get; set; }

        public string? itemheadformtypeid { get; set; }

        public string? itemmaterialtypeid { get; set; }

        public string? itempropertyclasstypeid { get; set; }

        public string? itemsurfacefinishtypeid { get; set; }

        public string? itemthreadtypeid { get; set; }
    }
}
