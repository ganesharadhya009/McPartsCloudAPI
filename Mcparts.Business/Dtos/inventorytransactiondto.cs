using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record inventorytransactiondtoGet : inventorytransactiondtoBase
    {
        public string id { get; set; }
    }
    public record inventorytransactiondto : inventorytransactiondtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record inventorytransactiondtoBase : EntityDtoBase
    {
        public string? moduleid { get; set; }

        public string? modulename { get; set; }

        public string? modulecode { get; set; }

        public string? modulenumber { get; set; }

        public DateTime? movementdate { get; set; }

        public int? status { get; set; }

        public string? number { get; set; }

        public string? warehouseid { get; set; }

        public string? productid { get; set; }

        public double? movement { get; set; }

        public int? transtype { get; set; }

        public double? stock { get; set; }

        public string? warehousefromid { get; set; }

        public string? warehousetoid { get; set; }

        public double? qtyscsys { get; set; }

        public double? qtysccount { get; set; }

        public double? qtyscdelta { get; set; }
    }
}
