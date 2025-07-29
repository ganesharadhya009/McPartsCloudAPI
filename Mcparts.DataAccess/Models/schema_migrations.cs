using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

/// <summary>
/// Auth: Manages updates to the auth system.
/// </summary>
public partial class schema_migrations
{
    public string version { get; set; } = null!;
}
