using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class s3_multipart_uploads
{
    public string id { get; set; } = null!;

    public long in_progress_size { get; set; }

    public string upload_signature { get; set; } = null!;

    public string bucket_id { get; set; } = null!;

    public string key { get; set; } = null!;

    public string version { get; set; } = null!;

    public string? owner_id { get; set; }

    public DateTime created_at { get; set; }

    public string? user_metadata { get; set; }

    public virtual buckets bucket { get; set; } = null!;

    public virtual ICollection<s3_multipart_uploads_parts> s3_multipart_uploads_parts { get; set; } = new List<s3_multipart_uploads_parts>();
}
