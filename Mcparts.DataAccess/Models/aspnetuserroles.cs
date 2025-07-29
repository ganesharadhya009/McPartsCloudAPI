using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class aspnetuserroles
{
    public string id { get; set; } = null!;

    public string? userid { get; set; }

    public string? roleid { get; set; }

    public virtual aspnetroles? role { get; set; }

    public virtual aspnetusers? user { get; set; }
}
