using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.FileProviders.Embedded;
using P5WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class CarViewModel
    {
        public int CarId { get; set; }


        [Required]
        public required string CarVinCode { get; set; }


        [Required]
        public required DateOnly CarYear { get; set; }


        [Required]
        public required DateOnly CarBuyDate { get; set; }


        [Required]
        public required double CarBuyPrice { get; set; }

        [Required]
        public required int CarBrandId { get; set; }


        public required virtual Brand Brand { get; set; }


        [Required]
        public required int CarModelId { get; set; }


        public required virtual CarModel CarModel { get; set; }


        [Required]
        public required int CarFinishTypeId { get; set; }


        public required virtual FinishType FinishType { get; set; }


        [Required]
        public required virtual ICollection<Fix> CarFixesList { get; set; } = new List<Fix>();

        public int AssociatedShortAddId { get; set; }

        public virtual ShortAdd? AssociatedShortAdd { get; set; }

    }
}
