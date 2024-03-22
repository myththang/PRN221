using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Budgets
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
            return Page();
        }

        [BindProperty]
        public Budget Budget { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Budgets == null || Budget == null)
            {
                return Page();
            }
            var currentUser = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("Username"));
            Budget.UserId = currentUser.UserId;
            _context.Budgets.Add(Budget);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
