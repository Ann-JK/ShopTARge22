using ShopTARge22.Core.Domain;
using ShopTARge22.Core.DTO;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceshipDTO dto, Spaceship spaceship);
    }
}
