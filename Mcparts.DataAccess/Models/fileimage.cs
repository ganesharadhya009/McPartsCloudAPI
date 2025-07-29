using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class fileimage
{
    public string id { get; set; } = null!;

    public string? name { get; set; }

    public string? description { get; set; }

    public string? originalname { get; set; }

    public string? generatedname { get; set; }

    public string? extension { get; set; }

    public long? filesize { get; set; }

    public bool isdeleted { get; set; }

    public DateTime? createdatutc { get; set; }

    public string? createdbyid { get; set; }

    public DateTime? updatedatutc { get; set; }

    public string? updatedbyid { get; set; }
}
