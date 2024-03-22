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
    public class DetailsModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;

        public DetailsModel(PRN221_Project.Models.Prn221ProjectContext context)
        {
            _context = context;
        }

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
    }
}
