using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using P5WebApp.Data;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Services;


namespace P5WebApp.Models.Repositories
{
    public class ShortAddRepository : IShortAddRepository
    {
        private static P5Referential? _context;

        public ShortAddRepository(P5Referential context)
        {
            _context = context;
        }


        public IEnumerable<ShortAdd> GetAllShortAdds()
        {
            IEnumerable<ShortAdd> shortAdds = _context!.ShortAdds.Where(s => s.ShortAddId >= 0);
            return shortAdds;
        }


        public int GetMaxShortAddId()
        {
            int maxShortAddId;

            if (!_context.ShortAdds.Any())
            {
                return maxShortAddId = 0;
            }
            else
            {
                return maxShortAddId = _context.ShortAdds.Max(c => c.ShortAddId);
            }
        }

        // Asynchronous task to retrieve an add from Db.
        public async Task<ShortAdd> GetShortAdd(int id)
        {
            var shortAdd = await _context!.ShortAdds.SingleOrDefaultAsync(s => s.ShortAddId == id);

            if (shortAdd == null)
            {
                throw new InvalidOperationException("The add requested does not exist");
            }
            else
            {
                return shortAdd;
            }

        }



        public async Task<IList<ShortAdd>> GetShortAddList()
        {
            var shortAdds = await _context!.ShortAdds.ToListAsync();
            return shortAdds;
        }

        // Asynchronous task to retrieve the associated photos from Db.
        public IEnumerable<Photo> GetAssociatedPhotosOfShortAdd(int id)
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
        public void UpdateShortAdd(ShortAdd ShortAdd)
        {
            if (ShortAdd != null)
            {
                _context.Entry(ShortAdd).State = EntityState.Modified;
                _context.SaveChanges();
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
            ShortAdd shortAdd = _context!.ShortAdds.First(s => s.ShortAddId == id);
            if (shortAdd != null)
            {
                _context!.ShortAdds.Remove(shortAdd);
                _context.SaveChanges();
            }
        }


        public async Task<IList<ShortAdd>> GetShortAdd()
        {
            var shortAdds = await _context.ShortAdds.ToListAsync();
            return shortAdds;
        }
    }
}
