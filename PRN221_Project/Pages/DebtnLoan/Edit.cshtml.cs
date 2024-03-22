using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.DebtnLoan
{
    public class EditModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;

        public EditModel(PRN221_Project.Models.Prn221ProjectContext context)
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

            var debtsloan =  await _context.DebtsLoans.FirstOrDefaultAsync(m => m.DebtLoanId == id);
            if (debtsloan == null)
            {
                return NotFound();
            }
            DebtsLoan = debtsloan;
           ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(DebtsLoan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DebtsLoanExists(DebtsLoan.DebtLoanId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool DebtsLoanExists(int id)
        {
          return (_context.DebtsLoans?.Any(e => e.DebtLoanId == id)).GetValueOrDefault();
        }
    }
}
