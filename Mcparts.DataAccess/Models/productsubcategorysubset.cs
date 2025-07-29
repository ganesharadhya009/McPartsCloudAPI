using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class productsubcategorysubset
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? updatedbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public bool? isdeleted { get; set; }

    public string? productsubcategoryid { get; set; }

    public string? iconpath { get; set; }

    public virtual ICollection<productmapper> productmapper { get; set; } = new List<productmapper>();

    public virtual ICollection<productmetadata> productmetadata { get; set; } = new List<productmetadata>();

    public virtual productsubcategory? productsubcategory { get; set; }
}
