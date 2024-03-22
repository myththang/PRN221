using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project.Models;

namespace PRN221_Project.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly Prn221ProjectContext _context;
        public RegisterModel(Prn221ProjectContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }
        [BindProperty]
        public User User { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Users == null || User == null)
            {
                return Page();
            }

            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Login");
        }
    }
}
