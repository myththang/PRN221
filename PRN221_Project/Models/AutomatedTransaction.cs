﻿using System;
using System.Collections.Generic;

namespace PRN221_Project.Models;

public partial class AutomatedTransaction
{
    public int TransactionId { get; set; }

    public int? UserId { get; set; }

    public DateTime? TransactionDate { get; set; }

    public decimal? Amount { get; set; }

    public string? Type { get; set; }

    public string? Description { get; set; }

    public virtual User? User { get; set; }
}
