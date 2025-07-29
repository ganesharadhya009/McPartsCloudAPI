using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class vendor
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? number { get; set; }

    public string? description { get; set; }

    public string? street { get; set; }

    public string? city { get; set; }

    public string? state { get; set; }

    public string? zipcode { get; set; }

    public string? country { get; set; }

    public string? phonenumber { get; set; }

    public string? faxnumber { get; set; }

    public string? emailaddress { get; set; }

    public string? website { get; set; }

    public string? whatsapp { get; set; }

    public string? linkedin { get; set; }

    public string? facebook { get; set; }

    public string? instagram { get; set; }

    public string? twitterx { get; set; }

    public string? tiktok { get; set; }

    public string? vendorgroupid { get; set; }

    public string? vendorcategoryid { get; set; }

    public bool isdeleted { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }

    public virtual ICollection<purchaseorder> purchaseorder { get; set; } = new List<purchaseorder>();

    public virtual vendorcategory? vendorcategory { get; set; }

    public virtual ICollection<vendorcontact> vendorcontact { get; set; } = new List<vendorcontact>();

    public virtual vendorgroup? vendorgroup { get; set; }
}
