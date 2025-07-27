using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.DataAccess.Dtos
{
    public record ItemCategoryBase
    {
        public string name { get; set; }

        public string description { get; set; }
    }

    public record ItemCategoryDto: ItemCategoryBase
    {
        public string id { get; set; }
    }

    public record ItemCategoryDtoPost : ItemCategoryBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }
}
