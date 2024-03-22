using System;
using System.Collections.Generic;

namespace PRN221_Project.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;
    public decimal Balance { get; set; }

    public virtual ICollection<AutomatedTransaction> AutomatedTransactions { get; } = new List<AutomatedTransaction>();

    public virtual ICollection<Budget> Budgets { get; } = new List<Budget>();

    public virtual ICollection<DebtsLoan> DebtsLoans { get; } = new List<DebtsLoan>();

    public virtual ICollection<Expense> Expenses { get; } = new List<Expense>();

    public virtual ICollection<Income> Incomes { get; } = new List<Income>();

    public virtual ICollection<Investment> Investments { get; } = new List<Investment>();

    public virtual ICollection<PaymentReminder> PaymentReminders { get; } = new List<PaymentReminder>();

    public virtual ICollection<ProductComparison> ProductComparisons { get; } = new List<ProductComparison>();

    public virtual ICollection<Security> Securities { get; } = new List<Security>();

    public virtual ICollection<TransactionLog> TransactionLogs { get; } = new List<TransactionLog>();
}
