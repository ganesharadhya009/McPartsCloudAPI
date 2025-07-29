using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

/// <summary>
/// auth: stores authenticator method reference claims for multi factor authentication
/// </summary>
public partial class mfa_amr_claims
{
    public Guid session_id { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public string authentication_method { get; set; } = null!;

    public Guid id { get; set; }

    public virtual sessions session { get; set; } = null!;
}
