using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class users
{
    public string id { get; set; } = null!;

    public string? usertype { get; set; }

    public string? firstname { get; set; }

    public string? lastname { get; set; }

    public string? primarycontactnumber { get; set; }

    public string? secondarycontactnumber { get; set; }

    public string? address1 { get; set; }

    public string? address2 { get; set; }

    public string? street { get; set; }

    public string? district { get; set; }

    public string? pincode { get; set; }

    public string? email { get; set; }

    public string? userstatusid { get; set; }

    public string? password { get; set; }

    public string? propertyid { get; set; }

    public string? gender { get; set; }

    public byte[]? idproof { get; set; }

    public byte[]? photo { get; set; }

    public string? area { get; set; }

    public string? idproofname { get; set; }

    public string? photoname { get; set; }

    public string? referredby { get; set; }

    public string? temporarypassword { get; set; }

    public DateTime? registereddate { get; set; }

    public bool isdeleted { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }

    public virtual userstatus? userstatus { get; set; }

    public virtual usertype? usertypeNavigation { get; set; }
}
