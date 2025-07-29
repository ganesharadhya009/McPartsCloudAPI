using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class tax
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public double? percentage { get; set; }

    public string? description { get; set; }

    public bool isdeleted { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }

    public virtual ICollection<purchaseorder> purchaseorder { get; set; } = new List<purchaseorder>();

    public virtual ICollection<salesorder> salesorder { get; set; } = new List<salesorder>();
}
