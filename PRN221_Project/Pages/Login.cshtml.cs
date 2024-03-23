using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace PRN221_Project.Pages
{
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client, NoStore = false)]
    public class LoginModel : PageModel
    {

        private readonly Prn221ProjectContext _context;
        public LoginModel (Prn221ProjectContext context)
        {
            _context = context; 
        }
        [BindProperty]
        public string Username { get; set; }

        [BindProperty]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var user = _context.Users.FirstOrDefault(u => u.Username == Username && u.Password == Password);
            if (user != null)
            {
                HttpContext.Session.SetString("Username", Username);
                HttpContext.Session.SetInt32("UserId", user.UserId);
                HttpContext.Session.SetString("NewCurrency", "1");
                var userId = HttpContext.Session.GetInt32("UserId");
                var today = DateTime.Now;
                var endOfToday = today.AddHours(24);

                var reminders = _context.PaymentReminders
                    .Include(p => p.User)
                    .Where(p => p.ReminderDate >= today && p.ReminderDate <= endOfToday && p.User.UserId == userId)
                    .ToList();
                HttpContext.Session.SetInt32("RemindersCount", reminders.Count);
                Console.WriteLine("count " + reminders.Count);

                return RedirectToPage("Dashboard");
            }
            else
            {
                // Authentication failed, add a model error and stay on the login page
                ModelState.AddModelError(string.Empty, "Invalid username or password");
                return Page();
            }


        }
    }
}
