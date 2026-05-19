using Microsoft.AspNetCore.Antiforgery;
using static P5WebApp.Models.Entities.Brand;

namespace P5WebApp.Models.Entities
{
    public class Brand : Vehicle
    {
        public int BrandId { get; set; }
        public string? BrandName { get; set; }

        public virtual ICollection<Model> ?Models { get; set; } = [];

    }
}
