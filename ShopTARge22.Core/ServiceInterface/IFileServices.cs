using ShopTARge22.Core.Domain;
using ShopTARge22.Core.DTO;

namespace ShopTARge22.Core.ServiceInterface
{
    public interface IFileServices
    {
        void FilesToApi(SpaceshipDTO dto, Spaceship spaceship);

        Task<List<FileToApi>> RemoveImagesFromApi(FileToApiDTO[] dtos);

        void UploadFilesToDatabase(RealEstateDTO dto, RealEstate domain);

        Task<FileToDatabase> RemoveFilesFromDatabase(FileToDatabaseDTO dto);
       
    }
}
