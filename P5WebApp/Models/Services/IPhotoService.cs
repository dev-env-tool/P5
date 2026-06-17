using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;

namespace P5WebApp.Models.Services
{
    public interface IPhotoService
    {
        List<Photo> GetAllPhotos();
        List<PhotoViewModel> GetAllPhotosViewModel();
        Photo GetPhotoById(int id);
        PhotoViewModel GetPhotoByIdViewModel(int id);

        Dictionary<string, string> CheckPhotoModelErrors(PhotoViewModel photo);

        void UpdatePhoto(PhotoViewModel photo);
        void SavePhoto(PhotoViewModel photo);
        void DeletePhoto(int id);

        Task<Photo> GetPhoto(int id);
        Task<IList<Photo>> GetPhoto();

    }
}