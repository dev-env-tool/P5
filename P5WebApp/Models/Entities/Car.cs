using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace P5WebApp.Models.Entities
{
    public class Car : Vehicle
    {
        // Foreign Key
        public int AssociatedVehicleId { get; set; }
        public Vehicle ?Vehicle { get; set; }
    }
}
