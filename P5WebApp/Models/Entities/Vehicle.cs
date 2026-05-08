namespace P5WebApp.Models.Entities
{
    public partial class Vehicle
    {
        public int VehicleId { get; set; }

        public string? VehicleVinCode { get; set; }

        public DateOnly VehicleYear { get; set; }

        public DateOnly VehicleBuyDate { get; set; }

        public double VehicleBuyPrice { get; set; }

        public int VehicleBrandId { get; set; }

        public int VehicleModelId { get; set; }


        public string? VehicleFinishTypeId { get; set; }


        public int VehicleFixId { get; set; }
    }
}
