using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class aspnetroleclaims
{
    public string id { get; set; } = null!;

    public string? roleid { get; set; }

    public string? claimtype { get; set; }

    public string? claimvalue { get; set; }

    public virtual aspnetroles? role { get; set; }
}
