using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Incomes
{
    public class DetailsModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;

        public DetailsModel(PRN221_Project.Models.Prn221ProjectContext context)
        {
            _context = context;
        }

      public Income Income { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Incomes == null)
            {
                return NotFound();
            }

            var income = await _context.Incomes.FirstOrDefaultAsync(m => m.IncomeId == id);
            if (income == null)
            {
                return NotFound();
            }
            else 
            {
                Income = income;
            }
            return Page();
        }
    }
}
