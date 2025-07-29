using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class deliveryorder
{
    public string id { get; set; } = null!;

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

    public virtual ICollection<salesreturn> salesreturn { get; set; } = new List<salesreturn>();
}
