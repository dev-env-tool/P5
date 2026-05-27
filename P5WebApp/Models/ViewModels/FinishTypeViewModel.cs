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

        [Required]
        public required string? FinishTypeName { get; set; }



        [Required]

        public required virtual ICollection<CarModel>? CarModels { get; set; } = new List<CarModel>();


        [Required]

        public required virtual ICollection<Brand>? Brands { get; set; } = new List<Brand>();

    }
}
