using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class company
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public string? currency { get; set; }

    public string? street { get; set; }

    public string? city { get; set; }

    public string? state { get; set; }

    public string? zipcode { get; set; }

    public string? country { get; set; }

    public string? phonenumber { get; set; }

    public string? faxnumber { get; set; }

    public string? emailaddress { get; set; }

    public string? website { get; set; }

    public bool isdeleted { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }
}
