using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.PaymentReminders
{
    public class DetailsModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;

        public DetailsModel(PRN221_Project.Models.Prn221ProjectContext context)
        {
            _context = context;
        }

      public PaymentReminder PaymentReminder { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.PaymentReminders == null)
            {
                return NotFound();
            }

            var paymentreminder = await _context.PaymentReminders.FirstOrDefaultAsync(m => m.ReminderId == id);
            if (paymentreminder == null)
            {
                return NotFound();
            }
            else 
            {
                PaymentReminder = paymentreminder;
            }
            return Page();
        }
    }
}
