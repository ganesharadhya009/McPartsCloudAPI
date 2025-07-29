using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class aspnetusertokens
{
    public string userid { get; set; } = null!;

    public string loginprovider { get; set; } = null!;

    public string name { get; set; } = null!;

    public string? value { get; set; }

    public virtual aspnetusers user { get; set; } = null!;
}
