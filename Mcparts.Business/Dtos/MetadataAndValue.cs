using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record MetadataAndValue
    {
        public string? MetadataId { get; set; }
        public string? MetadataIdValue { get; set; }
    }
}
