using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class userstatus
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public bool isdeleted { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }

    public virtual ICollection<users> users { get; set; } = new List<users>();
}
