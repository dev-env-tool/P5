using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace P5WebApp.Models.Entities
{
    public class Car : Vehicle
    {
        public int CarId { get; set; }
        public string VehicleType { get; set; } = "Car";
        // Foreign Key
        public int AssociatedVehicleId { get; set; }
        public Vehicle ?AssociatedVehicle { get; set; }
    }
}


