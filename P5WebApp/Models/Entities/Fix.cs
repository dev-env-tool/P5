using static P5WebApp.Models.Entities.Photo;

namespace P5WebApp.Models.Entities
{
    public class Fix : Vehicle
    {

        // Input fields of Fix class

        public int FixId { get; set; }

        public string? FixDescription { get; set; }

        public DateOnly FixDate { get; set; }

        public double FixCost { get; set; }

        // Foreign Key
        public int ?AssociatedVehicleId { get; set; }

        public virtual Vehicle ?AssociatedVehicle { get; set; }
    }
}
