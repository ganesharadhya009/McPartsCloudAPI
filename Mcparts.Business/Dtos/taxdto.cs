using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record taxdtoGet : taxdtoBase
    {
        public string id { get; set; }
    }
    public record taxdto : taxdtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record taxdtoBase : EntityDtoBase
    {
        public string? name { get; set; }

        public double? percentage { get; set; }

        public string? description { get; set; }
    }
}
