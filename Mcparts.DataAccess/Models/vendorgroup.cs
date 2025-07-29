using System;
using System.Collections;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class vendorgroup
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public BitArray isdeleted { get; set; } = null!;

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }

    public virtual ICollection<vendor> vendor { get; set; } = new List<vendor>();
}
