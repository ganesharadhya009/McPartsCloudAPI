using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class products
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? partnumber { get; set; }

    public string? description { get; set; }

    public double? unitprice { get; set; }

    public bool? physical { get; set; }

    public string? unitmeasureid { get; set; }

    public bool isdeleted { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }

    public string? additionaldescription { get; set; }

    public string? note { get; set; }

    public int? lotsize { get; set; }

    public string? productcategoryid { get; set; }

    public string? productsubcategoryid { get; set; }

    public string? productsubcategroysubsetid { get; set; }

    public virtual ICollection<inventorytransaction> inventorytransaction { get; set; } = new List<inventorytransaction>();

    public virtual ICollection<productmapper> productmapper { get; set; } = new List<productmapper>();

    public virtual ICollection<purchaseorderitem> purchaseorderitem { get; set; } = new List<purchaseorderitem>();

    public virtual ICollection<salesorderitem> salesorderitem { get; set; } = new List<salesorderitem>();

    public virtual unitmeasure? unitmeasure { get; set; }
}
