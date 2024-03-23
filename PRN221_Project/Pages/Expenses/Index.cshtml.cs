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

namespace PRN221_Project.Pages.Expenses
{
    
    public class IndexModel : PageModel 
    {
        private readonly PRN221_Project.Models.Prn221ProjectContext _context;
        private readonly ILogger<IndexModel> _logger;
        private readonly IMemoryCache _cache;
        private readonly string cachingKey = "ExpensesKey";
        public IndexModel(PRN221_Project.Models.Prn221ProjectContext context,IMemoryCache cache, ILogger<IndexModel> logger)
        {
            _context = context;
            _cache = cache;
            _logger = logger;
        }

        public IList<Expense> Expense { get;set; } = default!;
        public string culture = "vi-VN";
        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("Username") == null)
            {

                return RedirectToPage("/Login");
            }
            var currentUser = _context.Users.FirstOrDefault(u => u.Username == HttpContext.Session.GetString("Username"));
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            if (_cache.TryGetValue(cachingKey, out IEnumerable<Expense> expense))
            {
                _logger.Log(LogLevel.Information, "Expense found in cache");
            }
            else
            {
                _logger.Log(LogLevel.Information, "not found in cache.Loading");
                expense = _context.Expenses.Where(e => e.UserId == currentUser.UserId).ToList();
                var cacheEntryOption = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(45))
                    .SetAbsoluteExpiration(TimeSpan.FromSeconds(3600))
                    .SetPriority(CacheItemPriority.Normal);
                _cache.Set(cachingKey, expense, cacheEntryOption);
            }
            stopwatch.Stop();
            _logger.Log(LogLevel.Information, "Passed time"+ stopwatch.ElapsedMilliseconds);

            Expense = expense.ToList() ;


            return Page();
        }
        public IActionResult OnPost()
        {
            return ClearCache();
        }

        public IActionResult ClearCache()
        {
            _cache.Remove(cachingKey);
            _logger.Log(LogLevel.Information, "Cleared cache");
            return RedirectToPage("/Expense");
        }
    }
}
