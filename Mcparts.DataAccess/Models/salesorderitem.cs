using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class salesorderitem
{
    public string id { get; set; } = null!;

    public string? salesorderid { get; set; }

    public string? productid { get; set; }

    public string? summary { get; set; }

    public double? unitprice { get; set; }

    public double? quantity { get; set; }

    public double? total { get; set; }

    public bool? isdeleted { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }

    public virtual products? product { get; set; }

    public virtual salesorder? salesorder { get; set; }
}
