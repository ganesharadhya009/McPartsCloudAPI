using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record goodsreceivedtoGet : goodsreceivedtoBase
    {
        public string id { get; set; }
    }
    public record goodsreceivedto : goodsreceivedtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record goodsreceivedtoBase : EntityDtoBase
    {
        public string? number { get; set; }

        public DateTime? receivedate { get; set; }

        public int? status { get; set; }

        public string? description { get; set; }

        public string? purchaseorderid { get; set; }
    }
}
