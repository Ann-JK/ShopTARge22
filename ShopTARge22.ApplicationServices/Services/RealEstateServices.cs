using Microsoft.EntityFrameworkCore;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.DTO;
using ShopTARge22.Data;
using System.Net.Sockets;

namespace ShopTARge22.ApplicationServices.Services
{
    public class RealEstateServices
    {
        private readonly ShopTARge22Context _context;

        public RealEstateServices
            (
                ShopTARge22Context context
            )
        {
            _context = context;
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
            var domain = new RealEstate()
            {
                Id = dto.Id,
                Address = dto.Address,
                SizeSqrM = dto.SizeSqrM,
                RoomCount = dto.RoomCount,
                Floor = dto.Floor,
                BuildingType = dto.BuildingType,
                BuiltInYear = dto.BuiltInYear,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };

            _context.RealEstates.Update(domain);
            await _context.SaveChangesAsync();

            return domain;
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
