using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record companydtoGet : companydtoBase
    {
        public string id { get; set; }
    }
    public record companydto : companydtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record companydtoBase : EntityDtoBase
    {
        public string? name { get; set; }

        public string? description { get; set; }

        public string? currency { get; set; }

        public string? street { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? zipcode { get; set; }

        public string? country { get; set; }

        public string? phonenumber { get; set; }

        public string? faxnumber { get; set; }

        public string? emailaddress { get; set; }

        public string? website { get; set; }
    }
}
