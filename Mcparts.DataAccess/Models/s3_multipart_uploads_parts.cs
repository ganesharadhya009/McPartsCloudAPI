using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class s3_multipart_uploads_parts
{
    public Guid id { get; set; }

    public string upload_id { get; set; } = null!;

    public long size { get; set; }

    public int part_number { get; set; }

    public string bucket_id { get; set; } = null!;

    public string key { get; set; } = null!;

    public string etag { get; set; } = null!;

    public string? owner_id { get; set; }

    public string version { get; set; } = null!;

    public DateTime created_at { get; set; }

    public virtual buckets bucket { get; set; } = null!;

    public virtual s3_multipart_uploads upload { get; set; } = null!;
}
