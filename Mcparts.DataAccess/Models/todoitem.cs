using System;
using System.Collections;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class todoitem
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public string? todoid { get; set; }

    public BitArray isdeleted { get; set; } = null!;

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }

    public virtual todo? todo { get; set; }
}
