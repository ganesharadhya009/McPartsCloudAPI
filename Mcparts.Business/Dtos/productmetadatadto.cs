using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record productmetadatadtoGet : productmetadatadtoBase
    {
        public string id { get; set; }
    }
    public record productmetadatadto : productmetadatadtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record productmetadatadtoBase : EntityDtoBase
    {
        public string? name { get; set; }

        public string? description { get; set; }
       

        public string? productsubcategoryid { get; set; }

        public string? controltype { get; set; }

        public bool? issearchable { get; set; }

        public bool? ismultiselect { get; set; }

        public bool? isiconsupported { get; set; }

        public string? productcategoryid { get; set; }

        public string? productsubcategoryidsubsetid { get; set; }
    }
}
