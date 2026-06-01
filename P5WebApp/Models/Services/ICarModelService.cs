using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;

namespace P5WebApp.Models.Services
{
    public interface ICarModelService
    {
        List<CarModel> GetAllCarModels();
        List<CarModelViewModel> GetAllCarModelsViewModel();
        CarModel GetCarModelById(int id);
        CarModelViewModel GetCarModelByIdViewModel(int id);

        Dictionary<string, string> CheckCarModelModelErrors(CarModelViewModel product);

        void UpdateCarModel(CarModelViewModel CarModel);
        void SaveCarModel(CarModelViewModel CarModel);
        void DeleteCarModel(int id);

        Task<CarModel> GetCarModel(int id);
        Task<IList<CarModel>> GetCarModel();

    }
}