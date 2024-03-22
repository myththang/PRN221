using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Investments
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
        ViewData["UserId"] = new SelectList(_context.Users, "UserId", "UserId");
            return Page();
        }

        [BindProperty]
        public Investment Investment { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Investments == null || Investment == null)
            {
                return Page();
            }

            _context.Investments.Add(Investment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
