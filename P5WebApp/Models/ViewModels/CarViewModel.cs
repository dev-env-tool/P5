using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.FileProviders.Embedded;
using P5WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class CarViewModel
    {
        [BindNever]
        public required int CarId { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingCarVinCode")]
        public required string CarVinCode { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingCarYear")]
        public required DateOnly CarYear { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingCarBuyDate")]
        public required DateOnly CarBuyDate { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingCarBuyPrice")]
        public required double CarBuyPrice { get; set; }

        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingCarBrandId")]
        public required int CarBrandId { get; set; }


        public required virtual Brand Brand { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingCarModelId")]
        public required int CarModelId { get; set; }


        public required virtual CarModel CarModel { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingCarFinishTypeId")]
        public required int CarFinishTypeId { get; set; }


        public required virtual FinishType FinishType { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorEmptyCarFixesList")]
        public required virtual ICollection<Fix> CarFixesList { get; set; } = new List<Fix>();

        public int AssociatedShortAddId { get; set; }

        public virtual ShortAdd? AssociatedShortAdd { get; set; }

    }
}
