using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PRN221_Project.Models;

public partial class Prn221ProjectContext : DbContext
{
    public Prn221ProjectContext()
    {
    }

    public Prn221ProjectContext(DbContextOptions<Prn221ProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AutomatedTransaction> AutomatedTransactions { get; set; }

    public virtual DbSet<Budget> Budgets { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<DebtsLoan> DebtsLoans { get; set; }

    public virtual DbSet<ExchangeRate> ExchangeRates { get; set; }

    public virtual DbSet<Expense> Expenses { get; set; }

    public virtual DbSet<FinancialProduct> FinancialProducts { get; set; }

    public virtual DbSet<Income> Incomes { get; set; }

    public virtual DbSet<Investment> Investments { get; set; }

    public virtual DbSet<PaymentReminder> PaymentReminders { get; set; }

    public virtual DbSet<ProductComparison> ProductComparisons { get; set; }

    public virtual DbSet<Security> Securities { get; set; }

    public virtual DbSet<TransactionLog> TransactionLogs { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=LIBUR\\SQLEXPRESS;database=PRN221_Project;uid=sa;pwd=123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AutomatedTransaction>(entity =>
        {
            entity.HasKey(e => e.TransactionId).HasName("PK__Automate__55433A4BAE53DCA2");

            entity.Property(e => e.TransactionId).HasColumnName("TransactionID");
            entity.Property(e => e.Amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.TransactionDate).HasColumnType("date");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.AutomatedTransactions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Automated__UserI__5EBF139D");
        });

        modelBuilder.Entity<Budget>(entity =>
        {
            entity.HasKey(e => e.BudgetId).HasName("PK__Budgets__E38E79C463A901CF");

            entity.Property(e => e.BudgetId).HasColumnName("BudgetID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Month).HasColumnType("date");
            entity.Property(e => e.TotalBudget).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Budgets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Budgets__UserID__5441852A");
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.HasKey(e => e.CurrencyId).HasName("PK__Currenci__14470B100BCF80F5");

            entity.Property(e => e.CurrencyId).HasColumnName("CurrencyID");
            entity.Property(e => e.CurrencyCode)
                .HasMaxLength(5)
                .IsUnicode(false);
            entity.Property(e => e.CurrencyName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DebtsLoan>(entity =>
        {
            entity.HasKey(e => e.DebtLoanId).HasName("PK__DebtsLoa__27937CA54F477CBA");

            entity.Property(e => e.DebtLoanId).HasColumnName("DebtLoanID");
            entity.Property(e => e.Amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.InterestRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.DebtsLoans)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__DebtsLoan__UserI__5BE2A6F2");
        });

        modelBuilder.Entity<ExchangeRate>(entity =>
        {
            entity.HasKey(e => e.RateId).HasName("PK__Exchange__58A7CCBC702C810C");

            entity.Property(e => e.RateId).HasColumnName("RateID");
            entity.Property(e => e.FromCurrencyId).HasColumnName("FromCurrencyID");
            entity.Property(e => e.Rate).HasColumnType("decimal(15, 6)");
            entity.Property(e => e.ToCurrencyId).HasColumnName("ToCurrencyID");

            entity.HasOne(d => d.FromCurrency).WithMany(p => p.ExchangeRateFromCurrencies)
                .HasForeignKey(d => d.FromCurrencyId)
                .HasConstraintName("FK__ExchangeR__FromC__66603565");

            entity.HasOne(d => d.ToCurrency).WithMany(p => p.ExchangeRateToCurrencies)
                .HasForeignKey(d => d.ToCurrencyId)
                .HasConstraintName("FK__ExchangeR__ToCur__6754599E");
        });

        modelBuilder.Entity<Expense>(entity =>
        {
            entity.HasKey(e => e.ExpenseId).HasName("PK__Expenses__1445CFF39EE0A845");

            entity.Property(e => e.ExpenseId).HasColumnName("ExpenseID");
            entity.Property(e => e.Amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ExpenseDate).HasColumnType("date");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Expenses)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Expenses__UserID__4BAC3F29");
        });

        modelBuilder.Entity<FinancialProduct>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Financia__B40CC6ED0E2A4886");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Income>(entity =>
        {
            entity.HasKey(e => e.IncomeId).HasName("PK__Income__60DFC66C75E35B54");

            entity.ToTable("Income");

            entity.Property(e => e.IncomeId).HasColumnName("IncomeID");
            entity.Property(e => e.Amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.IncomeDate).HasColumnType("date");
            entity.Property(e => e.Source)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Incomes)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Income__UserID__4E88ABD4");
        });

        modelBuilder.Entity<Investment>(entity =>
        {
            entity.HasKey(e => e.InvestmentId).HasName("PK__Investme__91D937AB0702CC93");

            entity.Property(e => e.InvestmentId).HasColumnName("InvestmentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.InvestmentDate).HasColumnType("date");
            entity.Property(e => e.InvestmentType)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Investments)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Investmen__UserI__5165187F");
        });

        modelBuilder.Entity<PaymentReminder>(entity =>
        {
            entity.HasKey(e => e.ReminderId).HasName("PK__PaymentR__01A830A7825B7FB7");

            entity.Property(e => e.ReminderId).HasColumnName("ReminderID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ReminderDate).HasColumnType("date");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.PaymentReminders)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__PaymentRe__UserI__571DF1D5");
        });

        modelBuilder.Entity<ProductComparison>(entity =>
        {
            entity.HasKey(e => e.ComparisonId).HasName("PK__ProductC__6E1F99B7457B0050");

            entity.Property(e => e.ComparisonId).HasColumnName("ComparisonID");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductComparisons)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductCo__Produ__6B24EA82");

            entity.HasOne(d => d.User).WithMany(p => p.ProductComparisons)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__ProductCo__UserI__6A30C649");
        });

        modelBuilder.Entity<Security>(entity =>
        {
            entity.HasKey(e => e.SecurityId).HasName("PK__Security__9F8B09508E565D33");

            entity.ToTable("Security");

            entity.Property(e => e.SecurityId).HasColumnName("SecurityID");
            entity.Property(e => e.EncryptionKey)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Securities)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Security__UserID__6E01572D");
        });

        modelBuilder.Entity<TransactionLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__Transact__5E5499A89B6DE8EF");

            entity.Property(e => e.LogId).HasColumnName("LogID");
            entity.Property(e => e.Amount).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.TransactionDate).HasColumnType("date");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.TransactionLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Transacti__UserI__619B8048");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC12BA8084");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Balance)
                .HasColumnType("money");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
