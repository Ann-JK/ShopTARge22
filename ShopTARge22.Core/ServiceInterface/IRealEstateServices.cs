using ShopTARge22.Core.Domain;
using ShopTARge22.Core.DTO;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IRealEstateServices
    {
        Task<RealEstate> Create(RealEstateDTO dto);
        Task<RealEstate> DetailsAsync(Guid id);
        Task<RealEstate> Delete(Guid id);
        Task<RealEstate> Update(RealEstateDTO dto);
    }
}
