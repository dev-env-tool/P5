using Microsoft.Extensions.FileProviders.Embedded;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public required string Name { get; set; }

        [Required]
        public required string Password { get; set; }

        public string ReturnUrl { get; set; } = "/";
    }
}
