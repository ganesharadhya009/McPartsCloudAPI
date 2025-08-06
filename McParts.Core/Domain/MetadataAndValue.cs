using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McParts.Core.Domain
{
    public record MetadataAndValue
    {
        public string? MetadataId { get; set; }
        public string? MetadataIdName { get; set; }
        public string? MetadataValueId { get; set; }
        public string? MetadataValueName { get; set; }
    }
}
