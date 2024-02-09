using vcart.Services.Implementations;
using vcart.Services.Interfaces;
using vcart.UI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

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

        public IActionResult Index()
        {
            //var items = _itemService.GetItems();
            //key

            string key = "catalog";
            // _cache.Remove(key); // uncomment only if debug the flow
            var items = _cache.GetOrCreate(key, entry =>
            {
                entry.AbsoluteExpiration = DateTime.Now.AddHours(12);
                entry.SlidingExpiration = TimeSpan.FromMinutes(15);
                return _itemService.GetItems();
            });


            //try
            //{
            //    int x = 0, y = 3;
            //    int z = y / x;
            //}
            //catch (Exception ex)
            //{
            //    _logger.LogError(ex, ex.Message);
            //}
            return View(items);
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