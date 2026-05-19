using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.FileProviders.Embedded;
using P5WebApp.Models.Entities;

namespace P5WebApp.Models.ViewModels
{
    public class ModelViewModel
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingModelName")]
        public string? Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingAsociatedBrandId")]
        public int AsociatedBrandId { get; set; }
        public virtual Brand ?AssociatedBrand { get; set; }

    }
}
