using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Expenses
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;

        public IndexModel(PRN221_Project.Models.Prn221ProjectContext context)
        {
            _context = context;
        }

        public IList<Expense> Expense { get;set; } = default!;

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {

                return RedirectToPage("/Index");
            }

            var currentUser = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("Username"));
            Expense = _context.Expenses.Where(e => e.UserId == currentUser.UserId).ToList();


            return Page();
        }
    }
}
