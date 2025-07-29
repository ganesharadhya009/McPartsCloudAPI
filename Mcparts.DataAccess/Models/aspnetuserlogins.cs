using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class aspnetuserlogins
{
    public string loginprovider { get; set; } = null!;

    public string providerkey { get; set; } = null!;

    public string? providerdisplayname { get; set; }

    public string userid { get; set; } = null!;

    public virtual aspnetusers user { get; set; } = null!;
}
