using Microsoft.AspNetCore.Mvc;
using ShopTARge22.Data;
using ShopTARge22.Models.Spaceships;

namespace ShopTARge22.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShopTARge22Context _context;
        private readonly ISpaceshipServices _spaceshipServices;

        public SpaceshipsController
            (
                ShopTARge22Context context, 
                ISpaceshipServices spaceshipServices
            )
        {
            _context = context;
            _spaceshipServices = spaceshipServices;
        }
        public IActionResult Index()
        {
            var resul = _context.Spaceships
                .Select(x => new SpaceshipsIndexViewModel
                 {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    BuiltDate = x.BuiltDate,
                    Passengers = x.Passengers
                 });
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipsCreateViewModel vm)
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                Passengers = vm.Passengers,
                EnginePower = vm.EnginePower,
                Crew = vm.Crew,
                Company = vm.Company,
                CargoWeight = vm.CargoWeight

            };

            var result = await _spaceshipServices.Create(dto);

            return RedirectToAction(nameof(Index), vm);
        
        }

        [HttpPost]
        public async Task<ActionResult> DeleteConfirmation(Guid id) 
        {
            var spaceshipId = await _spaceshipServices.Delete(id);

            if (spaceshipId == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
