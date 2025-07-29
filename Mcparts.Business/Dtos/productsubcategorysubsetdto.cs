using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record productsubcategorysubsetdtoGet : productsubcategorysubsetdtoBase
    {
        public string id { get; set; }
    }

    public record productsubcategorysubsetdto : productsubcategorysubsetdtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record productsubcategorysubsetdtoBase : EntityDtoBase
    {

        public string? name { get; set; }

        public string? description { get; set; }

       

        public string? productsubcategoryid { get; set; }

        public string? iconpath { get; set; }
    }
}
