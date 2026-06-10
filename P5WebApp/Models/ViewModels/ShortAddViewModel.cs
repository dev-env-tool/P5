using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.FileProviders.Embedded;
using P5WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class ShortAddViewModel
    {
        public int ShortAddId { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner une description")]
        public string Description { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner une date de disponibilité")]
        public DateOnly ?ShortAddAvailabilityDate { get; set; }

 
        public bool ShortAddPublished { get; set; }

        public DateOnly ?ShortAddDateSold { get; set; }


        public bool ShortAddSold { get; set; }


        [Required(ErrorMessage = "Veuillez renseigner la voiture associée")]
        public virtual int ShortAddCarId { get; set; }

        [Required(ErrorMessage = "Veuillez renseigner le prix d'achat de la voiture")]
        public double ShortAddBuyPrice { get; set; }

        public const double Margin = 500;


        public double ShortAddSellingPrice { get; set; }


        public virtual ICollection<Photo> ShortAddPhotosList { get; set; } = new List<Photo>();

        public virtual ICollection<Car> CarsList { get; set; } = new List<Car>();

        public virtual Car Car { get; set; }


        public CarViewModel CarViewModel { get; set; }

    }
}
