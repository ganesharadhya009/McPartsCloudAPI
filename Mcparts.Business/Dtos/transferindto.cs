using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record transferindtoGet : transferindtoBase
    {
        public string id { get; set; }
    }
    public record transferindto : transferindtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record transferindtoBase : EntityDtoBase
    {
        public string? number { get; set; }

        public DateTime? transferreceivedate { get; set; }

        public int? status { get; set; }

        public string? description { get; set; }

        public string? transferoutid { get; set; }
    }
}
