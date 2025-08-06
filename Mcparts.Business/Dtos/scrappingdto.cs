using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record scrappingdtoGet : scrappingdtoBase
    {
        public string id { get; set; }
    }
    public record scrappingdto : scrappingdtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();

    }
    public record scrappingdtoBase : EntityDtoBase
    {
        public string? number { get; set; }

        public DateTime? scrappingdate { get; set; }

        public int? status { get; set; }

        public string? description { get; set; }

        public string? warehouseid { get; set; }
    }
}
