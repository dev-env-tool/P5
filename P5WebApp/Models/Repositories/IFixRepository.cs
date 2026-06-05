using Microsoft.EntityFrameworkCore;
using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5WebApp.Models.Repositories
{
    public interface IFixRepository
    {
        IEnumerable<Fix> GetAllFixes();

        int GetMaxFixId();

        void UpdateFix(Fix Fix);
        void SaveFix(Fix Fix);
        void DeleteFix(int id);
        Task<Fix> GetFix(int id);
        Task<IList<Fix>> GetFix();
    }
}


