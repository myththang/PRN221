using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.Caching.Memory;
using PRN221_Project.Models;
using System.Diagnostics;

namespace PRN221_Project.Pages
{
 
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly Prn221ProjectContext _context;
        
        public IndexModel(ILogger<IndexModel> logger, Prn221ProjectContext context)
        {
            _logger = logger;
            _context = context;
           
        }

        public decimal TotalExpense { get; set; }
        public decimal TotalIncome { get; set; }
        public decimal Balance { get; set; }
        public decimal Budget { get; set; }

        [BindProperty(SupportsGet = true)]

        public List<string> Categories { get; set; }
        public List<decimal> ExpenseAmounts { get; set; }
        public List<decimal> IncomeAmounts { get; set; }
        public List<decimal> ExpenseAmountsOverTime { get; set; }
        public List<string> Dates { get; set; }
        public string culture = "vi-VN";
        public void OnGet()
        {
            
            if (!Request.Method.Equals("POST", StringComparison.OrdinalIgnoreCase))
            {

                var currentUser = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("Username"));
                TotalExpense = _context.Expenses.Where(e => e.UserId == currentUser.UserId).Sum(e => e.Amount);
                TotalIncome = _context.Incomes.Where(i => i.UserId == currentUser.UserId).Sum(i => i.Amount);
                Balance = currentUser.Balance;
                Budget = _context.Budgets.Where(b => b.UserId == currentUser.UserId).Sum(b => b.TotalBudget);
                // Fetch expense categories and amounts
                Categories = new List<string> { "Food", "Transportation", "Shopping", "Debt Payments", "Savings" };
                ExpenseAmounts = new List<decimal>();
                foreach (var category in Categories)
                {
                    var totalExpense = _context.Expenses
                        .Where(e => e.UserId == currentUser.UserId && e.Category == category)
                        .Sum(e => e.Amount);
                    ExpenseAmounts.Add(totalExpense);
                }


                var startDate = DateTime.Today.AddMonths(-6); // Assuming you want data for the last 6 months
                var endDate = DateTime.Today;
                Dates = new List<string>();
                IncomeAmounts = new List<decimal>();
                ExpenseAmountsOverTime = new List<decimal>();
                for (var date = startDate; date <= endDate; date = date.AddMonths(1))
                {
                    Dates.Add(date.ToString("MMM yyyy"));

                    var totalIncome = _context.Incomes
                        .Where(i => i.UserId == currentUser.UserId && i.IncomeDate.Month == date.Month && i.IncomeDate.Year == date.Year)
                        .Sum(i => i.Amount);
                    IncomeAmounts.Add(totalIncome);

                    var totalExpense = _context.Expenses
                        .Where(e => e.UserId == currentUser.UserId && e.ExpenseDate.Month == date.Month && e.ExpenseDate.Year == date.Year)
                        .Sum(e => e.Amount);
                    ExpenseAmountsOverTime.Add(totalExpense);
                }

            }
            if (HttpContext.Session.GetString("NewCurrency") != "1")
            {
  
                var newCurrency = HttpContext.Session.GetString("NewCurrency");

                if ( !string.IsNullOrEmpty(newCurrency))
                {
                    if ( int.TryParse(newCurrency, out int newCurrencyId))
                    {
                        switch (newCurrencyId)
                        {
                            case 1:
                                culture = "vi-VN";
                                break;
                            case 2:
                                culture = "en-US";
                                break;
                            case 3:
                                culture = "fr-FR";
                                break;
                            
                        }
                        var eRate = _context.ExchangeRates
                            .FirstOrDefault(e =>  e.ToCurrencyId == newCurrencyId);

                        if (eRate != null)
                        {

                            TotalExpense = TotalExpense * eRate.Rate;
                            TotalIncome = TotalIncome * eRate.Rate;
                            Balance = Balance * eRate.Rate; 
                            Budget = Budget * eRate.Rate;
                            for (int i = 0; i < ExpenseAmounts.Count; i++)
                            {
                                ExpenseAmounts[i] = ExpenseAmounts[i] * eRate.Rate;
                            }
                            for (int i = 0; i < IncomeAmounts.Count; i++)
                            {
                                IncomeAmounts[i] *= eRate.Rate;
                            }
                            for (int i = 0; i < ExpenseAmountsOverTime.Count; i++)
                            {
                                ExpenseAmountsOverTime[i] *= eRate.Rate;
                            }
                        }
                    }
                }
            }

        }
    }
}