using Mcparts.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record productcategorydtoGet : productcategorydtoBase
    {
        public string id { get; set; }
    }
    public record productcategorydto : productcategorydtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record productcategorydtoBase : EntityDtoBase
    {

        public string? name { get; set; }

        public string? description { get; set; }

       

        public string? productgroupid { get; set; }

        public string? iconpath { get; set; }
       
    }
}

