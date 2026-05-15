namespace P5WebApp.Models.Entities
{
    public class FinishType : Vehicle
    {
        public string? FinishTypeId { get; set; }

        public string? FinishTypeName { get; set; }

        // Foreign Key
        public int AssociatedVehicleId { get; set; }
        public virtual Vehicle? AssociatedVehicle { get; set; }
    }
}
