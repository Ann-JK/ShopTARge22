using ShopTARge22.Core.Domain;
using ShopTARge22.Core.DTO;
namespace ShopTARge222.Core.ServiceInterface
{
    public interface ISpaceshipsServices
    {
        Task<Spaceship> Create(SpaceshipDTO dto);
        Task<Spaceship> DetailsAsync(Guid id);

        Task<Spaceship> Delete(Guid id);
        Task<Spaceship> Update(SpaceshipDTO dto);
    }
}
