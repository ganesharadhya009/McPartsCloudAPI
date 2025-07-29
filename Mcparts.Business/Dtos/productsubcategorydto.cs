using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record productsubcategorydtoGet : productsubcategorydtoBase
    {
        public string id { get; set; }
    }

    public record productsubcategorydto : productsubcategorydtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record productsubcategorydtoBase : EntityDtoBase
    {

        public string? name { get; set; }

        public string? description { get; set; }

        public string? productcategoryid { get; set; }

        public string? iconpath { get; set; }
    }
}
