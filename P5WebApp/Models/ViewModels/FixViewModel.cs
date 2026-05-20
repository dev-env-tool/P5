using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.FileProviders.Embedded;
using P5WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class FixViewModel
    {
        [BindNever]
        public required int FixId { get; set; }

        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingFixDescription")]
        public required string FixDescription { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingFixDate")]
        public required DateOnly FixDate { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingFixCost")]
        public required double FixCost { get; set; }



        // Foreign Key
        [BindNever]
        public required int AssociatedCarId { get; set; }

        [BindNever]
        public required virtual Car AssociatedCar { get; set; }

    }
}
