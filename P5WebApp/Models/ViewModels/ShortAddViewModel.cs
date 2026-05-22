using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.FileProviders.Embedded;
using P5WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class ShortAddViewModel
    {
        [BindNever]
        public required int Id { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingShortAddDescription")]
        public required string Description { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingShortAddAvailabilityDate")]
        public required DateOnly ShortAddAvailabilityDate { get; set; }



        public required DateOnly ShortAddDateSold { get; set; }


        public required bool ShortAddSold { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingShortAddAddCarId")]
        public required virtual int ShortAddCarId { get; set; }



        public const double Margin = 500;



        public required double ShortAddSellingPrice { get; set; }



        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorEmptyShortAddPhotosList")]
        public required virtual ICollection<Photo> ShortAddPhotosList { get; set; } = new List<Photo>();



        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingShortAddCar")]
        public required virtual Car Car { get; set; }

    }
}
