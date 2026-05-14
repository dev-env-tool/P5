using Microsoft.AspNetCore.Antiforgery;
using static P5WebApp.Models.Entities.Brand;

namespace P5WebApp.Models.Entities
{
    public partial class Brand : Vehicle
    {
        public int BrandId { get; set; }
        public string? BrandDescription { get; set; }

        public class BrandList
        { 
            ICollection<Brand>? BrandListForVehicle { get; set; }
        }

        public ICollection<Model.BrandModel>? BrandAndModelListForVehicle { get; set; }
    }
}
