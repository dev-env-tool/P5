using Microsoft.EntityFrameworkCore;
using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5WebApp.Models.Repositories
{
    public interface ICarModelRepository
    {
        IEnumerable<CarModel> GetAllCarModels();

        IEnumerable<CarModel> GetCarModelsByBrandIds(int[] ids);
        int GetMaxCarModelId();

        void UpdateCarModel(CarModel CarModel);
        void SaveCarModel(CarModel CarModel);
        void DeleteCarModel(int id);
        Task<CarModel> GetCarModel(int id);
        Task<IList<CarModel>> GetCarModel();
    }
}


