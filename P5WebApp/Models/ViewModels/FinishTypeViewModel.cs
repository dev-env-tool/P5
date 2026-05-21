using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileProviders.Embedded;
using P5WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class FinishTypeViewModel
    {
        [BindNever]
        public required int? FinishTypeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingFinishTypeName")]
        public required string? FinishTypeName { get; set; }




        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingAssociatedCarId")]
        public required int AssociatedCarId { get; set; }

        public required virtual Car AssociatedCar { get; set; }




        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingAssociatedCarModelId")]
        public required int AssociatedCarModelId { get; set; }

        public required virtual CarModel AssociatedCarModel { get; set; }

        public required virtual ICollection<CarModel>? CarModels { get; set; } = [];



        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingAssociatedBrandId")]
        public required int AssociatedBrandId { get; set; }

        public required virtual Brand AssociatedBrand { get; set; }

        public required virtual ICollection<Brand>? Brands { get; set; } = [];

    }
}
