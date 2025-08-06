using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record vendordtoGet : vendordtoBase
    {
        public string id { get; set; }
    }
    public record vendordto : vendordtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record vendordtoBase : EntityDtoBase
    {
        public string? name { get; set; }

        public string? number { get; set; }

        public string? description { get; set; }

        public string? street { get; set; }

        public string? city { get; set; }

        public string? state { get; set; }

        public string? zipcode { get; set; }

        public string? country { get; set; }

        public string? phonenumber { get; set; }

        public string? faxnumber { get; set; }

        public string? emailaddress { get; set; }

        public string? website { get; set; }

        public string? whatsapp { get; set; }

        public string? linkedin { get; set; }

        public string? facebook { get; set; }

        public string? instagram { get; set; }

        public string? twitterx { get; set; }

        public string? tiktok { get; set; }

        public string? vendorgroupid { get; set; }

        public string? vendorcategoryid { get; set; }
    }
}
