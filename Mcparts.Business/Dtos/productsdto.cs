using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record productsdtoGet : productsdtoBase
    {
        public string id { get; set; }
    }

    public record productsdto : productsdtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record productsdtoBase : EntityDtoBase
    {
        public string? name { get; set; }

        public string? partnumber { get; set; }

        public string? description { get; set; }

        public double? unitprice { get; set; }

        public bool? physical { get; set; }

        public string? unitmeasureid { get; set; }

        public string? additionaldescription { get; set; }

        public string? note { get; set; }

        public int? lotsize { get; set; }
    }
}
