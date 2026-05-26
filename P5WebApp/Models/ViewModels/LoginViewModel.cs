using Microsoft.Extensions.FileProviders.Embedded;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingLoginName")]
        public required string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingLoginPassword")]
        public required string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
