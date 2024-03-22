using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Investments
{
    public class DeleteModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;

        public DeleteModel(PRN221_Project.Models.Prn221ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Investment Investment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Investments == null)
            {
                return NotFound();
            }

            var investment = await _context.Investments.FirstOrDefaultAsync(m => m.InvestmentId == id);

            if (investment == null)
            {
                return NotFound();
            }
            else 
            {
                Investment = investment;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Investments == null)
            {
                return NotFound();
            }
            var investment = await _context.Investments.FindAsync(id);

            if (investment != null)
            {
                Investment = investment;
                _context.Investments.Remove(Investment);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
