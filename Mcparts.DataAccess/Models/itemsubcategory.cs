using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class itemsubcategory
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public string? itemcaregoryid { get; set; }

    public string? iconpathsearch { get; set; }

    public bool? isdeleted { get; set; }

    public virtual itemcategory? itemcaregory { get; set; }

    public virtual ICollection<itemgrouptype> itemgrouptype { get; set; } = new List<itemgrouptype>();

    public virtual ICollection<items> items { get; set; } = new List<items>();

    public virtual ICollection<itemtype> itemtype { get; set; } = new List<itemtype>();
}
