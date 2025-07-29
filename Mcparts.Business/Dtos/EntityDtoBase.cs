using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record EntityDtoBase
    {
        [JsonIgnore]
        public bool? isdeleted { get; set; }
        [JsonIgnore]
        public DateTime? createdatutc { get; set; }
        [JsonIgnore]
        public string? createdbyid { get; set; }
        [JsonIgnore]
        public DateTime? updatedatutc { get; set; }
        [JsonIgnore]
        public string? updatedbyid { get; set; }
    }
}
