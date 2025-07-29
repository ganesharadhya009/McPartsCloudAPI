using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class scrapping
{
    public string id { get; set; } = null!;

    public string? number { get; set; }

    public DateTime? scrappingdate { get; set; }

    public int? status { get; set; }

    public string? description { get; set; }

    public string? warehouseid { get; set; }

    public bool isdeleted { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }

    public virtual warehouse? warehouse { get; set; }
}
