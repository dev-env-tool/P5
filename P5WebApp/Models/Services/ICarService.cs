using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;

namespace P5WebApp.Models.Services
{
    public interface ICarService
    {
        List<Car> GetAllCars();
        List<CarViewModel> GetAllCarViewModel();
        Car GetCarById(int id);
        CarViewModel GetCarByIdViewModel(int id);
        void UpdateCarInfos();
        void SaveCar(CarViewModel Car);
        void DeleteCar(int id);

        /// <summary>
        /// Use of a dictionnary to ease ModelState tests.
        /// </summary >
        Dictionary<string, string> CheckCarModelErrors(CarViewModel Car);


        Task<Car> GetCar(int id);
        Task<IList<Car>> GetCar();

    }
}
