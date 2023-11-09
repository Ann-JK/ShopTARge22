using Microsoft.EntityFrameworkCore;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.DTO;
using ShopTARge22.Core.ServiceInterface;
using ShopTARge22.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopTARge22.ApplicationServices.Services
{
    public class KindergartensServices : IKindergartensServices
    {
        private readonly ShopTARge22Context _context;
        private readonly IKindergartensServices _services;

        public KindergartensServices
            (
                ShopTARge22Context context,
                IKindergartensServices services
            )
        { 
            _context = context;
            _services = services;
        }

        public async Task<Kindergarten> Create(KindergartenDTO dto) 
        {
            Kindergarten kindergarten = new Kindergarten();

            kindergarten.Id = Guid.NewGuid();
            kindergarten.GroupName = dto.GroupName;
            kindergarten.ChildrenCount = dto.ChildrenCount;
            kindergarten.KindergartenName = dto.KindergartenName;
            kindergarten.Teacher = dto.Teacher;
            kindergarten.CreatedAt = dto.CreatedAt;
            kindergarten.ModifiedAt = dto.ModifiedAt;

            await _context.Kindergartens.AddAsync(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }

        public async Task<Kindergarten> DetailsAsync(Guid id)
        { 
            var result = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Kindergarten> Update(KindergartenDTO dto)
        {
            Kindergarten kindergarten = new Kindergarten();

            kindergarten.Id = Guid.NewGuid();
            kindergarten.GroupName = dto.GroupName;
            kindergarten.ChildrenCount = dto.ChildrenCount;
            kindergarten.KindergartenName = dto.KindergartenName;
            kindergarten.Teacher = dto.Teacher;
            kindergarten.CreatedAt = dto.CreatedAt;
            kindergarten.ModifiedAt = dto.ModifiedAt;

            _context.Kindergartens.Update(kindergarten);
            await _context.SaveChangesAsync();

            return kindergarten;
        }

        public async Task<Kindergarten> Delete(Guid id)
        { 
            var kindergartenId = await _context.Kindergartens
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Kindergartens.Remove(kindergartenId);
            await _context.SaveChangesAsync();

            return kindergartenId;
        }
    }
}
