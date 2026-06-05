using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;

namespace P5WebApp.Models.Services
{
    public interface IFixService
    {
        List<Fix> GetAllFixes();
        List<FixViewModel> GetAllFixesViewModel();
        Fix GetFixById(int id);
        FixViewModel GetFixByIdViewModel(int id);

        Dictionary<string, string> CheckFixModelErrors(FixViewModel product);

        void UpdateFixInfos(FixViewModel Fix);
        void SaveFix(FixViewModel Fix);
        void DeleteFix(int id);

        Task<Fix> GetFix(int id);
        Task<IList<Fix>> GetFix();

    }
}