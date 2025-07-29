using Mcparts.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record productgroupdtoGet : productgroupdtoBase
    {
        public string id { get; set; }
    }
    public record productgroupdto : productgroupdtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record productgroupdtoBase : EntityDtoBase
    {
        public string? name { get; set; }

        public string? description { get; set; }

      
    }
}

