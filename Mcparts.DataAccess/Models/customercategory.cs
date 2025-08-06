using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class customercategory
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }

    public bool? isdeleted { get; set; }

    public virtual ICollection<customer> customer { get; set; } = new List<customer>();
}
