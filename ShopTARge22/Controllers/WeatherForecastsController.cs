using Microsoft.AspNetCore.Mvc;

namespace ShopTARge22.Controllers
{
    public class WeatherForecastsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
