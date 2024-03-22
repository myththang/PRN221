using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Incomes
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;

        public IndexModel(PRN221_Project.Models.Prn221ProjectContext context)
        {
            _context = context;
        }

        public IList<Income> Income { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Incomes != null)
            {
                Income = await _context.Incomes
                .Include(i => i.User).ToListAsync();
            }
        }
    }
}
