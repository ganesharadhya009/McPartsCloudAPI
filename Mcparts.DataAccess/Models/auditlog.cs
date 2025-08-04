using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class auditlog
{
    public string id { get; set; } = null!;

    public string? tablename { get; set; }

    public string? action { get; set; }

    public string? changes { get; set; }

    public string? userid { get; set; }

    public DateTime? createdbyutc { get; set; }
}
