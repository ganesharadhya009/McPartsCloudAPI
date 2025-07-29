using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class itemsubgrouptype
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public string? itemgrouptypeid { get; set; }

    public string? iconpathsearch { get; set; }

    public string? isdeleted { get; set; }

    public virtual itemgrouptype? itemgrouptype { get; set; }

    public virtual ICollection<items> items { get; set; } = new List<items>();

    public virtual ICollection<itemtype> itemtype { get; set; } = new List<itemtype>();
}
