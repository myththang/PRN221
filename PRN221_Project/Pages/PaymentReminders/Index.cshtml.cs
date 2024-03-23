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
    public class IndexModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;

        public IndexModel(PRN221_Project.Models.Prn221ProjectContext context)
        {
            _context = context;
        }

        public IList<PaymentReminder> PaymentReminder { get;set; } = default!;

        public async Task OnGetAsync()
        {
            var userId = HttpContext.Session.GetInt32("UserId");

            if (_context.PaymentReminders != null)
            {
                PaymentReminder = await _context.PaymentReminders
            .Include(p => p.User)
            .Where(p => p.User.UserId == userId)
            .ToListAsync();
            }

            var today = DateTime.Now;
            var endOfToday = today.AddHours(24);



            var reminders = await _context.PaymentReminders
                .Include(p => p.User)
                .Where(p => p.ReminderDate >= today && p.ReminderDate <= endOfToday && p.User.UserId == userId)
                .ToListAsync();
            TempData["Reminders"] = reminders;
            HttpContext.Session.SetInt32("RemindersCount", reminders.Count);
            Console.WriteLine("count " + reminders.Count);


        }
    }
}
