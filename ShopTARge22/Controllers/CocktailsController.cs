using Microsoft.AspNetCore.Mvc;

namespace ShopTARge22.Controllers
{
    public class CocktailsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
