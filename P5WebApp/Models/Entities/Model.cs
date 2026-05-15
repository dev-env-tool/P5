using static P5WebApp.Models.Entities.Photo;

namespace P5WebApp.Models.Entities
{
    public class Model : Vehicle
    {

        public int Id { get; set; }
        public string? Name { get; set; }

        public int BrandId { get; set; }
        public virtual Brand ?AssociatedBrand { get; set; }

        // Foreign Key
        public int AssociatedVehicleId { get; set; }
        public virtual Vehicle? AssociatedVehicle { get; set; }

    }
}
