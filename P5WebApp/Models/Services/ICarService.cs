using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;
using System.Data.Common;

namespace P5WebApp.Models.Services
{
    public interface ICarService
    {
        List<Car> GetAllCars();

        string GetCarModelCarBrandAndYearNameByVinCode(string CarVinCode);

        string GetCarModelCarBrandAndYearNameAndFinishTypeAndPhotoPathByCarId(int carId);
        List<CarViewModel> GetAllCarsViewModel();
        Car GetCarById(int id);
        CarViewModel GetCarByIdViewModel(int id);
        void UpdateCarInfos(CarViewModel Car);
        Car SaveCar(CarViewModel Car);
        void DeleteCar(int id);

        /// <summary>
        /// Use of a dictionnary to ease ModelState tests.
        /// </summary >
        Dictionary<string, string> CheckCarModelErrors(CarViewModel Car);


        Task<Car> GetCar(int id);
        Task<IList<Car>> GetCar();

        Task<DbTransaction> BeginTransaction();

    }
}
