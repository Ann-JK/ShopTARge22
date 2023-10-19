using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.DTO;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Data;
using ShopTARge22.Models.Spaceships;

namespace ShopTARge22.Controllers
{
    public class SpaceshipsController : Controller
    {
        private readonly ShopTARge22Context _context;
        private readonly ISpaceshipsServices _spaceshipServices;
        private readonly IFileServices _fileServices;

        public SpaceshipsController
            (
                ShopTARge22Context context,
                ISpaceshipsServices spaceshipsServices,
                IFileServices  fileServices
            )
        {
            _context = context;
            _spaceshipServices = spaceshipsServices;
            _fileServices = fileServices;
        }


        public IActionResult Index()
        {
            var result = _context.Spaceships
                .Select(x => new SpaceshipsIndexViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    BuiltDate = x.BuiltDate,
                    Passengers = x.Passengers
                });

            return View(result);
        }

        [HttpGet]
        public IActionResult Create()
        {
            SpaceshipsCreateUpdateViewModel result = new SpaceshipsCreateUpdateViewModel();

            return View("CreateUpdate", result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SpaceshipsCreateUpdateViewModel vm)
        {
            var dto = new SpaceshipDTO()
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                Passengers = vm.Passengers,
                BuiltDate = vm.BuiltDate,
                CargoWeight = vm.CargoWeight,
                Crew = vm.Crew,
                EnginePower = vm.EnginePower,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                Files = vm.Files,
                FiletoApiDTOs = vm.Image
                    .Select(x => new FileToApiDTO
                    {
                        Id = x.ImageId,
                        ExistingFilePath = x.FilePath,
                        SpaceshipId = x.SpaceshipId,
                    }).ToArray()
            };

            var result = await _spaceshipServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

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

            var images = await _context.FileToApis
                .Where(x => x.SpaceshipId == id)
                .Select(y => new ImageViewModel
                {
                    FilePath = y.ExistingFilePath,
                    ImageId = y.Id,
                }).ToArrayAsync();

            var vm = new SpaceshipsCreateUpdateViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Type = spaceship.Type;
            vm.BuiltDate = spaceship.BuiltDate;
            vm.Passengers = spaceship.Passengers;
            vm.CargoWeight = spaceship.CargoWeight;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;
            vm.Image.AddRange(images);


            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(SpaceshipsCreateUpdateViewModel vm)
        {
            var dto = new SpaceshipDTO()
            {
                Id = vm.Id,
                Name = vm.Name,
                Type = vm.Type,
                BuiltDate = vm.BuiltDate,
                Passengers = vm.Passengers,
                CargoWeight = vm.CargoWeight,
                Crew = vm.Crew,
                EnginePower = vm.EnginePower,
                CreatedAt = vm.CreatedAt,
                ModifiedAt = vm.ModifiedAt,
                FiletoApiDTOs = vm.Image
                .Select(x => new FileToApiDTO
                {
                    Id = x.ImageId,
                    ExistingFilePath = x.FilePath,
                    SpaceshipId = x.SpaceshipId
                }).ToArray()
            };

            var result = await _spaceshipServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var spaceship = await _spaceshipServices.DetailsAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }


            var vm = new SpaceshipDetailsViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Type = spaceship.Type;
            vm.BuiltDate = spaceship.BuiltDate;
            vm.Passengers = spaceship.Passengers;
            vm.CargoWeight = spaceship.CargoWeight;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;


            return View(vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var spaceship = await _spaceshipServices.DetailsAsync(id);

            if (spaceship == null)
            {
                return NotFound();
            }

            var images = await _context.FileToApis
               .Where(x => x.SpaceshipId == id)
               .Select(y => new ImageViewModel
               {
                   FilePath = y.ExistingFilePath,
                   ImageId = y.Id
               }).ToArrayAsync();

            var vm = new SpaceshipDeleteViewModel();

            vm.Id = spaceship.Id;
            vm.Name = spaceship.Name;
            vm.Type = spaceship.Type;
            vm.BuiltDate = spaceship.BuiltDate;
            vm.Passengers = spaceship.Passengers;
            vm.CargoWeight = spaceship.CargoWeight;
            vm.Crew = spaceship.Crew;
            vm.EnginePower = spaceship.EnginePower;
            vm.CreatedAt = spaceship.CreatedAt;
            vm.ModifiedAt = spaceship.ModifiedAt;
            vm.ImageViewModels.AddRange(images);


            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
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