using Microsoft.AspNetCore.Mvc.ModelBinding;
using P5WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.FileProviders.Embedded;


namespace P5WebApp.Models.ViewModels
{
    public class PhotoViewModel
    {
        // Input fields of Photo class
        public int PhotoId { get; set; }

        [Required]
        public string PhotoName { get; set; }

        [Required]
        public string PhotoPath { get; set; }

        // Foreign Key
        [Required]
        public int AssociatedCarId { get; set; }

    }
}
