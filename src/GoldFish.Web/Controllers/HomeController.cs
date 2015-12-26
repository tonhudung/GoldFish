using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace GoldFish.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
