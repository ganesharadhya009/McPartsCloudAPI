using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class aspnetroles
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? normalizedname { get; set; }

    public string? concurrencystamp { get; set; }

    public virtual ICollection<aspnetroleclaims> aspnetroleclaims { get; set; } = new List<aspnetroleclaims>();

    public virtual ICollection<aspnetuserroles> aspnetuserroles { get; set; } = new List<aspnetuserroles>();
}
