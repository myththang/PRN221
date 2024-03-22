using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project.Models;
using System.ComponentModel.DataAnnotations;

namespace PRN221_Project.Pages
{
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
            var user = _context.Users.FirstOrDefault(u=>u.Username==Username&&u.Password==Password);
            if (user != null)
            {
                HttpContext.Session.SetString("Username", Username);
                return RedirectToPage("Index");
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
