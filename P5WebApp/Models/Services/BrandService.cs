using Microsoft.EntityFrameworkCore;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace P5WebApp.Models.Services
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository ?_brandRepository;
        private readonly ICarModelRepository ?_carModelRepository;
        

        public BrandService(IBrandRepository brandRepository, ICarModelRepository carModelRepository) 
        {
            _brandRepository = brandRepository;
            _carModelRepository = carModelRepository;
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
            var brandToReturn = brands.Find(b => b.BrandId == id);
            return brandToReturn;
        }



        public Dictionary<string, string> CheckBrandModelErrors(BrandViewModel brand)
        {
            /// <summary>
            /// Use of a dictionnary to ease ModelState tests.
            /// [Key ,Value]
            /// [Key = Value = "ErrorMessageName" ]
            /// </summary >
            Dictionary<string, string> modelErrors = new Dictionary<string, string>();


            /// <summary>
            /// Declaration of the same ProductViewModel RegularExpression attributes
            /// to run server side attribute validation.
            /// </summary >
            var Attribute1 = new RequiredAttribute();

            if (!Attribute1.IsValid(brand.BrandName))
            {
                modelErrors.Add("", "Veuillez renseigner un nom de marque");
            }



            return modelErrors;
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

        public void UpdateBrand(BrandViewModel brand)
        {

            var brandToEdit = GetBrandById(brand.BrandId);
   
            brandToEdit.BrandName = brand.BrandName;

            _brandRepository.UpdateBrand(brandToEdit);

        }

        public void SaveBrand(BrandViewModel brand)
        {
            var brandToAdd = MapToBrandEntity(brand);
            _brandRepository.SaveBrand(brandToAdd);
        }



        private Brand MapToBrandEntity(BrandViewModel brand)
        {

            Brand brandEntity = new Brand
            {
                BrandName = brand.BrandName,
            };
            return brandEntity;
        }


        public void DeleteBrand(int id)
        {
            int numberofTimesbrandUsed = _carModelRepository.GetAllCarModels().Where(c => c.AssociatedBrandId == id).Count();

            if (numberofTimesbrandUsed > 0)
            {
            }
            else 
            {
                _brandRepository.DeleteBrand(id);
            }
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
