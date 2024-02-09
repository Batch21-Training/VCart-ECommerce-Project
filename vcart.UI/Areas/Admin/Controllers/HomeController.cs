using Microsoft.AspNetCore.Mvc;

namespace vcart.UI.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
