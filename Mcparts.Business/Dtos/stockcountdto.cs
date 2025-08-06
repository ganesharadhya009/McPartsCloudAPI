using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record stockcountdtoGet : stockcountdtoBase
    {
        public string id { get; set; }
    }
    public record stockcountdto : stockcountdtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record class stockcountdtoBase : EntityDtoBase
    {
        public string? number { get; set; }

        public DateTime? countdate { get; set; }

        public int? status { get; set; }

        public string? description { get; set; }

        public string? warehouseid { get; set; }
    }
}
