using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record purchaseorderdtoGet : purchaseorderdtoBase
    {
        public string id { get; set; }
    }
    public record purchaseorderdto : purchaseorderdtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record purchaseorderdtoBase : EntityDtoBase
    {
        public string? number { get; set; }

        public DateTime? orderdate { get; set; }

        public int? orderstatus { get; set; }

        public string? description { get; set; }

        public string? vendorid { get; set; }

        public string? taxid { get; set; }

        public double? beforetaxamount { get; set; }

        public double? taxamount { get; set; }

        public double? aftertaxamount { get; set; }
    }
}
