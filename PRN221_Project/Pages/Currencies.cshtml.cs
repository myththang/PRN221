using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PRN221_Project.Models;

namespace PRN221_Project.Pages
{
    public class CurrenciesModel : PageModel
    {
        private readonly Prn221ProjectContext _context;
        public CurrenciesModel(Prn221ProjectContext context)
        {
            _context = context;
        }
        public IList<Currency> Currency {  get; set; }
        [BindProperty(SupportsGet = true)]
        public string SelectedCurrency { get; set; }
        public void OnGet()
        {
            Currency = _context.Currencies.ToList();
        }
        public IActionResult OnPost()
        {
            HttpContext.Session.SetString("OldCurrency", HttpContext.Session.GetString("NewCurrency"));
            HttpContext.Session.SetString("NewCurrency", SelectedCurrency);
            return RedirectToPage();
        }
    }
}
