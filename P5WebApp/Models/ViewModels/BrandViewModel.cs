using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.FileProviders.Embedded;
using P5WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;



namespace P5WebApp.Models.ViewModels
{
    public class BrandViewModel
    {
        [BindNever]
        public required int BrandId { get; set; }

        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingBrandName")]
        public required string? BrandName { get; set; }

        public virtual ICollection<CarModel>? CarModels { get; set; } = new List<CarModel>();
    }
}