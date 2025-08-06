using Mcparts.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Mcparts.Business.Dtos
{
    public record deliveryorderdtoGet : deliveryorderdtoBase
    {
        public string id { get; set; }
    }
    public record deliveryorderdto : deliveryorderdtoBase
    {
        [JsonIgnore]
        public string id { get; set; } = Guid.NewGuid().ToString();
    }

    public record deliveryorderdtoBase : EntityDtoBase
    {
        public string? number { get; set; }

        public DateTime? deliverydate { get; set; }

        public int? status { get; set; }

        public string? description { get; set; }

        public string? salesorderid { get; set; }

        public bool isdeleted { get; set; }

        public DateTime? createdatutc { get; set; }

        public string? createdbyid { get; set; }

        public DateTime? updatedatutc { get; set; }

        public string? updatedbyid { get; set; }

        public virtual salesorder? salesorder { get; set; }
    }
}
