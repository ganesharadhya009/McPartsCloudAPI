using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class migrations
{
    public int id { get; set; }

    public string name { get; set; } = null!;

    public string hash { get; set; } = null!;

    public DateTime? executed_at { get; set; }
}
