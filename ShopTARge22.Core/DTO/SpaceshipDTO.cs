using Microsoft.AspNetCore.Http;

namespace ShopTARge22.Core.DTO
{
    public class SpaceshipDTO
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime BuiltDate { get; set; }
        public int Passengers { get; set; }
        public int CargoWeight { get; set; }
        public int Crew { get; set; }
        public int EnginePower { get; set; }

        public List<IFormFile> Files { get; set; }
        public IEnumerable<FileToApiDTO> FiletoApiDTOs { get; set; } = new List<FileToApiDTO>();

        // Only in database
        public DateTime CreatedAt { get; set; }
        public DateTime LastModifiedAt { get; set; }
    }
}
