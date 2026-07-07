using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using P5WebApp.Data;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Services;
using P5WebApp.Models.ViewModels;

namespace P5WebApp.Models.Repositories
{
    public class PhotoRepository : IPhotoRepository
    {
        private static P5Referential? _context;

        public PhotoRepository(P5Referential context)
        {
            _context = context;
        }

        public IEnumerable<Photo> GetAllPhotos()
        {
            IEnumerable<Photo> photos = _context.Photos.Where(b => b.PhotoId >= 0);
            return photos.ToList();
        }


        public int GetMaxPhotoId()
        {
            int maxPhotoId;

            if (!_context.Photos.Any())
            {
                return maxPhotoId = 0;
            }
            else
            {
                return maxPhotoId = _context.Photos.Max(i => i.PhotoId);
            }
        }


        public void UpdatePhoto(Photo photo)
        {
            if (photo != null)
            {
                _context.Entry(photo).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void SavePhoto(Photo photo)
        {
            if (photo != null)
            {
                _context!.Photos.Add(photo);
                _context.SaveChanges();
            }
        }


        public void DeletePhoto(int id)
        {
            Photo photo = _context!.Photos.First(s => s.PhotoId == id);
            if (photo != null)
            {
                _context!.Photos.Remove(photo);
                _context.SaveChanges();
            }
        }

        public async Task<Photo> GetPhoto(int id)
        {
            var photo = await _context.Photos.SingleOrDefaultAsync(b => b.PhotoId == id);
            return photo;
        }

        public async Task<IList<Photo>> GetPhoto()
        {
            var photos = await _context.Photos.ToListAsync();
            return photos;
        }


    }
}
