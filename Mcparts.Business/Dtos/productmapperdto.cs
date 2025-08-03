using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record productmapperdtoGet : productmapperdtoBase
    {
        public string id { get; set; }
    }
    public record productmapperdto : productmapperdtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record productmapperdtoBase: EntityDtoBase
    {

        public string? productid { get; set; }

        public string? productcategoryid { get; set; }

        public string? productsubcategoryid { get; set; }

        public string? productmetadataid { get; set; }

        public string? productgroupid { get; set; }

        public string? productsubcategorysubsetid { get; set; }

        public string? productmetadatavaluesid { get; set; }

        public string? productmetadataname { get; set; }

        public string? productmetadatavaluesname { get; set; }
    }
}
