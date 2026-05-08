using Microsoft.AspNetCore.Antiforgery;

namespace P5WebApp.Models.Entities
{
    public partial class Brand : Vehicle
    {
        public int BrandId { get; set; }
        public string? BrandDescription { get; set; }
    }
}
