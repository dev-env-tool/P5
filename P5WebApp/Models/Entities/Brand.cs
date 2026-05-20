using Microsoft.AspNetCore.Antiforgery;


namespace P5WebApp.Models.Entities
{
    public class Brand : Car
    {
        public required int BrandId { get; set; }
        public required string BrandName { get; set; }

        public required virtual ICollection<CarModel> ?CarModels { get; set; } = [];
    }
}
