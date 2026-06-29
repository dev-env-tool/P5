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
    public class FixRepository : IFixRepository
    {
        private readonly P5Referential? _context;

        public FixRepository(P5Referential context)
        {
            _context = context;
        }

        public IEnumerable<Fix> GetAllFixes()
        {
            IEnumerable<Fix> Fixs = _context.Fixes.Where(f => f.FixId >= 0);
            return Fixs.ToList();
        }


        public int GetMaxFixId()
        {
            int maxFixId;

            if (!_context.Fixes.Any())
            {
                return maxFixId = 0;
            }
            else
            {
                return maxFixId = _context.Fixes.Max(f => f.FixId);
            }
        }


        public void UpdateFix(Fix Fix)
        {
            if (Fix != null)
            {
                _context.Entry(Fix).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void SaveFix(Fix Fix)
        {
            if (Fix != null)
            {
                _context!.Fixes.Add(Fix);
                _context.SaveChanges();
            }
        }


        public void DeleteFix(int id)
        {
            Fix Fix = _context!.Fixes.First(f => f.FixId == id);
            if (Fix != null)
            {
                _context!.Fixes.Remove(Fix);
                _context.SaveChanges();
            }
        }

        public async Task<Fix> GetFix(int id)
        {
            var Fix = await _context.Fixes.SingleOrDefaultAsync(f => f.FixId  == id);
            return Fix;
        }

        public async Task<IList<Fix>> GetFix()
        {
            var Fixs = await _context.Fixes.ToListAsync();
            return Fixs;
        }


    }
}
