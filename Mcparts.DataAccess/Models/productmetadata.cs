using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class productmetadata
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

    public string? controltype { get; set; }

    public bool? issearchable { get; set; }

    public bool? ismultiselect { get; set; }

    public bool? isiconsupported { get; set; }

    public string? productcategoryid { get; set; }

    public string? productsubcategoryidsubsetid { get; set; }

    public virtual productcategory? productcategory { get; set; }

    public virtual ICollection<productmapper> productmapper { get; set; } = new List<productmapper>();

    public virtual ICollection<productmetadatavalues> productmetadatavalues { get; set; } = new List<productmetadatavalues>();

    public virtual productsubcategory? productsubcategory { get; set; }

    public virtual productsubcategorysubset? productsubcategoryidsubset { get; set; }
}
