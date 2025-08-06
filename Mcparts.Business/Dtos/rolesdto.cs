using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record rolesdtoGet : rolesdtoBase
    {
        public string id { get; set; }
    }
    public record rolesdto : rolesdtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record rolesdtoBase : EntityDtoBase
    {
        public string? name { get; set; }

        public string? description { get; set; }
    }
}
