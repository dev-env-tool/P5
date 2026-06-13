using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.FileProviders.Embedded;
using P5WebApp.Models.Entities;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class CarViewModel
    {
        public int CarId { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner un numéro d'immatriculation")]
        public string CarVinCode { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner une année de production")]
        public DateOnly? CarYear { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner une date d'achat")]
        public DateOnly ?CarBuyDate { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner un prix d'achat")]
        [RegularExpression("^(-?(\\d+\\.?\\d+|\\d))+$", ErrorMessage = "Le prix n'est pas un nombre")]
        [Range(0.0001, double.MaxValue, ErrorMessage = "Le prix n'est pas supérieur à 0")]

        public double CarBuyPrice { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner une marque")]
        public int CarBrandId { get; set; }



        [Required(ErrorMessage = "Veuillez renseigner un modèle")]
        public int CarModelId { get; set; }



        [Required(ErrorMessage = "Veuillez renseigner une finition")]
        public int CarFinishTypeId { get; set; }


        public int FixId { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner la description de la réparation")]
        public string FixDescription { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner la date de la réparation")]
        public DateOnly? FixDate { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner le coût de la réparation")]
        [RegularExpression("^(-?(\\d+\\.?\\d+|\\d))+$", ErrorMessage = "Le coût n'est pas un nombre")]
        [Range(0.0001, double.MaxValue, ErrorMessage = "Le coût n'est pas supérieur à 0")]
        public double FixCost { get; set; }



        // Foreign Key
        [Required(ErrorMessage = "Veuillez choisir une voiture associée")]
        public int AssociatedCarId { get; set; }

        public List<int>? AssociatedFixIds { get; set; } = new List<int>();

        public int AssociatedShortAddId { get; set; }


        public virtual ICollection<Fix> CarFixesList { get; set; } = new List<Fix>();

        public virtual ICollection<Brand> CarBrands { get; set; } = new List<Brand>();


        public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();


        public virtual ICollection<FinishType> FinishTypes { get; set; } = new List<FinishType>();


        public virtual ShortAdd? AssociatedShortAdd { get; set; }

        public virtual Car? Car { get; set; }



        //public List<string>? CarVinCodes { get; set; } = new List<string>();


        //public string SelectedVinCode { get; set; }

    }
}
