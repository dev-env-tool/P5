using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.FileProviders.Embedded;
using Microsoft.Identity.Client;
using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;
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
        [DateCustom]
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



        // Foreign Key
        [Required(ErrorMessage = "Veuillez choisir une voiture associée")]
        public int AssociatedCarId { get; set; }

        public List<int>? AssociatedFixIds { get; set; } = new List<int>();

        public int AssociatedShortAddId { get; set; }


        //public virtual ICollection<Fix> CarFixesList { get; set; } = new List<Fix>();

        public virtual List<FixViewModel> CarFixesViewModelList { get; set; } = new List<FixViewModel> { new FixViewModel() };




        public virtual ICollection<Brand> CarBrands { get; set; } = new List<Brand>();


        public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();


        public virtual ICollection<FinishType> FinishTypes { get; set; } = new List<FinishType>();


        //public virtual ShortAdd? AssociatedShortAdd { get; set; }

        [Required(ErrorMessage = "Veuillez choisir une photo associée")]
        public IFormFile Photo { get; set; }

        public PhotoViewModel PhotoForDb { get; set; }


        public string? CarDescription { get; set; }


        public DateOnly? CarAddAvailabilityDate { get; set; }

        public bool CarPublished { get; set; }

        public DateOnly? CarDateSold { get; set; }


        public const double CarMargin = 500;


        public double CarSellingPrice { get; set; }
    }
}



public class DateCustom : ValidationAttribute
{
    //public DateCustom(DateOnly date)
    //    => date = date;


    public string GetErrorMessage() =>
        $"";

    public string errorMessage1 = "La date d'achat doit être ultérieure à l'année de production de la voiture";
    public string errorMessage2 = "La date de disponibilité doit être ultérieure à la date d'achat de la voiture";
    public string errorMessage3 = "La date de vente doit être ultérieure à la date de disponibilité de la voiture";
    public string errorMessage4 = "La date renseignée ne peut être ultérieure à la date d'aujourd'hui";

    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var car = (CarViewModel)validationContext.ObjectInstance;
        var carYear = car.CarYear;
        var carBuyDate = car.CarBuyDate;
        var carAddAvailabilityDate = car.CarAddAvailabilityDate;
        var carDateSold = car.CarDateSold;

        var timeNow = DateTime.Now;

        if (carYear != null && carBuyDate != null) 
        {
            if(carYear > carBuyDate)
            {
                return new ValidationResult(errorMessage1);
            }
        
        }

        if (carYear != null && carBuyDate != null && carAddAvailabilityDate != null)
        {
            if (carBuyDate > carAddAvailabilityDate)
            {
                return new ValidationResult(errorMessage2);
            }

        }

        if (carYear != null && carBuyDate != null && carAddAvailabilityDate != null && carDateSold != null)
        {
            if (carAddAvailabilityDate > carDateSold)
            {
                return new ValidationResult(errorMessage3);
            }

        }


        return base.IsValid(value, validationContext);
    }

}