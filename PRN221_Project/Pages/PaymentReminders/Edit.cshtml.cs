using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.PaymentReminders
{
    public class EditModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;

        public EditModel(PRN221_Project.Models.Prn221ProjectContext context)
        {
            _context = context;
        }

        [BindProperty]
        public PaymentReminder PaymentReminder { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PaymentReminders == null)
            {
                return NotFound();
            }

            var paymentreminder =  await _context.PaymentReminders.FirstOrDefaultAsync(m => m.ReminderId == id);
            if (paymentreminder == null)
            {
                return NotFound();
            }
            PaymentReminder = paymentreminder;
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

            _context.Attach(PaymentReminder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentReminderExists(PaymentReminder.ReminderId))
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

        private bool PaymentReminderExists(int id)
        {
          return (_context.PaymentReminders?.Any(e => e.ReminderId == id)).GetValueOrDefault();
        }
    }
}
