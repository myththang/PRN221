using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using PRN221_Project.Models;

namespace PRN221_Project.Pages.Incomes
{
    [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client, NoStore = false)]
    public class IndexModel : PageModel
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;
        private readonly ILogger<IndexModel> _logger;
        private readonly IMemoryCache _cache;
        private readonly string cachingKey = "IncomesKey";
        public IndexModel(PRN221_Project.Models.Prn221ProjectContext context, IMemoryCache cache, ILogger<IndexModel> logger)
        {
            _context = context;
            _cache = cache;
            _logger = logger;   
        }

        public IList<Income> Income { get;set; } = default!;
      
        public async Task OnGetAsync()
        {
            var currentUser = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("Username"));
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            if (_cache.TryGetValue(cachingKey, out IEnumerable<Income> income))
            {
                _logger.Log(LogLevel.Information, "Income found in cache");
            }
            else
            {
                _logger.Log(LogLevel.Information, "not found in cache.Loading");
                income = _context.Incomes.Where(e => e.UserId == currentUser.UserId).ToList();
                var cacheEntryOption = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(45))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                    .SetPriority(CacheItemPriority.Normal);
                _cache.Set(cachingKey, income, cacheEntryOption);
            }
            stopwatch.Stop();
            _logger.Log(LogLevel.Information, "Passed time" + stopwatch.ElapsedMilliseconds);

            Income = income.ToList();
        }
    }
}
