using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record transferoutdtoGet : transferoutdtoBase
    {
        public string id { get; set; }
    }
    public record transferoutdto : transferoutdtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record transferoutdtoBase : EntityDtoBase
    {
        public string? number { get; set; }

        public DateTime? transferreleasedate { get; set; }

        public int? status { get; set; }

        public string? description { get; set; }

        public string? warehousefromid { get; set; }

        public string? warehousetoid { get; set; }
    }
}
