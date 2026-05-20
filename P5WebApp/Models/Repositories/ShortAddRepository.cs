using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using P5WebApp.Data;
using P5WebApp.Interfaces;
using P5WebApp.Models.Entities;


namespace P5WebApp.Models.Repositories
{
    public class ShortAddRepository : IShortAddRepository
    {
        private static P5Referential? _context;

        public ShortAddRepository(P5Referential context)
        {
            _context = context;
        }

        // Asynchronous task to retrieve an add from Db.
        public async Task<ShortAdd> GetShortAdd(int id)
        {
            var shortAdd = await _context!.ShortAdds.SingleOrDefaultAsync(s => s.Id == id);

            if (shortAdd == null)
            {
                throw new InvalidOperationException("The add requested does not exist");
            }
            else
            {
                return shortAdd;
            }

        }

        // Asynchronous task to retrieve the associated car from Db.
        public async Task<Car> GetAssociatedCar(int id)
        {
            var car = await _context!.Cars.SingleOrDefaultAsync(c => c.AssociatedShortAddId == id);

            if (car == null)
            {
                throw new InvalidOperationException("The car requested does not exist");
            }
            else
            {
                return car;
            }

        }

        public IEnumerable<ShortAdd> GetAllShortAdds()
        {
            IEnumerable<ShortAdd> shortAdds = _context!.ShortAdds.Where(s => s.Id >= 0);
            return shortAdds;
        }

        public async Task<IList<ShortAdd>> GetShortAddList()
        {
            var shortAdds = await _context!.ShortAdds.ToListAsync();
            return shortAdds;
        }

        // Asynchronous task to retrieve the associated photos from Db.
        public IEnumerable<Photo> GetPhotosOfShortAdd(int id)
        {
            IEnumerable<Photo> photos = _context!.Photos.Where(p => p.AssociatedShortAddId == id);
            if (photos == null)
            {
                throw new InvalidOperationException("The photos requested does not exist");
            }
            else
            {
                return photos;
            }
        }


        public void SaveShortAdd(ShortAdd shortAdd)
        {
            if (shortAdd != null)
            {
                _context!.ShortAdds.Add(shortAdd);
                _context.SaveChanges();
            }
        }


        public void DeleteShortAdd(int id)
        {
            ShortAdd shortAdd = _context!.ShortAdds.First(s => s.Id == id);
            if (shortAdd != null)
            {
                _context!.ShortAdds.Remove(shortAdd);
                _context.SaveChanges();
            }
        }
    }
}
