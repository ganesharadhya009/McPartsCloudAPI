using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class itemcategory
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public bool? isdeleted { get; set; }

    public string? iconpathsearch { get; set; }

    public virtual ICollection<itemgrouptype> itemgrouptype { get; set; } = new List<itemgrouptype>();

    public virtual ICollection<items> items { get; set; } = new List<items>();

    public virtual ICollection<itemsubcategory> itemsubcategory { get; set; } = new List<itemsubcategory>();

    public virtual ICollection<itemtype> itemtype { get; set; } = new List<itemtype>();
}
