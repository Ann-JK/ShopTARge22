using Microsoft.EntityFrameworkCore;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.DTO;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Data;

namespace ShopTARge22.ApplicationServices.Services
{
    public class RealEstateServices : IRealEstateServices
    {
        private readonly ShopTARge22Context _context;
        private readonly IFileServices _fileServices;

        public RealEstateServices
            (
                ShopTARge22Context context, 
                IFileServices fileServices

            )
        {
            _context = context;
            _fileServices = fileServices;
        }

        public async Task<RealEstate> Create(RealEstateDTO dto)
        {
            RealEstate realEstate = new RealEstate();

            realEstate.Id = Guid.NewGuid();
            realEstate.Address = dto.Address;
            realEstate.SizeSqrM = dto.SizeSqrM;
            realEstate.RoomCount = dto.RoomCount;
            realEstate.Floor = dto.Floor;
            realEstate.BuildingType = dto.BuildingType;
            realEstate.BuiltInYear = dto.BuiltInYear;
            realEstate.CreatedAt = dto.CreatedAt;
            realEstate.UpdatedAt = dto.UpdatedAt;
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, realEstate);
            }

            await _context.RealEstates.AddAsync(realEstate);
            await _context.SaveChangesAsync();

            return realEstate;
        }

        public async Task<RealEstate> DetailsAsync(Guid id)
        {
            var result = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);
            
            return result;
        }

        public async Task<RealEstate> Update(RealEstateDTO dto)
        {
            RealEstate realEstate = new();

            realEstate.Id = dto.Id;
            realEstate.Address = dto.Address;
            realEstate.SizeSqrM = dto.SizeSqrM;
            realEstate.RoomCount = dto.RoomCount;
            realEstate.Floor = dto.Floor;
            realEstate.BuildingType = dto.BuildingType;
            realEstate.BuiltInYear = dto.BuiltInYear;
            realEstate.CreatedAt = dto.CreatedAt;
            realEstate.UpdatedAt = dto.UpdatedAt;
            if (dto.Files != null)
            {
                _fileServices.UploadFilesToDatabase(dto, realEstate);
            }

            _context.RealEstates.Update(realEstate);
            await _context.SaveChangesAsync();

            return realEstate;
        }

        public async Task<RealEstate> Delete(Guid id)
        {
            var realEstateId = await _context.RealEstates
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.RealEstates.Remove(realEstateId);
            await _context.SaveChangesAsync();

            return realEstateId;
        }
    }
}
