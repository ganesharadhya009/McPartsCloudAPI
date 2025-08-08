using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class userrolemapper
{
    public string id { get; set; } = null!;

    public string? userid { get; set; }

    public string? roleid { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }

    public bool? isdeleted { get; set; }
}
