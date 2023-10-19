using ShopTARge22.ApplicationServices.Services;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.DTO;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.RealEstateTest;

namespace ShopTARge22.SpaceshipsTest
{
    public class SpaceShipsTest : TestBase
    {

        [Fact]
        public async Task ShouldNot_AddEmptySpaceship_WhenReturnResult()
        {
            //Arrange
            SpaceshipDTO spaceship = new();
            spaceship.Name = "TestName";
            spaceship.Type = "Moonship";
            spaceship.BuiltDate = DateTime.Now.AddDays(-10);
            spaceship.Passengers = 6;
            spaceship.CargoWeight = 214;
            spaceship.Crew = 2;
            spaceship.EnginePower = 30;
            spaceship.CreatedAt = DateTime.Now.AddDays(-1);
            spaceship.ModifiedAt = DateTime.Now.AddDays(-1);

            var result = await Svc<ISpaceshipsServices>().Create(spaceship);
            Assert.NotNull(result);
        }

        [Fact]
        public async Task Should_GetBydSpaceship_WhenReturnsEqual()
        {
            Guid databaseGuid = Guid.Parse("173d934d-6446-4a36-a200-515ea63d1795");
            Guid guid = Guid.Parse("173d934d-6446-4a36-a200-515ea63d1795");

            await Svc<ISpaceshipsServices>().DetailsAsync(guid);

            Assert.Equal(databaseGuid, guid);
        }

        [Fact]
        public async Task Should_DeleteByIdRealEstate_WhenDeleteRealEstate()
        {
            SpaceshipDTO spaceship = MockSpaceshipData();


            var addSpaceship = await Svc<ISpaceshipsServices>().Create(spaceship);
            var result = await Svc<ISpaceshipsServices>().Delete((Guid)addSpaceship.Id);

            Assert.Equal(result, addSpaceship);
        }

        private SpaceshipDTO MockSpaceshipData()
        {
            SpaceshipDTO spaceship = new()
            {
                Name = "TestName",
                Type = "Moonship",
                BuiltDate = DateTime.Now.AddDays(-10),
                Passengers = 6,
                CargoWeight = 214,
                Crew = 2,
                EnginePower = 30,
                CreatedAt = DateTime.Now.AddDays(-1),
                ModifiedAt = DateTime.Now.AddDays(-1),

        };

            return spaceship;
        }

        [Fact]
        public async Task ShouldNot_DeleteByIdSpaceship_WhenDidNotDeleteSpaceship()
        {
            SpaceshipDTO spaceship = MockSpaceshipData();

            var spaceship1 = await Svc<ISpaceshipsServices>().Create(spaceship);
            var spaceship2 = await Svc<ISpaceshipsServices>().Create(spaceship);

            var result = await Svc<ISpaceshipsServices>().Delete((Guid)spaceship2.Id);

            Assert.NotEqual(result.Id, spaceship1.Id);

        }

        [Fact]
        public async Task Should_UpdateSpaceship_WhenUpdateData()
        {
            var guid = new Guid("173d934d-6446-4a36-a200-515ea63d1795");

            SpaceshipDTO dto = MockSpaceshipData();
            Spaceship spaceship = new();

            spaceship.Id = Guid.Parse("173d934d-6446-4a36-a200-515ea63d1795");
            spaceship.Name = "TestName";
            spaceship.Type = "Mars ship";
            spaceship.BuiltDate = DateTime.Now.AddDays(-10);
            spaceship.Passengers = 6;
            spaceship.CargoWeight = 214;
            spaceship.Crew = 2;
            spaceship.EnginePower = 30;
            spaceship.CreatedAt = DateTime.Now.AddDays(-1);
            spaceship.ModifiedAt = DateTime.Now.AddDays(-1);

            await Svc<ISpaceshipsServices>().Update(dto);

            Assert.Equal(spaceship.Id, guid);
            //Assert.DoesNotMatch(spaceship.Passengers);

        }

        private SpaceshipDTO MockUpdateSpaceshipData()
        {
            SpaceshipDTO spaceship = new()
            {
                Name = "TestName",
                Type = "Moonship",
                BuiltDate = DateTime.Now.AddDays(-10),
                Passengers = 8,
                CargoWeight = 100,
                Crew = 2,
                EnginePower = 30,
                CreatedAt = DateTime.Now.AddDays(-1),
                ModifiedAt = DateTime.Now,

            };

            return spaceship;
        }
    }
}
