using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;

namespace P5WebApp.Models.Services
{
    public interface IFinishTypeService
    {
        List<FinishType> GetAllFinishTypes();
        List<FinishTypeViewModel> GetAllFinishTypesViewModel();
        FinishType GetFinishTypeById(int id);
        FinishTypeViewModel GetFinishTypeByIdViewModel(int id);

        Dictionary<string, string> CheckFinishTypeModelErrors(FinishTypeViewModel product);

        void UpdateFinishType(FinishTypeViewModel FinishType);
        void SaveFinishType(FinishTypeViewModel FinishType);
        void DeleteFinishType(int id);

        Task<FinishType> GetFinishType(int id);
        Task<IList<FinishType>> GetFinishType();

    }
}