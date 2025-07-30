using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class productmetadatavalues
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? updatedbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public bool? isdeleted { get; set; }

    public string? productmetdataid { get; set; }

    public string? iconpath { get; set; }

    public string? partnumbercode { get; set; }

    public virtual productmetadata? productmetdata { get; set; }
}
