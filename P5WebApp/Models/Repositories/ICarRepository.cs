using Microsoft.EntityFrameworkCore;
using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5WebApp.Models.Repositories
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAllCars();

        int GetMaxCarId();

        void UpdateCar(Car Car);
        void SaveCar(Car Car);
        void DeleteCar(int id);
        Task<Car> GetCar(int id);
        Task<IList<Car>> GetCar();
    }
}


