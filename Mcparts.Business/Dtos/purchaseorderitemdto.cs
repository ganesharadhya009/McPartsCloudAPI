using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record purchaseorderitemdtoGet : purchaseorderitemdtoBase
    {
        public string id { get; set; }
    }
    public record purchaseorderitemdto : purchaseorderitemdtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record purchaseorderitemdtoBase : EntityDtoBase
    {
        public string? purchaseorderid { get; set; }

        public string? productid { get; set; }

        public string? summary { get; set; }

        public double? unitprice { get; set; }

        public double? quantity { get; set; }

        public double? total { get; set; }
    }
}
