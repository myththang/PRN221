using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Budgets
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;

        public IndexModel(PRN221_Project.Models.Prn221ProjectContext context)
        {
            _context = context;
        }

        public IList<Budget> Budget { get;set; } = default!;
        public string culture = "vi-VN";
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {

                return RedirectToPage("/Index");
            }

            var currentUser = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("Username"));
            Budget = _context.Budgets.Where(e => e.UserId == currentUser.UserId).ToList();
            return Page();
        }
    }
}
