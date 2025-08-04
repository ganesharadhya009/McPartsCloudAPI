using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class tokeninfos
{
    public int id { get; set; }

    public string username { get; set; } = null!;

    public string refreshtoken { get; set; } = null!;

    public DateTime expiredat { get; set; }
}
