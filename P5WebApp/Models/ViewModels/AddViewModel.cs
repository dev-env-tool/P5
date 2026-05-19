using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.FileProviders.Embedded;
using P5WebApp.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class AddViewModel
    {
        [BindNever]
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingAddTitle")] 
        public string? Title { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingAddDescription")]
        public string? Description { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingAddAvailabilityDate")]
        public DateOnly AddAvailabilityDate { get; set; }



        public DateOnly AddDateSold { get; set; }


        public bool AddSold { get; set; }


        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingAddAddVehicleId")]
        public virtual int AddVehicleId { get; set; }



        public const double Margin = 500;



        public double AddSellingPrice { get; set; }



        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorEmptyAddPhotosList")]
        public virtual ICollection<Photo>? AddPhotosList { get; set; } = [];



        [Required(ErrorMessageResourceType = typeof(EmbeddedResourceFileInfo), ErrorMessageResourceName = "ErrorMissingAddCar")]
        public virtual Car? Car { get; set; }

    }
}
