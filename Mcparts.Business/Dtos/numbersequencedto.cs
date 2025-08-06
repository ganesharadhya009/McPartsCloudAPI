using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record numbersequencedtoGet : numbersequencedtoBase
    {
        public string id { get; set; }
    }
    public record numbersequencedto : numbersequencedtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record numbersequencedtoBase : EntityDtoBase
    {
        public string? entityname { get; set; }

        public string? prefix { get; set; }

        public string? suffix { get; set; }

        public int? lastusedcount { get; set; }
    }
}
