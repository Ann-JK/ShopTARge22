using Microsoft.AspNetCore.Mvc;
using ShopTARge22.Data;
using ShopTARge22.Models.Spaceships;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Xml.Linq;
using ShopTARge22.Core.Domain;

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

        [HttpGet]
        public IActionResult Create() 
        {
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

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var spaceship = await _spaceshipServices.DetailsAsync(id);

            if (spaceship == null) 
            {
                return NotFound();
            }

            var vm = new SpaceshipsCreateUpdateViewModel();

            vm.Id = spaceship.Id,
            vm.Name = spaceship.Name,
            vm.Type = spaceship.Type,
            vm.Passengers = spaceship.Passengers,
            vm.EnginePower = spaceship.EnginePower,
            vm.Crew = spaceship.Crew,
            vm.Company = spaceship.Company,
            vm.CargoWeight = spaceship.CargoWeight

            return View("CreateUpdate"vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipsCreateUpdateViewModel vm) 
        {
            var dto = new SpaceshipDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                BuiltDate = vm.BuiltDate,
                Passengers = vm.Passengers,
                CargoWeight = vm.CargoWeight,
                Crew = vm.Crew,
                EnginePower = vm.EnginePower,
                Company = vm.Company,
                CreatedAtAction = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt
            };
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
