using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.FileProviders.Embedded;
using P5WebApp.Models.Entities;

namespace P5WebApp.Models.ViewModels
{
    public class CarModelViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner le nom du modèle")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Veuillez choisir une marque")]
        public int AssociatedBrandId { get; set; }

        public List <Brand> Brands { get; set; } = new List<Brand>();


        public virtual ICollection<FinishType>? FinishTypes { get; set; } = new List<FinishType>();

    }
}
