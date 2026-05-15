using Microsoft.AspNetCore.Antiforgery;
using static P5WebApp.Models.Entities.Brand;

namespace P5WebApp.Models.Entities
{
    public partial class Brand : Vehicle
    {
        public int BrandId { get; set; }
        public string? BrandDescription { get; set; }

        public virtual ICollection<Model> ?Models { get; set; } = [];

        // Foreign Key
        public int AssociatedVehicleId { get; set; }
        public virtual Vehicle? AssociatedVehicle { get; set; }
    }
}
