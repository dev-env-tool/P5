using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.FileProviders.Embedded;
using P5WebApp.Models.Entities;

namespace P5WebApp.Models.ViewModels
{
    public class CarModelViewModel
    {
        [BindNever]
        public required int Id { get; set; }

        [Required]
        public required string Name { get; set; }

        [Required]
        public required int AsociatedBrandId { get; set; }
        public required virtual Brand AssociatedBrand { get; set; }

        public virtual ICollection<FinishType>? FinishTypes { get; set; } = new List<FinishType>();

    }
}
