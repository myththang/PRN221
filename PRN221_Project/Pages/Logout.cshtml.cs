using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PRN221_Project.Pages
{
    public class LogoutModel : PageModel
    {
        

        public IActionResult OnGet()
        {
            
           HttpContext.Session.Clear();

            // Redirect to home page or login page after logout
            return RedirectToPage("/Index");
        }
    }
}
