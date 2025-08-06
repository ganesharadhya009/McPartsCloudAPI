using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record customercategorydtoGet : customercategorydtoBase
    {
        public string id { get; set; }
    }
    public record customercategorydto : customercategorydtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record customercategorydtoBase : EntityDtoBase
    {
        public string? name { get; set; }

        public string? description { get; set; }
    }
}
