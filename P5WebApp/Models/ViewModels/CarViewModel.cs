using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.FileProviders.Embedded;
using Microsoft.Identity.Client;
using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace P5WebApp.Models.ViewModels
{
    public class CarViewModel : IValidatableObject
    {
        public int CarId { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner un numéro d'immatriculation")]
        public string CarVinCode { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner une année de production")]
        public DateOnly? CarYear { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner une date d'achat")]
        public DateOnly? CarBuyDate { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            DateOnly minCarYear = new DateOnly(1970, 1, 1);
            DateOnly maxCarYear = new DateOnly(2010, 1, 1);

            DateOnly dateToday = DateOnly.FromDateTime(DateTime.Now);

            if (CarYear <= minCarYear)
            {
                yield return new ValidationResult("La date de production doit être comprise entre " + minCarYear + " et " + maxCarYear, new[] { nameof(CarYear) });

            }

            if (CarYear >= maxCarYear)
            {
                yield return new ValidationResult("La date de production doit être comprise entre "+ minCarYear + " et " + maxCarYear, new[] { nameof(CarYear) });

            }

            if (CarBuyDate <= CarYear)
            {
                yield return new ValidationResult("La date d'achat doit être ultérieure à la date de production de la voiture" , new[] { nameof(CarBuyDate)});
            }
            if (CarBuyDate >= dateToday)
            {
                yield return new ValidationResult("La date d'achat ne peut être ultérieure à la date du jour", new[] { nameof(CarBuyDate) });
            }

            if (CarAddAvailabilityDate <= CarBuyDate)
            {
                yield return new ValidationResult("La date de disponibilité doit être ultérieure à la date d'achat de la voiture", new[] { nameof(CarAddAvailabilityDate) });
            }

            if (CarDateSold >= dateToday)
            {
                yield return new ValidationResult("La date de vente ne peut être ultérieure à la date du jour", new[] { nameof(CarDateSold) });
            }

            if (CarDateSold <= CarAddAvailabilityDate)
            {
                yield return new ValidationResult("La date de vente doit être ultérieure à la date de disponibilité de la voiture", new[] { nameof(CarDateSold) });

            }

            if (CarFixesViewModelList != null)
            { 
                //foreach(var fix in CarFixesViewModelList)
                //{
                //    var context = new ValidationContext(fix);
                //    var results = new List<ValidationResult>();
                //    if (fix.ValidateFix)
                //    {

                //    }
                //}
                    for (int i = 0; i < CarFixesViewModelList.Count; i++)
                    {
                        var fix = CarFixesViewModelList[i];
                        if (fix.ValidateFix)
                        {
                            if (fix.FixDate >= dateToday)
                            {
                                yield return new ValidationResult("la date de réparation ne peut être ultérieure à la date du jour", new[] { $"CarFixesViewModelList[{i}].FixDate" });
                            }
                            if (fix.FixDate <= CarBuyDate)
                            {
                                yield return new ValidationResult("La date de la réparation doit être ultérieure à la date d'achat de la voiture", new[] { $"CarFixesViewModelList[{i}].FixDate" });
                            }
                            if (fix.FixDate >= CarAddAvailabilityDate)
                            {
                                yield return new ValidationResult("La date de la réparation doit être antérieure à la date de disponibilité de la voiture", new[] { $"CarFixesViewModelList[{i}].FixDate" });
                            }
                            if (fix.FixDate >= CarDateSold)
                            {
                                yield return new ValidationResult("La date de la réparation doit être antérieure à la date de vente de la voiture", new[] { $"CarFixesViewModelList[{i}].FixDate" });
                            }
                            if (fix.FixDate >= dateToday)
                            {
                                yield return new ValidationResult("La date de la réparation ne peut être ultérieure à la date du jour", new[] { $"CarFixesViewModelList[{i}].FixDate" });
                            }

                    }
                }


                
            }
        }


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


        [Required(ErrorMessage = "Veuillez choisir une voiture associée")]
        public int AssociatedCarId { get; set; }

        //public List<int>? AssociatedFixIds { get; set; } = new List<int>();

        //public int AssociatedShortAddId { get; set; }

        public virtual List<FixViewModel> ?CarFixesViewModelList { get; set; }




        public virtual ICollection<Brand> CarBrands { get; set; } = new List<Brand>();


        public virtual ICollection<CarModel> CarModels { get; set; } = new List<CarModel>();


        public virtual ICollection<FinishType> FinishTypes { get; set; } = new List<FinishType>();


        [Required(ErrorMessage = "Veuillez choisir une photo associée")]
        public IFormFile Photo { get; set; }

        public PhotoViewModel PhotoForDb { get; set; }


        public string? CarDescription { get; set; }

        public DateOnly? CarAddAvailabilityDate { get; set; }

        public bool CarPublished { get; set; }

        public DateOnly? CarDateSold { get; set; }



        public double CarSellingPrice { get; set; }
        public string ?CarBrandName { get; set; }
        public string? CarModelName { get; set; }
        public string ?CarFinishTypeName { get; set; }
        public string? PhotoPath { get; set; }

    }
}



//public class DateCustom : ValidationAttribute
//{




//    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
//    {
//        //var car = (CarViewModel)validationContext.ObjectInstance;
//        var car = validationContext.ObjectInstance as CarViewModel;

//        var carYear = car.CarYear;
//        var carBuyDate = car.CarBuyDate;
//        var carAddAvailabilityDate = car.CarAddAvailabilityDate;
//        var carDateSold = car.CarDateSold;

//        DateOnly dateOnlyNow = DateOnly.FromDateTime(DateTime.Now);

//        if (carYear != null && carBuyDate != null)
//        {
//            if (carBuyDate < carYear)
//            {
//                return new ValidationResult(string.Empty);
//            }

//        }
//        return ValidationResult.Success;

//    }
//}












//}
//public class DateCustom : ValidationAttribute
//{
//    //public DateCustom(DateOnly date)
//    //    => date = date;


//    //public string GetErrorMessage() =>
//    //    $"";

//    public string errorMessage1 = "La date d'achat doit être ultérieure à l'année de production de la voiture";
//    public string errorMessage2 = "La date de disponibilité doit être ultérieure à la date d'achat de la voiture";
//    public string errorMessage3 = "La date de vente doit être ultérieure à la date de disponibilité de la voiture";
//    public string errorMessage4 = "La date renseignée ne peut être ultérieure à la date d'aujourd'hui";

//    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
//    {
//        var car = (CarViewModel)validationContext.ObjectInstance;
//        var carYear = car.CarYear;
//        var carBuyDate = car.CarBuyDate;
//        var carAddAvailabilityDate = car.CarAddAvailabilityDate;
//        var carDateSold = car.CarDateSold;

//        DateOnly dateOnlyNow = DateOnly.FromDateTime(DateTime.Now);

//        if (carYear != null && carBuyDate != null) 
//        {
//            if(carYear > carBuyDate)
//            {
//                return new ValidationResult(errorMessage1, new[] { "CarBuyDate" });
//            }

//        }

//        if (carYear != null && carBuyDate != null && carAddAvailabilityDate != null)
//        {
//            if (carBuyDate > carAddAvailabilityDate)
//            {
//                return new ValidationResult(errorMessage2);
//            }

//        }

//        if (carYear != null && carBuyDate != null && carAddAvailabilityDate != null && carDateSold != null)
//        {
//            if (carAddAvailabilityDate > carDateSold)
//            {
//                return new ValidationResult(errorMessage3);
//            }

//        }

//        return ValidationResult.Success;
//        //return base.GetValidationResult(value, validationContext);
//    }

//}