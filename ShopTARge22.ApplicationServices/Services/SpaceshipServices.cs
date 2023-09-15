﻿using Microsoft.EntityFrameworkCore;
using ShopTARge22.Core.Domain;
using ShopTARge22.Core.DTO;
using ShopTARge22.Data;
using ShopTARge222.Core.ServiceInterface;

namespace ShopTARge22.ApplicationServices.Services
{
    public class SpaceshipsServices : ISpaceshipsServices
    {
        private readonly ShopTARge22Context _context;

        public SpaceshipsServices
            (
                ShopTARge22Context context
            )
        {
            _context = context;
        }


        public async Task<Spaceship> Create(SpaceshipDTO dto)
        {
            Spaceship spaceship = new Spaceship();

            spaceship.Id = Guid.NewGuid();
            spaceship.Name = dto.Name;
            spaceship.Type = dto.Type;
            spaceship.BuiltDate = dto.BuiltDate;
            spaceship.Passengers = dto.Passengers;
            spaceship.CargoWeight = dto.CargoWeight;
            spaceship.Crew = dto.Crew;
            spaceship.EnginePower = dto.EnginePower;
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            await _context.Spaceships.AddAsync(spaceship);
            await _context.SaveChangesAsync();

            return spaceship;
        }

        public async Task<Spaceship> DetailsAsync(Guid id)
        {
            var result = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceshipId = await _context.Spaceships
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Spaceships.Remove(spaceshipId);
            await _context.SaveChangesAsync();

            return spaceshipId;
        }

        public async Task<Spaceship> Update(SpaceshipDTO dto)
        {
            Id = dto.Id,
            Name = dto.Name,
            Type = dto.Type,
            BuiltDate = dto.BuiltDate,
            Passengers = dto.Passengers,
            CargoWeight = dto.CargoWeight,
            Crew = dto.Crew,
            EnginePower = dto.EnginePower,
            CreatedAt = dto.CreatedAt,
            ModifiedAt = DateTime.Now
        };

        _context.Spaceships

    }
}