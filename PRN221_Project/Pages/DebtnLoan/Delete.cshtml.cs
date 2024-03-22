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
    public class DeleteModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;

        public DeleteModel(PRN221_Project.Models.Prn221ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.DebtsLoans == null)
            {
                return NotFound();
            }
            var debtsloan = await _context.DebtsLoans.FindAsync(id);

            if (debtsloan != null)
            {
                DebtsLoan = debtsloan;
                _context.DebtsLoans.Remove(DebtsLoan);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
