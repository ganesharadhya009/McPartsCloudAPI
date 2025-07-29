using System;
using System.Collections;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class aspnetusers
{
    public string id { get; set; } = null!;

    public string? firstname { get; set; }

    public string? lastname { get; set; }

    public string? companyname { get; set; }

    public string? profilepicturename { get; set; }

    public bool? isblocked { get; set; }

    public bool? isdeleted { get; set; }

    public DateTime? createdat { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedat { get; set; }

    public string? updatedbyid { get; set; }

    public string? username { get; set; }

    public string? normalizedusername { get; set; }

    public string? email { get; set; }

    public string? normalizedemail { get; set; }

    public BitArray emailconfirmed { get; set; } = null!;

    public string? passwordhash { get; set; }

    public string? securitystamp { get; set; }

    public string? concurrencystamp { get; set; }

    public string? phonenumber { get; set; }

    public bool phonenumberconfirmed { get; set; }

    public bool twofactorenabled { get; set; }

    public DateTime? lockoutend { get; set; }

    public bool lockoutenabled { get; set; }

    public int accessfailedcount { get; set; }

    public virtual ICollection<aspnetuserclaims> aspnetuserclaims { get; set; } = new List<aspnetuserclaims>();

    public virtual ICollection<aspnetuserlogins> aspnetuserlogins { get; set; } = new List<aspnetuserlogins>();

    public virtual ICollection<aspnetuserroles> aspnetuserroles { get; set; } = new List<aspnetuserroles>();
}
