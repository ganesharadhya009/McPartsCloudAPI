using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class aspnetuserclaims
{
    public string id { get; set; } = null!;

    public string userid { get; set; } = null!;

    public string? claimtype { get; set; }

    public string? claimvalue { get; set; }

    public virtual aspnetusers user { get; set; } = null!;
}
