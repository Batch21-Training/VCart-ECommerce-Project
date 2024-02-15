using Microsoft.AspNetCore.Mvc;
using vcart.Services.Interfaces;
using X.PagedList;

namespace vcart.UI.ViewComponents
{
    public class ProductMenuViewComponent : ViewComponent
    {
        private readonly IItemService _itemService;
        private readonly int _pageSize;

        public ProductMenuViewComponent(IItemService itemService)
        {
            _itemService = itemService;
            _pageSize = 3; // Set the default page size
        }

        public IViewComponentResult Invoke(int? pageNumber, int? pageSize)
        {
            var _pageNumber = pageNumber ?? 1;
            var items = _itemService.GetItems().ToList(); // Assuming GetItems returns IEnumerable<ItemModel>
            var pagedItems = items.ToPagedList(_pageNumber, pageSize ?? _pageSize);

            ViewBag.PageNumber = _pageNumber;
            ViewBag.PageSize = pageSize ?? _pageSize;

            return View("~/Views/Shared/_ProductMenu.cshtml", pagedItems);

        }
    }
}


