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
        public int Id { get; set; }
        public string CarModelName { get; set; } 
        public string BrandName { get; set; }
        public DateOnly ? CarYear { get; set; }
        public double CarSellingPrice { get; set; }
        public string FinishTypeName { get; set; }
        public string PhotoPath { get; set; }

        public bool isIdPair { get; set; }

    }
}

