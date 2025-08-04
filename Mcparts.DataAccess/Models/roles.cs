using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class roles
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public bool isdeleted { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }
}
