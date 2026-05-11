using P5WebApp.Models.Entities;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class AddViewModel
    {
        [BindNever]
        public int Id { get; set; }

        [Required]
        public DateOnly AddAvailabilityDate { get; set; }

        public DateOnly AddDateSold { get; set; }

        [Required]
        public bool AddSold { get; set; }

        [Required]
        public int ?AddCarId { get; set; }

        [Required]
        public double AddBuyPrice { get; set; }

        [Required]
        public virtual ICollection<Photo>? AddPhotosList { get; set; }

    }
}
