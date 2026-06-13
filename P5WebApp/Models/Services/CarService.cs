using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Runtime.ConstrainedExecution;

namespace P5WebApp.Models.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository ?_carRepository;
        private readonly ICarModelService? _carModelService;
        private readonly IBrandService? _brandService;
        public CarService(ICarRepository carRepository, ICarModelService carModelService, IBrandService brandService) 
        {
            _carRepository = carRepository;
            _carModelService = carModelService;
            _brandService = brandService;
        }

        public List<Car> GetAllCars()
        {
            IEnumerable<Car> CarEntities = _carRepository.GetAllCars();
            return CarEntities.ToList();
        }

        public string GetCarModelCarBrandAndYearNameByVinCode(string CarVinCode)
        {
            int carModelId = GetAllCars().Where(c => c.CarVinCode == CarVinCode).Select(c => c.CarModelId).FirstOrDefault();
            string carModelName = _carModelService.GetAllCarModels().Where(c => c.Id == carModelId).Select(c => c.Name).Single();


            int carBrandId = GetAllCars().Where(c => c.CarVinCode == CarVinCode).Select(c => c.CarBrandId).FirstOrDefault();
            string brandName = _brandService.GetAllBrands().Where(b => b.BrandId == carBrandId).Select(b => b.BrandName).Single();

            string carBrandYear = GetAllCars().Where(c => c.CarVinCode == CarVinCode).Select(c => c.CarYear).FirstOrDefault().ToString();


            return (carModelName + " " + brandName + " " + carBrandYear);
        }




        public List<CarViewModel> GetAllCarsViewModel()
        {

            IEnumerable<Car> CarEntities = GetAllCars();
            return MapToViewModel(CarEntities);
        }

        private static List<FixViewModel> MapFixesToViewModel(IEnumerable<Fix> CarFixes)
        {
            List<FixViewModel> fixes = new List<FixViewModel>();
            foreach (Fix fix in CarFixes)
                fixes.Add(new FixViewModel
                {
                    FixDescription = fix.FixDescription,
                    FixDate = fix.FixDate,
                    FixCost = fix.FixCost

                });

            return (fixes);
        }

        private static List<CarViewModel> MapToViewModel(IEnumerable<Car> CarEntities)
        {
            List<CarViewModel> Cars = new List<CarViewModel>();
            foreach (Car Car in CarEntities)
            {
                Cars.Add(new CarViewModel
                {
                    CarId = Car.CarId,
                    CarVinCode = Car.CarVinCode,
                    CarYear = Car.CarYear,
                    CarBuyDate = Car.CarBuyDate,
                    CarBuyPrice = Car.CarBuyPrice,
                    CarBrandId = Car.CarBrandId,
                    CarModelId = Car.CarModelId,
                    CarFinishTypeId = Car.CarFinishTypeId,
                    CarFixesViewModelList = MapFixesToViewModel(Car.CarFixesList),
                });
            }

            return Cars;
        }


        public Car GetCarById(int id)
        {
            List<Car> Cars = GetAllCars().ToList();
            var CarToReturn = Cars.Find(c => c.CarId == id);
            return CarToReturn;
        }



        public Dictionary<string, string> CheckCarModelErrors(CarViewModel Car)
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

            if (!Attribute1.IsValid(Car.CarVinCode))
            {
                modelErrors.Add("", "Veuillez renseigner un numéro d'immatriculation");
            }

            var Attribute2 = new RequiredAttribute();

            if (!Attribute2.IsValid(Car.CarYear))
            {
                modelErrors.Add("", "Veuillez renseigner une année de production");
            }

            var Attribute3 = new RequiredAttribute();

            if (!Attribute3.IsValid(Car.CarBuyDate))
            {
                modelErrors.Add("", "Veuillez renseigner une date d'achat");
            }

            var Attribute4 = new RequiredAttribute();

            if (!Attribute4.IsValid(Car.CarBuyPrice))
            {
                modelErrors.Add("", "Veuillez renseigner un prix d'achat");
            }

            var Attribute5 = new RequiredAttribute();

            if (!Attribute5.IsValid(Car.CarBrandId))
            {
                modelErrors.Add("", "Veuillez renseigner une marque");
            }

            var Attribute6 = new RequiredAttribute();

            if (!Attribute6.IsValid(Car.CarModelId))
            {
                modelErrors.Add("", "Veuillez renseigner un modèle");
            }


            var Attribute7 = new RequiredAttribute();

            if (!Attribute7.IsValid(Car.CarFinishTypeId))
            {
                modelErrors.Add("", "Veuillez renseigner une finition");
            }


            return modelErrors;
        }

        public CarViewModel GetCarByIdViewModel(int id)
        {
            List<CarViewModel> Cars = GetAllCarsViewModel().ToList();
            return Cars.Find(c => c.CarId == id);
        }


        public void UpdateCarInfos(CarViewModel Car)
        {

            var CarToEdit = GetCarById(Car.CarId);



            CarToEdit.CarVinCode = Car.CarVinCode;
            CarToEdit.CarYear = Car.CarYear ?? DateOnly.MinValue;
            CarToEdit.CarBuyDate = Car.CarBuyDate ?? DateOnly.MinValue;
            CarToEdit.CarBuyPrice = Car.CarBuyPrice;
            CarToEdit.CarBrandId = Car.CarBrandId;
            CarToEdit.CarModelId = Car.CarModelId;
            CarToEdit.CarFinishTypeId = Car.CarFinishTypeId;
            CarToEdit.CarFixesList = MapFixesViewModelToFixEntities(Car.CarFixesViewModelList);


            _carRepository.UpdateCar(CarToEdit);

        }

        public Car SaveCar(CarViewModel Car)
        {
            var CarToAdd = MapToCarEntity(Car);
            _carRepository.SaveCar(CarToAdd);
            return CarToAdd;
        }

        private static List<Fix> MapFixesViewModelToFixEntities(IEnumerable<FixViewModel> carFixViewModels)
        {
            List<Fix> fixes = new List<Fix>();

            if (carFixViewModels == null)
                return fixes;

            foreach (FixViewModel carFix in carFixViewModels)
            {
                fixes.Add(new Fix
                {
                    FixDescription = carFix.FixDescription,
                    FixDate = carFix.FixDate,
                    FixCost = carFix.FixCost
                });
            }

            return fixes;
        }

        private Car MapToCarEntity(CarViewModel Car)
        {

            Car CarEntity = new Car
            {
                CarVinCode = Car.CarVinCode,
                CarYear = Car.CarYear ?? DateOnly.MinValue,
                CarBuyDate = Car.CarBuyDate ?? DateOnly.MinValue,
                CarBuyPrice = Car.CarBuyPrice,
                CarBrandId = Car.CarBrandId,
                CarModelId = Car.CarModelId,
                CarFinishTypeId = Car.CarFinishTypeId,
                //AssociatedShortAddId = Car.AssociatedShortAddId,
                CarFixesList = MapFixesViewModelToFixEntities(Car.CarFixesViewModelList),
               
            };
            return CarEntity;
        }


        public void DeleteCar(int id)
        {
            _carRepository.DeleteCar(id);
        }

        public async Task<Car> GetCar(int id)
        {
            var Car = await _carRepository.GetCar(id);
            return Car;
        }

        public async Task<IList<Car>> GetCar()
        {
            var Cars = await _carRepository.GetCar();
            return Cars;
        }

    }
}
