using Microsoft.AspNetCore.Mvc.ModelBinding;
using Humanizer.Localisation;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.FileProviders.Embedded;

namespace P5WebApp.Models.ViewModels
{
    public class FinishTypeViewModel
    {
        [BindNever]
        public required int? FinishTypeId { get; set; }

        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingFinishTypeName")]
        public required string? FinishTypeName { get; set; }

    }
}
