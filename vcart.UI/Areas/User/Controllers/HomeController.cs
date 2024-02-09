using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using vcart.Services.Interfaces;

namespace vcart.UI.Areas.User.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;
        IItemService _itemService;
        private IMemoryCache _cache;
        public HomeController(ILogger<HomeController> logger, IItemService itemService, IMemoryCache cache)
        {
            _logger = logger;
            _itemService = itemService;
            _cache = cache;
        }

        public IActionResult Index()
        {
            string key = "catalog";
            var items = _cache.GetOrCreate(key, entry =>
            {
                entry.AbsoluteExpiration = DateTime.Now.AddHours(12);
                entry.SlidingExpiration = TimeSpan.FromMinutes(15);
                return _itemService.GetItems();
            });

            return View(items);
        }
    }
}
