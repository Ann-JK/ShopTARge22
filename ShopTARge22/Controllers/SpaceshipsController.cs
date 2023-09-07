using Microsoft.AspNetCore.Mvc;

namespace ShopTARge22.Controllers
{
    public class SpaceshipsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
