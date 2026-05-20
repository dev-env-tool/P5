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



        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingAssociatedCarModelId")]
        public required int AssociatedCarModelId { get; set; }

        public required virtual CarModel AssociatedCarModel { get; set; }



        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingAssociatedBrandlId")]
        public required int AssociatedBrandlId { get; set; }

        public required virtual Brand AssociatedBrand { get; set; }



    }
}
