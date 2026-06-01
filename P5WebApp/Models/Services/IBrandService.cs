using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;

namespace P5WebApp.Models.Services
{
    public interface IBrandService
    {
        List<Brand> GetAllBrands();
        List<BrandViewModel> GetAllBrandsViewModel();
        Brand GetBrandById(int id);
        BrandViewModel GetBrandByIdViewModel(int id);

        Dictionary<string, string> CheckBrandModelErrors(BrandViewModel product);

        void UpdateBrand(BrandViewModel brand);
        void SaveBrand(BrandViewModel Brand);
        void DeleteBrand(int id);

        Task<Brand> GetBrand(int id);
        Task<IList<Brand>> GetBrand();

    }
}