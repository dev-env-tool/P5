using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using P5WebApp.Data;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Services;
using P5WebApp.Models.ViewModels;

namespace P5WebApp.Models.Repositories
{
    public class CarRepository : ICarRepository
    {
        private static P5Referential? _context;

        public CarRepository(P5Referential context)
        {
            _context = context;
        }

        public IEnumerable<Car> GetAllCars()
        {
            IEnumerable<Car> Cars = _context.Cars.Where(c => c.CarId >= 0);
            return Cars.ToList();
        }


        public int GetMaxCarId()
        {
            int maxCarId;

            if (!_context.Cars.Any())
            {
                return maxCarId = 0;
            }
            else
            {
                return maxCarId = _context.Cars.Max(c => c.CarId);
            }
        }


        public void UpdateCar(Car Car)
        {
            if (Car != null)
            {
                _context.Entry(Car).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void SaveCar(Car Car)
        {
            if (Car != null)
            {
                _context!.Cars.Add(Car);
                _context.SaveChanges();
            }
        }


        public void DeleteCar(int id)
        {
            Car Car = _context!.Cars.First(c => c.CarId == id);
            if (Car != null)
            {
                _context!.Cars.Remove(Car);
                _context.SaveChanges();
            }
        }

        public async Task<Car> GetCar(int id)
        {
            var Car = await _context.Cars.SingleOrDefaultAsync(c => c.CarId  == id);
            return Car;
        }

        public async Task<IList<Car>> GetCar()
        {
            var Cars = await _context.Cars.ToListAsync();
            return Cars;
        }


    }
}
