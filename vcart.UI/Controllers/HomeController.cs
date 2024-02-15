using vcart.Services.Implementations;
using vcart.Services.Interfaces;
using vcart.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;
using X.PagedList;
using X.PagedList.Mvc.Core;

namespace vcart.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IItemService _itemService;
        private IMemoryCache _cache;
        public HomeController(ILogger<HomeController> logger, 
            IItemService itemService, IMemoryCache cache)
        {
            _logger = logger;
            _itemService = itemService;
            _cache = cache;
        }

        public IActionResult Index(int? page)
        {
            try
            {
                string key = "catalog";
                int pageSize = 10;
                int pageNumber = page ?? 1;

                var cachedItems = _cache.GetOrCreate(key, entry =>
                {
                    entry.AbsoluteExpiration = DateTime.Now.AddHours(12);
                    entry.SlidingExpiration = TimeSpan.FromMinutes(15);
                    return _itemService.GetItems().ToList(); 
                });

                var pagedItems = _itemService.GetItems().ToPagedList(pageNumber, pageSize);

                return View(pagedItems);
            }
            catch
            {
                  return View("Error");
            }
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.Any, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}