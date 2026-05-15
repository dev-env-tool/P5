using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.Collections.Generic;
using static P5WebApp.Models.Entities.Fix;

namespace P5WebApp.Models.Entities
{
    public partial class Vehicle
    {
        public int VehicleId { get; set; }

        public string? VehicleVinCode { get; set; }

        public DateOnly VehicleYear { get; set; }

        public DateOnly VehicleBuyDate { get; set; }

        public double VehicleBuyPrice { get; set; }

        public virtual int VehicleBrandId { get; set; }

        public virtual int VehicleModelId { get; set; }

        public virtual string? VehicleFinishTypeId { get; set; }

        public virtual ICollection<Fix>? VehicleFixesList { get; set; } = [];


    }
}
