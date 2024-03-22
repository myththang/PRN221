using System;
using System.Collections.Generic;

namespace PRN221_Project.Models;

public partial class FinancialProduct
{
    public int ProductId { get; set; }

    public string? ProductName { get; set; }

    public string? Type { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<ProductComparison> ProductComparisons { get; } = new List<ProductComparison>();
}
