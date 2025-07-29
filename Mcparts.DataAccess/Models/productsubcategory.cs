using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class productsubcategory
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? updatedbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public bool? isdeleted { get; set; }

    public string? productcategoryid { get; set; }

    public string? iconpath { get; set; }

    public virtual productcategory? productcategory { get; set; }

    public virtual ICollection<productmapper> productmapper { get; set; } = new List<productmapper>();

    public virtual ICollection<productmetadata> productmetadata { get; set; } = new List<productmetadata>();

    public virtual ICollection<productsubcategorysubset> productsubcategorysubset { get; set; } = new List<productsubcategorysubset>();
}
