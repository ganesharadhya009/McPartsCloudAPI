using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

/// <summary>
/// auth: stores metadata about factors
/// </summary>
public partial class mfa_factors
{
    public Guid id { get; set; }

    public Guid user_id { get; set; }

    public string? friendly_name { get; set; }

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public string? secret { get; set; }

    public string? phone { get; set; }

    public DateTime? last_challenged_at { get; set; }

    public string? web_authn_credential { get; set; }

    public Guid? web_authn_aaguid { get; set; }

    public virtual ICollection<mfa_challenges> mfa_challenges { get; set; } = new List<mfa_challenges>();

    public virtual users user { get; set; } = null!;
}
