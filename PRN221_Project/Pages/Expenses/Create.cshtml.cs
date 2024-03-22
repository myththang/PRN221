using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Expenses
{
    public class CreateModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;

        public CreateModel(PRN221_Project.Models.Prn221ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {

                return RedirectToPage("/Index");
            }
            Categories = new List<string> { "Food", "Transportation", "Shopping", "Debt Payments", "Savings" };
            return Page();
        }

        [BindProperty]
        public Expense Expense { get; set; } = default!;
        public List<string> Categories { get; set; }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var currentUser = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("Username"));
            Expense.UserId = currentUser.UserId;
            Expense.ExpenseDate = DateTime.Now;
            currentUser.Balance = currentUser.Balance-Expense.Amount;
            _context.Expenses.Add(Expense);
            _context.SaveChanges();

            return RedirectToPage("./Index");
        }
    }
}
