using P5WebApp.Models.Entities;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.ViewModels;
using System.Globalization;

namespace P5WebApp.Models.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository ?_brandRepository;

        public BrandService(IBrandRepository brandRepository) 
        {
            _brandRepository = brandRepository;
        }

        public List<Brand> GetAllBrands()
        {
            IEnumerable<Brand> brandEntities = _brandRepository.GetAllBrands();
            return brandEntities.ToList();
        }

        public List<BrandViewModel> GetAllBrandsViewModel()
        {

            IEnumerable<Brand> brandEntities = GetAllBrands();
            return MapToViewModel(brandEntities);
        }


        private static List<BrandViewModel> MapToViewModel(IEnumerable<Brand> brandEntities)
        {
            List<BrandViewModel> brands = new List<BrandViewModel>();
            foreach (Brand brand in brandEntities)
            {
                brands.Add(new BrandViewModel
                {
                    BrandId = brand.BrandId,
                    BrandName = brand.BrandName
                });
            }

            return brands;
        }


        public Brand GetBrandById(int id)
        {
            List<Brand> brands = GetAllBrands().ToList();
            return brands.Find(b => b.BrandId == id);
        }


        public BrandViewModel GetBrandByIdViewModel(int id)
        {
            List<BrandViewModel> brands = GetAllBrandsViewModel().ToList();
            return brands.Find(b => b.BrandId == id);
        }

        //public void UpdateBrandInfos()
        //{
        //    Brand brand = (Cart)_cart;
        //    foreach (CartLine line in cart.Lines)
        //    {
        //        _BrandRepository.UpdateBrandStocks(line.Brand.Id, line.Quantity);
        //    }
        //}

       

        public void SaveBrand(BrandViewModel brand)
        {
            var brandToAdd = MapToBrandEntity(brand);
            _brandRepository.SaveBrand(brandToAdd);
        }


        private static Brand MapToBrandEntity(BrandViewModel brand)
        {
            Brand brandEntity = new Brand
            {
                BrandId = brand.BrandId,
                BrandName = brand.BrandName,
            };
            return brandEntity;
        }


        public void DeleteBrand(int id)
        {
            _brandRepository.DeleteBrand(id);
        }

        public async Task<Brand> GetBrand(int id)
        {
            var brand = await _brandRepository.GetBrand(id);
            return brand;
        }

        public async Task<IList<Brand>> GetBrand()
        {
            var brands = await _brandRepository.GetBrand();
            return brands;
        }

    }
}
