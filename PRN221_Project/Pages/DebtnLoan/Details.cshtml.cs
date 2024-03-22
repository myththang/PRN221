using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.DebtnLoan
{
    public class DetailsModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;

        public DetailsModel(PRN221_Project.Models.Prn221ProjectContext context)
        {
            _context = context;
        }

      public DebtsLoan DebtsLoan { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.DebtsLoans == null)
            {
                return NotFound();
            }

            var debtsloan = await _context.DebtsLoans.FirstOrDefaultAsync(m => m.DebtLoanId == id);
            if (debtsloan == null)
            {
                return NotFound();
            }
            else 
            {
                DebtsLoan = debtsloan;
            }
            return Page();
        }
    }
}
