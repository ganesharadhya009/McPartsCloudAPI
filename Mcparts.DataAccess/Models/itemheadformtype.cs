using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class itemheadformtype
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public string? iconpathsearch { get; set; }

    public bool? isdeleted { get; set; }

    public virtual ICollection<items> items { get; set; } = new List<items>();
}
