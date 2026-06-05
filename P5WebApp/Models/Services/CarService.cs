using Microsoft.EntityFrameworkCore;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace P5WebApp.Models.Services
{
    public class CarService : ICarService
    {
        private readonly ICarRepository ?_carRepository;

        public CarService(ICarRepository carRepository) 
        {
            _carRepository = carRepository;
        }

        public List<Car> GetAllCars()
        {
            IEnumerable<Car> CarEntities = _carRepository.GetAllCars();
            return CarEntities.ToList();
        }

        public List<CarViewModel> GetAllCarsViewModel()
        {

            IEnumerable<Car> CarEntities = GetAllCars();
            return MapToViewModel(CarEntities);
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
                    CarFixesList = Car.CarFixesList,

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
            CarToEdit.CarFixesList = Car.CarFixesList;

            _carRepository.UpdateCar(CarToEdit);

        }

        public void SaveCar(CarViewModel Car)
        {
            var CarToAdd = MapToCarEntity(Car);
            _carRepository.SaveCar(CarToAdd);
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
                CarFixesList = Car.CarFixesList,
               
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
