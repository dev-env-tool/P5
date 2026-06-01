using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.FileProviders.Embedded;
using P5WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class ShortAddViewModel
    {
        public int Id { get; set; }


        [Required]
        public required string Description { get; set; }


        [Required]
        public required DateOnly ShortAddAvailabilityDate { get; set; }



        public required DateOnly ShortAddDateSold { get; set; }


        public required bool ShortAddSold { get; set; }


        [Required]
        public required virtual int ShortAddCarId { get; set; }



        public const double Margin = 500;



        public required double ShortAddSellingPrice { get; set; }



        [Required]
        public required virtual ICollection<Photo> ShortAddPhotosList { get; set; } = new List<Photo>();



        [Required]
        public required virtual Car Car { get; set; }

    }
}
