﻿using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class one_time_tokens
{
    public Guid id { get; set; }

    public Guid user_id { get; set; }

    public string token_hash { get; set; } = null!;

    public string relates_to { get; set; } = null!;

    public DateTime created_at { get; set; }

    public DateTime updated_at { get; set; }

    public virtual users user { get; set; } = null!;
}
