using Microsoft.AspNetCore.Mvc;
using vcart.Services.Interfaces;

namespace vcart.UI.ViewComponents
{
    public class ProductMenuViewComponent: ViewComponent
    {
        IItemService _itemService;
        public ProductMenuViewComponent(IItemService itemService)
        {
            _itemService = itemService;
        }

        public IViewComponentResult Invoke()
        {
            var items = _itemService.GetItems();
            return View("~/Views/Shared/_ProductMenu.cshtml", items);
        }
    }
}
