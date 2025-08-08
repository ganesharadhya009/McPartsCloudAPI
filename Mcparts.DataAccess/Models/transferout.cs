using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class transferout
{
    public string id { get; set; } = null!;

    public string? number { get; set; }

    public DateTime? transferreleasedate { get; set; }

    public int? status { get; set; }

    public string? description { get; set; }

    public string? warehousefromid { get; set; }

    public string? warehousetoid { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }

    public bool? isdeleted { get; set; }

    public virtual ICollection<transferin> transferin { get; set; } = new List<transferin>();

    public virtual warehouse? warehousefrom { get; set; }

    public virtual warehouse? warehouseto { get; set; }
}
