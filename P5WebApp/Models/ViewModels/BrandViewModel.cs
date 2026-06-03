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
        public int BrandId { get; set; }

        [Required(ErrorMessage ="Veuillez renseigner un nom de marque")]
        public required string? BrandName { get; set; }

        public virtual ICollection<CarModel>? CarModels { get; set; } = new List<CarModel>();
    }
}