using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.DataAccess.Dtos
{
    public record ItemsDto : ItemsDtoBase
    {
        public string id { get; set; }
    }

    public record ItemsDtoPost : ItemsDtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record ItemsDtoBase
    {
        public string? partnumber { get; set; }

        public string? name { get; set; }

        public string? description { get; set; }

        public bool? isdeleted { get; set; }

        public string? createdby { get; set; }

        public DateTime? createddate { get; set; }

        public string? updatedby { get; set; }

        public DateTime? updateddate { get; set; }

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
