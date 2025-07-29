using System;
using System.Collections.Generic;
using System.Net;

namespace Mcparts.DataAccess.Models;

/// <summary>
/// Auth: Stores session data associated to a user.
/// </summary>
public partial class sessions
{
    public Guid id { get; set; }

    public Guid user_id { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public Guid? factor_id { get; set; }

    /// <summary>
    /// Auth: Not after is a nullable column that contains a timestamp after which the session should be regarded as expired.
    /// </summary>
    public DateTime? not_after { get; set; }

    public DateTime? refreshed_at { get; set; }

    public string? user_agent { get; set; }

    public IPAddress? ip { get; set; }

    public string? tag { get; set; }

    public virtual ICollection<mfa_amr_claims> mfa_amr_claims { get; set; } = new List<mfa_amr_claims>();

    public virtual ICollection<refresh_tokens> refresh_tokens { get; set; } = new List<refresh_tokens>();

    public virtual users user { get; set; } = null!;
}
