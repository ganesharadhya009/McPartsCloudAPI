using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

/// <summary>
/// Auth: Manages SSO identity provider information; see saml_providers for SAML.
/// </summary>
public partial class sso_providers
{
    public Guid id { get; set; }

    /// <summary>
    /// Auth: Uniquely identifies a SSO provider according to a user-chosen resource ID (case insensitive), useful in infrastructure as code.
    /// </summary>
    public string? resource_id { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public virtual ICollection<saml_providers> saml_providers { get; set; } = new List<saml_providers>();

    public virtual ICollection<saml_relay_states> saml_relay_states { get; set; } = new List<saml_relay_states>();

    public virtual ICollection<sso_domains> sso_domains { get; set; } = new List<sso_domains>();
}
