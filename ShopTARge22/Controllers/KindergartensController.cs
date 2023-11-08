using Microsoft.AspNetCore.Mvc;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Data;
using ShopTARge22.Models.Kindergartens;

namespace ShopTARge22.Controllers
{
    public class KindergartensController : Controller
    {
        private readonly ShopTARge22Context _context;
        private readonly IKindergartensServices _kindergartensServices;

        public KindergartensController
            (
                ShopTARge22Context context,
                IKindergartensServices kindergartenServices
            )
        { 
            _context = context;
            _kindergartensServices = kindergartenServices;
        }

        public IActionResult Index()
        {
            var result = _context.Kindergartens
                .Select(x => new KindergartensIndexViewModel
                {
                    Id = x.Id,
                    GroupName = x.GroupName,
                    ChildrenCount = x.ChildrenCount,
                    KindergartenName = x.KindergartenName,
                    Teacher = x.Teacher,

                });
            return View(result);
        }
    }
}
