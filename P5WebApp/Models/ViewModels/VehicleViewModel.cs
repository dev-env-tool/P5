using P5WebApp.Models.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class VehicleViewModel
    {
        [BindNever]
        public int VehicleId { get; set; }

        [Required]
        public string? VehicleVinCode { get; set; }

        [Required]
        public DateOnly VehicleYear { get; set; }

        [Required]
        public DateOnly VehicleBuyDate { get; set; }

        [Required]
        public double VehicleBuyPrice { get; set; }

        [Required]
        public int VehicleBrandId { get; set; }

        [Required]
        public int VehicleModelId { get; set; }

        [Required]
        public string? VehicleFinishTypeId { get; set; }


        public virtual ICollection<Fix>? VehicleFixesList { get; set; }

    }
}
