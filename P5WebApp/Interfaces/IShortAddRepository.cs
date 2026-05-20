using Microsoft.CodeAnalysis;
using P5WebApp.Models.Entities;

namespace P5WebApp.Interfaces
{
    public interface IShortAddRepository
    {
        Task<ShortAdd> GetShortAdd(int id);
        Task<Car> GetAssociatedCar(int id);
        IEnumerable<ShortAdd> GetAllShortAdds();
        Task<IList<ShortAdd>> GetShortAddList();
        IEnumerable<Photo> GetPhotosOfShortAdd(int id);
        void SaveShortAdd(ShortAdd add);
        void DeleteShortAdd(int id);

    }
}
