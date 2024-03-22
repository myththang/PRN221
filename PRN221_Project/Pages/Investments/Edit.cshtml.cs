using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Investments
{
    public class EditModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;

        public EditModel(PRN221_Project.Models.Prn221ProjectContext context)
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

            var investment =  await _context.Investments.FirstOrDefaultAsync(m => m.InvestmentId == id);
            if (investment == null)
            {
                return NotFound();
            }
            Investment = investment;
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

            _context.Attach(Investment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvestmentExists(Investment.InvestmentId))
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

        private bool InvestmentExists(int id)
        {
          return (_context.Investments?.Any(e => e.InvestmentId == id)).GetValueOrDefault();
        }
    }
}
