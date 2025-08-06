using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record purchasereturndtoGet : purchasereturndtoBase
    {
        public string id { get; set; }
    }
    public record purchasereturndto : purchasereturndtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record class purchasereturndtoBase : EntityDtoBase
    {
        public string? number { get; set; }

        public DateTime? returndate { get; set; }

        public int? status { get; set; }

        public string? description { get; set; }

        public string? goodsreceiveid { get; set; }
    }
}
