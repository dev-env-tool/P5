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
    public class BrandRepository : IBrandRepository
    {
        private static P5Referential? _context;

        public BrandRepository(P5Referential context)
        {
            _context = context;
        }

        public IEnumerable<Brand> GetAllBrands()
        {
            IEnumerable<Brand> Brands = _context.Brands.Where(b => b.BrandId >= 0);
            return Brands.ToList();
        }


        public int GetMaxBrandId()
        {
            int MaxBrandId;

            if (!_context.Brands.Any())
            {
                return MaxBrandId = 0;
            }
            else
            {
                return MaxBrandId = _context.Brands.Max(i => i.BrandId);
            }
        }


        public void UpdateBrand(Brand Brand)
        {
            if (Brand != null)
            {
                _context.Entry(Brand).State = EntityState.Modified;
                _context.SaveChanges();
            }
        }

        public void SaveBrand(Brand Brand)
        {
            if (Brand != null)
            {
                _context!.Brands.Add(Brand);
                _context.SaveChanges();
            }
        }


        public void DeleteBrand(int id)
        {
            Brand Brand = _context!.Brands.First(s => s.BrandId == id);
            if (Brand != null)
            {
                _context!.Brands.Remove(Brand);
                _context.SaveChanges();
            }
        }

        public async Task<Brand> GetBrand(int id)
        {
            var Brand = await _context.Brands.SingleOrDefaultAsync(b => b.BrandId == id);
            return Brand;
        }

        public async Task<IList<Brand>> GetBrand()
        {
            var Brands = await _context.Brands.ToListAsync();
            return Brands;
        }


    }
}
