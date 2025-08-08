using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class inventorytransaction
{
    public string id { get; set; } = null!;

    public string? moduleid { get; set; }

    public string? modulename { get; set; }

    public string? modulecode { get; set; }

    public string? modulenumber { get; set; }

    public DateTime? movementdate { get; set; }

    public int? status { get; set; }

    public string? number { get; set; }

    public string? warehouseid { get; set; }

    public string? productid { get; set; }

    public double? movement { get; set; }

    public int? transtype { get; set; }

    public double? stock { get; set; }

    public string? warehousefromid { get; set; }

    public string? warehousetoid { get; set; }

    public double? qtyscsys { get; set; }

    public double? qtysccount { get; set; }

    public double? qtyscdelta { get; set; }

    public bool? isdeleted { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }

    public virtual products? product { get; set; }

    public virtual warehouse? warehouse { get; set; }

    public virtual warehouse? warehousefrom { get; set; }

    public virtual warehouse? warehouseto { get; set; }
}
