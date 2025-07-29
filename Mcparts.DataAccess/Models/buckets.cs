﻿using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class buckets
{
    public string id { get; set; } = null!;

    public string name { get; set; } = null!;

    /// <summary>
    /// Field is deprecated, use owner_id instead
    /// </summary>
    public Guid? owner { get; set; }

    public DateTime? created_at { get; set; }

    public DateTime? updated_at { get; set; }

    public bool? _public { get; set; }

    public bool? avif_autodetection { get; set; }

    public long? file_size_limit { get; set; }

    public List<string>? allowed_mime_types { get; set; }

    public string? owner_id { get; set; }

    public virtual ICollection<objects> objects { get; set; } = new List<objects>();

    public virtual ICollection<s3_multipart_uploads> s3_multipart_uploads { get; set; } = new List<s3_multipart_uploads>();

    public virtual ICollection<s3_multipart_uploads_parts> s3_multipart_uploads_parts { get; set; } = new List<s3_multipart_uploads_parts>();
}
