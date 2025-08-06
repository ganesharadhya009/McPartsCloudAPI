using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record warehousedtoGet : warehousedtoBase
    {
        public string id { get; set; }
    }
    public record warehousedto : warehousedtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record warehousedtoBase : EntityDtoBase
    {
        public string? name { get; set; }

        public string? description { get; set; }

        public BitArray? systemwarehouse { get; set; }
    }
}
