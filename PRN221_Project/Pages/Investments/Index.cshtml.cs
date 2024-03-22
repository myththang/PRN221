using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Investments
{
    public class IndexModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;

        public IndexModel(PRN221_Project.Models.Prn221ProjectContext context)
        {
            _context = context;
        }

        public IList<Investment> Investment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Investments != null)
            {
                Investment = await _context.Investments
                .Include(i => i.User).ToListAsync();
            }
        }
    }
}
