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

        [Required(ErrorMessage = "Veuillez renseigner un nom de finition")]
        public string? FinishTypeName { get; set; }

        [Required(ErrorMessage = "Veuillez choisir au moins une marque associée")]
        public List<int>? AssociatedBrandsIds { get; set; } = new List<int>();

        [Required(ErrorMessage = "Veuillez choisir au moins un modèle associé")]
        public List<int>? AssociatedCarModelIds { get; set; } = new List<int>();

        public virtual ICollection<Brand>? Brands { get; set; } = new List<Brand>();
        public virtual ICollection<CarModel>? CarModels { get; set; } = new List<CarModel>();



    }
}
