using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class itemmetadata
{
    public string id { get; set; } = null!;

    public string? type { get; set; }

    public string? value { get; set; }

    public string? itemid { get; set; }

    public virtual items? item { get; set; }
}
