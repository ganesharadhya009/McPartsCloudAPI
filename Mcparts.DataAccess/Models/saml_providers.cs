using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

/// <summary>
/// Auth: Manages SAML Identity Provider connections.
/// </summary>
public partial class saml_providers
{
    public Guid id { get; set; }

    public Guid sso_provider_id { get; set; }

    public string entity_id { get; set; } = null!;

    public string metadata_xml { get; set; } = null!;

    public string? metadata_url { get; set; }

    public string? attribute_mapping { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public string? name_id_format { get; set; }

    public virtual sso_providers sso_provider { get; set; } = null!;
}
