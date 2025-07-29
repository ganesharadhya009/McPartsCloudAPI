using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class purchaseorder
{
    public string id { get; set; } = null!;

    public string? number { get; set; }

    public DateTime? orderdate { get; set; }

    public int? orderstatus { get; set; }

    public string? description { get; set; }

    public string? vendorid { get; set; }

    public string? taxid { get; set; }

    public double? beforetaxamount { get; set; }

    public double? taxamount { get; set; }

    public double? aftertaxamount { get; set; }

    public bool isdeleted { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }

    public virtual ICollection<goodsreceive> goodsreceive { get; set; } = new List<goodsreceive>();

    public virtual tax? tax { get; set; }

    public virtual vendor? vendor { get; set; }
}
