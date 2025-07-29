using System;
using System.Collections.Generic;

namespace Mcparts.DataAccess.Models;

public partial class gainers
{
    public string symbol { get; set; } = null!;

    public string? series { get; set; }

    public float? open_price { get; set; }

    public float? high_price { get; set; }

    public float? low_price { get; set; }

    public float? ltp { get; set; }

    public float? prev_price { get; set; }

    public float? net_price { get; set; }

    public long? trade_quantity { get; set; }

    public float? turnover { get; set; }

    public string? market_type { get; set; }

    public string? ca_ex_dt { get; set; }

    public string? ca_purpose { get; set; }

    public float? perchange { get; set; }

    public DateTime? srctimestamp { get; set; }

    public DateTime? apitimestamp { get; set; }

    public string? legend { get; set; }
}
