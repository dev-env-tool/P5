using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.FileProviders.Embedded;
using P5WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class VehicleViewModel
    {
        [BindNever]
        public int VehicleId { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingVehicleVinCode")]
        public string? VehicleVinCode { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingVehicleYear")]
        public DateOnly VehicleYear { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingVehicleBuyDate")]
        public DateOnly VehicleBuyDate { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingVehicleBuyPrice")]
        public double VehicleBuyPrice { get; set; }

        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingVehicleBrandId")]
        public int VehicleBrandId { get; set; }


        public virtual Brand? Brand { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingVehicleModelId")]
        public int VehicleModelId { get; set; }


        public virtual Model? Model { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingVehicleFinishTypeId")]
        public int? VehicleFinishTypeId { get; set; }


        public virtual FinishType? FinishType { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorEmptyVehicleFixesList")]
        public virtual ICollection<Fix>? VehicleFixesList { get; set; } = [];

    }
}
