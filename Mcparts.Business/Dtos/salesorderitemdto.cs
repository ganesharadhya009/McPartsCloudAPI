using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record salesorderitemdtoGet : salesorderitemdtoBase
    {
        public string id { get; set; }
    }
    public record salesorderitemdto : salesorderitemdtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record salesorderitemdtoBase : EntityDtoBase
    {
        public string? salesorderid { get; set; }

        public string? productid { get; set; }

        public string? summary { get; set; }

        public double? unitprice { get; set; }

        public double? quantity { get; set; }

        public double? total { get; set; }
    }
}
