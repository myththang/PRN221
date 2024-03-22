using System;
using System.Collections.Generic;

namespace PRN221_Project.Models;

public partial class Currency
{
    public int CurrencyId { get; set; }

    public string? CurrencyCode { get; set; }

    public string? CurrencyName { get; set; }

    public virtual ICollection<ExchangeRate> ExchangeRateFromCurrencies { get; } = new List<ExchangeRate>();

    public virtual ICollection<ExchangeRate> ExchangeRateToCurrencies { get; } = new List<ExchangeRate>();
}
