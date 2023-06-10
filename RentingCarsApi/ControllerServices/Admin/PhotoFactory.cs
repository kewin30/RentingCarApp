using RentingCarsApi.Entity;
using RentingCarsApi.Exceptions;
using RentingCarsApi.Services;

namespace RentingCarsApi.ControllerServices.Admin
{
    public interface IPhotoFactory
    {
        Task<Photo> NewPhoto(IFormFile file);
    }
    public class PhotoFactory : IPhotoFactory
    {
        private readonly IPhotoService _photoService;

        public PhotoFactory(IPhotoService photoService)
        {
            _photoService = photoService;
        }
        public async Task<Photo> NewPhoto(IFormFile file)
        {
            var result = await _photoService.AddPhotoAsync(file);
            if (result.Error != null)
            {
                throw new BadRequestException(result.Error.Message);
            }
            Photo photo = new Photo
            {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId,
            };
            return photo;
        }
    }
}
