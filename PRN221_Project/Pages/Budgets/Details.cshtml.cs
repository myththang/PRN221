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
    public class DetailsModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;

        public DetailsModel(PRN221_Project.Models.Prn221ProjectContext context)
        {
            _context = context;
        }

      public Budget Budget { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Budgets == null)
            {
                return NotFound();
            }

            var budget = await _context.Budgets.FirstOrDefaultAsync(m => m.BudgetId == id);
            if (budget == null)
            {
                return NotFound();
            }
            else 
            {
                Budget = budget;
            }
            return Page();
        }
    }
}
