using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.FileProviders.Embedded;
using Microsoft.Identity.Client;
using P5WebApp.Models.Entities;
using P5WebApp.Models.ViewModels;
using System.Collections;
using System.ComponentModel.DataAnnotations;

namespace P5WebApp.Models.ViewModels
{
    public class HomeViewModel
    {

        public virtual List<Car> Cars { get; set; }
        public virtual List<Brand> Brands { get; set; }
        public virtual List<CarModel> CarModels { get; set; }
        public virtual List<FinishType> FinishTypes { get; set; }
        public virtual List<Fix> Fixess { get; set; }
        public virtual List<Photo> Photos { get; set; }

    }
}

