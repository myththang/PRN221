using System;
using System.Collections.Generic;

namespace PRN221_Project.Models;

public partial class ProductComparison
{
    public int ComparisonId { get; set; }

    public int? UserId { get; set; }

    public int? ProductId { get; set; }

    public string? Description { get; set; }

    public virtual FinancialProduct? Product { get; set; }

    public virtual User? User { get; set; }
}
