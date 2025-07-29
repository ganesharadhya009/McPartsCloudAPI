using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class getproductcategorydataallwithcount
{
    public long? count { get; set; }

    public string? productcategoryid { get; set; }

    public string? name { get; set; }

    public string? description { get; set; }

    public string? iconpath { get; set; }
}
