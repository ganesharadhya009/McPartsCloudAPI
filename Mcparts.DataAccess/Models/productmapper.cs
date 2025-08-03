using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class productmapper
{
    public string id { get; set; } = null!;

    public string? productid { get; set; }

    public string? productcategoryid { get; set; }

    public string? productsubcategoryid { get; set; }

    public string? productmetadataid { get; set; }

    public string? productgroupid { get; set; }

    public string? productsubcategorysubsetid { get; set; }

    public string? createdbyid { get; set; }

    public string? updatedbyid { get; set; }

    public DateTime? createdatutc { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? productmetadatavaluesid { get; set; }

    public string? productmetadataname { get; set; }

    public string? productmetadatavaluesname { get; set; }

    public virtual products? product { get; set; }

    public virtual productcategory? productcategory { get; set; }

    public virtual productgroup? productgroup { get; set; }

    public virtual productmetadata? productmetadata { get; set; }

    public virtual productsubcategory? productsubcategory { get; set; }

    public virtual productsubcategorysubset? productsubcategorysubset { get; set; }
}
