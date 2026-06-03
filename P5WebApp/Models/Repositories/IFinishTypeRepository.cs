using Microsoft.EntityFrameworkCore;
using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace P5WebApp.Models.Repositories
{
    public interface IFinishTypeRepository
    {
        IEnumerable<FinishType> GetAllFinishTypes();

        int GetMaxFinishTypeId();

        void UpdateFinishType(FinishType FinishType);
        void SaveFinishType(FinishType FinishType);
        void DeleteFinishType(int id);
        Task<FinishType> GetFinishType(int id);
        Task<IList<FinishType>> GetFinishType();
    }
}


