using Microsoft.EntityFrameworkCore;
using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5WebApp.Models.Repositories
{
    public interface IPhotoRepository
    {
        IEnumerable<Photo> GetAllPhotos();

        int GetMaxPhotoId();

        void UpdatePhoto(Photo Photo);
        void SavePhoto(Photo Photo);
        void DeletePhoto(int id);
        Task<Photo> GetPhoto(int id);
        Task<IList<Photo>> GetPhoto();
    }
}


