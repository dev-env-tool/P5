using Microsoft.AspNetCore.Antiforgery;


namespace P5WebApp.Models.Entities
{
    public class Brand
    {
        public int BrandId { get; set; }
        public required string BrandName { get; set; }

        public virtual ICollection<CarModel> ?CarModels { get; set; } = new List<CarModel>();


        // For many to many relationship, not used in BrandViewModel
        public virtual ICollection<FinishType> ?FinishTypes { get; set; } = new List<FinishType>();
    }
}
