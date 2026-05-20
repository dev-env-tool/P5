using Microsoft.AspNetCore.Antiforgery;


namespace P5WebApp.Models.Entities
{
    public class Brand : Car
    {
        public int BrandId { get; set; }
        public string? BrandName { get; set; }

        public virtual ICollection<Model> ?Models { get; set; } = [];
    }
}
