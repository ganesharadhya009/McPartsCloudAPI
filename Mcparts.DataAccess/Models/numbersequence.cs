using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class numbersequence
{
    public string id { get; set; } = null!;

    public string? entityname { get; set; }

    public string? prefix { get; set; }

    public string? suffix { get; set; }

    public int? lastusedcount { get; set; }

    public bool isdeleted { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }
}
