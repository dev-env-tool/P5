using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.FileProviders.Embedded;
using P5WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class FixViewModel
    {
        [BindNever]
        public int FixId { get; set; }

        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingFixDescription")]
        public string? FixDescription { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingFixDate")]
        public DateOnly FixDate { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingFixCost")]
        public double FixCost { get; set; }



        // Foreign Key
        [BindNever]
        public int? AssociatedVehicleId { get; set; }

        [BindNever]
        public virtual Vehicle? AssociatedVehicle { get; set; }

    }
}
