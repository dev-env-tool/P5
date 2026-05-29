using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5WebApp.Models.Repositories
{
    public interface IBrandRepository
    {
        IEnumerable<Brand> GetAllBrands();

        int GetMaxBrandId();
        void SaveBrand(Brand Brand);
        void DeleteBrand(int id);
        Task<Brand> GetBrand(int id);
        Task<IList<Brand>> GetBrand();
    }
}


