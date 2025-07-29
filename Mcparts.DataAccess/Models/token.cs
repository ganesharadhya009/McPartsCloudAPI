using System;
using System.Collections;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class token
{
    public string id { get; set; } = null!;

    public string? userid { get; set; }

    public string? refreshtoken { get; set; }

    public DateTime expirydate { get; set; }

    public BitArray isdeleted { get; set; } = null!;

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }
}
