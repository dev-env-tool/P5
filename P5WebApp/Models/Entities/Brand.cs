using Microsoft.AspNetCore.Antiforgery;
using static P5WebApp.Models.Entities.Brand;

namespace P5WebApp.Models.Entities
{
    public class Brand : Vehicle
    {
        public int BrandId { get; set; }
        public string? BrandDescription { get; set; }

        public ICollection<Model> ?Models { get; set; } = [];

    }
}
