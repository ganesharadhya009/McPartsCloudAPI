using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class itemtype
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public string? itemcategoryid { get; set; }

    public string? itemsubcategoryid { get; set; }

    public string? itemgrouptypeid { get; set; }

    public string? itemgroupsubtypeid { get; set; }

    public string? iconpathsearch { get; set; }

    public bool? isdeleted { get; set; }

    public virtual itemcategory? itemcategory { get; set; }

    public virtual itemsubgrouptype? itemgroupsubtype { get; set; }

    public virtual itemgrouptype? itemgrouptype { get; set; }

    public virtual ICollection<items> items { get; set; } = new List<items>();

    public virtual itemsubcategory? itemsubcategory { get; set; }
}
