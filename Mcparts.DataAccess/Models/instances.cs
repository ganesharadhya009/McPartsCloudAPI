using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

/// <summary>
/// Auth: Manages users across multiple sites.
/// </summary>
public partial class instances
{
    public Guid id { get; set; }

    public Guid? uuid { get; set; }

    public string? raw_base_config { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }
}
