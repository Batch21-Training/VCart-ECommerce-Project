using Microsoft.AspNetCore.Mvc;
using vcart.Services.Interfaces;
using X.PagedList;

namespace vcart.UI.ViewComponents
{
    public class ProductMenuViewComponent: ViewComponent
    {
        IItemService _itemService;
        public ProductMenuViewComponent(IItemService itemService)
        {
            _itemService = itemService;
        }

        public IViewComponentResult Invoke(IPagedList productItems)
        {
            //var items = _itemService.GetItems().ToList();
            var items = productItems;
            return View("~/Views/Shared/_ProductMenu.cshtml", items);
        }
    }
}
