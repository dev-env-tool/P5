using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.FileProviders.Embedded;
using P5WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class FixViewModel
    {
        public int FixId { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner la description de la réparation VM")]
        public string FixDescription { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner la date de la réparation VM")]
        public DateOnly? FixDate { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner le coût de la réparation VM")]
        [RegularExpression("^(-?(\\d+\\.?\\d+|\\d))+$", ErrorMessage = "Le coût n'est pas un nombre VM")]
        [Range(0.0001, double.MaxValue, ErrorMessage = "Le coût n'est pas supérieur à 0 VM")]
        public double FixCost { get; set; }



        // Foreign Key
        [Required(ErrorMessage = "Veuillez choisir une voiture associée")]
        public int AssociatedCarId { get; set; }

        public bool ValidateFix { get; set; }

        //public List<FixViewModel> Fix { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    if (ValidateFix)
        //    {
        //        foreach (var obj in Fix)
        //        {
        //            if (string.IsNullOrWhiteSpace(obj.FixDescription))
        //            {
        //                yield return new ValidationResult("Veuillez renseigner la description de la réparation", new[] { nameof(obj.FixDescription) });
        //            }
        //            if (obj.FixDate==null)
        //            {
        //                yield return new ValidationResult("Veuillez renseigner la date de la réparation", new[] { nameof(obj.FixDate) });
        //            }
        //            if (obj.FixCost==null)
        //            {
        //                yield return new ValidationResult("Veuillez renseigner le coût de la réparation", new[] { nameof(obj.FixCost) });
        //            }
        //        }
        //    }

        //}


    }
}
