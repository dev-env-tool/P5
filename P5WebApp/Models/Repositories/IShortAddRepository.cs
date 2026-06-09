using Microsoft.EntityFrameworkCore;
using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5WebApp.Models.Repositories
{
    public interface IShortAddRepository
    {
        IEnumerable<ShortAdd> GetAllShortAdds();

        int GetMaxShortAddId();

        void UpdateShortAdd(ShortAdd ShortAdd);
        void SaveShortAdd(ShortAdd ShortAdd);
        void DeleteShortAdd(int id);
        Task<ShortAdd> GetShortAdd(int id);
        Task<IList<ShortAdd>> GetShortAdd();
    }
}


