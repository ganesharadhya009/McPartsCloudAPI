using System;
using System.Collections;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class warehouse
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public BitArray? systemwarehouse { get; set; }

    public bool? isdeleted { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }

    public virtual ICollection<inventorytransaction> inventorytransactionwarehouse { get; set; } = new List<inventorytransaction>();

    public virtual ICollection<inventorytransaction> inventorytransactionwarehousefrom { get; set; } = new List<inventorytransaction>();

    public virtual ICollection<inventorytransaction> inventorytransactionwarehouseto { get; set; } = new List<inventorytransaction>();

    public virtual ICollection<scrapping> scrapping { get; set; } = new List<scrapping>();

    public virtual ICollection<stockcount> stockcount { get; set; } = new List<stockcount>();

    public virtual ICollection<transferout> transferoutwarehousefrom { get; set; } = new List<transferout>();

    public virtual ICollection<transferout> transferoutwarehouseto { get; set; } = new List<transferout>();
}
