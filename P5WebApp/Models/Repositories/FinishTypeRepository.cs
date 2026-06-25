using Microsoft.Build.Evaluation;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using P5WebApp.Data;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Services;
using P5WebApp.Models.ViewModels;
using System.Linq;

namespace P5WebApp.Models.Repositories
{
    public class FinishTypeRepository : IFinishTypeRepository
    {
        private static P5Referential? _context;

        public FinishTypeRepository(P5Referential context)
        {
            _context = context;
        }

        public IEnumerable<FinishType> GetAllFinishTypes()
        {
            IEnumerable<FinishType> FinishTypes = _context.FinishTypes.Where(f => f.FinishTypeId >= 0);
            return FinishTypes.ToList();
        }


        public int GetMaxFinishTypeId()
        {
            int maxFinishTypeId;

            if (!_context.FinishTypes.Any())
            {
                return maxFinishTypeId = 0;
            }
            else
            {
                return maxFinishTypeId = _context.FinishTypes.Max(f => f.FinishTypeId);
            }
        }

        public IEnumerable<FinishType> GetFinishTypesByCarModelIds(int id)
        {
            if (id == null)
                return Enumerable.Empty<FinishType>();


            var selectedFinishTypes = GetAllFinishTypesWithoutFilter()
                .Where(f => f.AssociatedCarModelIds.Contains(id))
                .ToList();

            return (selectedFinishTypes);
        }

        public IEnumerable<FinishType> GetAllFinishTypesWithoutFilter()
        {
            IEnumerable<FinishType> FinishTypes = _context.FinishTypes;
            return FinishTypes.ToList();
        }

        public void UpdateFinishType(FinishType FinishType)
        {
            if (FinishType != null)
            {
                _context.Entry(FinishType).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void SaveFinishType(FinishType FinishType)
        {
            if (FinishType != null)
            {
                _context!.FinishTypes.Add(FinishType);
                _context.SaveChanges();
            }
        }


        public void DeleteFinishType(int id)
        {
            FinishType FinishType = _context!.FinishTypes.First(f => f.FinishTypeId == id);
            if (FinishType != null)
            {
                _context!.FinishTypes.Remove(FinishType);
                _context.SaveChanges();
            }
        }

        public async Task<FinishType> GetFinishType(int id)
        {
            var FinishType = await _context.FinishTypes.SingleOrDefaultAsync(f => f.FinishTypeId  == id);
            return FinishType;
        }

        public async Task<IList<FinishType>> GetFinishType()
        {
            var FinishTypes = await _context.FinishTypes.ToListAsync();
            return FinishTypes;
        }


    }
}
