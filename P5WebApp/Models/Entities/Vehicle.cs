using Microsoft.AspNetCore.Components.Web.Virtualization;
using System.Collections.Generic;
using static P5WebApp.Models.Entities.Fix;

namespace P5WebApp.Models.Entities
{
    public abstract class Vehicle
    {
        public int VehicleId { get; set; }

        public string? VehicleVinCode { get; set; }

        public DateOnly VehicleYear { get; set; }

        public DateOnly VehicleBuyDate { get; set; }

        public double VehicleBuyPrice { get; set; }

        public int VehicleBrandId { get; set; }

        public virtual Brand ?Brand { get; set; }

        public int VehicleModelId { get; set; }

        public virtual Model ?Model { get; set; }

        public int? VehicleFinishTypeId { get; set; }

        public virtual FinishType ?FinishType { get; set; }

        // Virtual couplings below to be able to override children parameters from parent class

        public virtual ICollection<Fix>? VehicleFixesList { get; set; } = [];


    }
}
