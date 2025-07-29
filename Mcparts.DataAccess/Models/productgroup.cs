using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class productgroup
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public bool? isdeleted { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }

    public virtual ICollection<productcategory> productcategory { get; set; } = new List<productcategory>();

    public virtual ICollection<productmapper> productmapper { get; set; } = new List<productmapper>();
}
