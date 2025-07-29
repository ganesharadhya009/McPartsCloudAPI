using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

/// <summary>
/// Auth: Store of tokens used to refresh JWT tokens once they expire.
/// </summary>
public partial class refresh_tokens
{
    public Guid? instance_id { get; set; }

    public long id { get; set; }

    public string? token { get; set; }

    public string? user_id { get; set; }

    public bool? revoked { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public string? parent { get; set; }

    public Guid? session_id { get; set; }

    public virtual sessions? session { get; set; }
}
