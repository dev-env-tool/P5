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
    public class CarModelRepository : ICarModelRepository
    {
        private static P5Referential? _context;

        public CarModelRepository(P5Referential context)
        {
            _context = context;
        }

        public IEnumerable<CarModel> GetAllCarModels()
        {
            IEnumerable<CarModel> CarModels = _context.CarModels.Where(c => c.Id >= 0);
            return CarModels.ToList();
        }


        public int GetMaxCarModelId()
        {
            int maxCarModelId;

            if (!_context.CarModels.Any())
            {
                return maxCarModelId = 0;
            }
            else
            {
                return maxCarModelId = _context.CarModels.Max(i => i.Id);
            }
        }


        public void UpdateCarModel(CarModel CarModel)
        {
            if (CarModel != null)
            {
                _context.Entry(CarModel).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void SaveCarModel(CarModel CarModel)
        {
            if (CarModel != null)
            {
                _context!.CarModels.Add(CarModel);
                _context.SaveChanges();
            }
        }


        public void DeleteCarModel(int id)
        {
            CarModel CarModel = _context!.CarModels.First(c => c.Id == id);
            if (CarModel != null)
            {
                _context!.CarModels.Remove(CarModel);
                _context.SaveChanges();
            }
        }

        public async Task<CarModel> GetCarModel(int id)
        {
            var CarModel = await _context.CarModels.SingleOrDefaultAsync(c => c.Id  == id);
            return CarModel;
        }

        public async Task<IList<CarModel>> GetCarModel()
        {
            var CarModels = await _context.CarModels.ToListAsync();
            return CarModels;
        }


    }
}
