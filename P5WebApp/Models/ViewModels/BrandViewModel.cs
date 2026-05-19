using Humanizer.Localisation;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.FileProviders.Embedded;



namespace P5WebApp.Models.ViewModels
{
    public class BrandViewModel
    {
        [BindNever]
        public int BrandId { get; set; }

        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingBrandName")]
        public string? BrandName { get; set; }

        public virtual ICollection<Model>? Models { get; set; } = [];
    }
}