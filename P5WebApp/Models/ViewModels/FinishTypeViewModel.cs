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
        public int FinishTypeId { get; set; }

        [Required]
        public string? FinishTypeName { get; set; }

        [Required]
        public List<int>? AssociatedCarModelIds { get; set; } = new List<int>();

        [Required]
        public List<int>? AssociatedBrandsIds { get; set; } = new List<int>();

        public virtual ICollection<CarModel>? CarModels { get; set; } = new List<CarModel>();

        public virtual ICollection<Brand>? Brands { get; set; } = new List<Brand>();

    }
}
