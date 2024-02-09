using vcart.Models;
using vcart.UI.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Text.Json;

namespace vcart.UI.Areas.User.Controllers
{
    [CustomAuthorize(Roles = "User")]
    [Area("User")]
    public class BaseController : Controller
    {
        public UserModel CurrentUser
        {
            get
            {
                if (User != null)
                {
                    string userData = User.Claims.Where(c => c.Type == ClaimTypes.UserData).FirstOrDefault()?.Value;
                    if (userData != null)
                    {
                        UserModel model = JsonSerializer.Deserialize<UserModel>(userData);
                        return model;
                    }
                }
                return null;
            }
        }
    }
}
