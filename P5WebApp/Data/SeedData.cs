using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.Services;
using System;
using System.Linq;
using P5WebApp;




namespace P5WebApp.Data
{

    public class SeedData
    {




        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var context = new P5Referential(
                serviceProvider.GetRequiredService<DbContextOptions<P5Referential>>());
           


            if (context.Brands.Any())
            {
                return;
            }
            context.Brands.AddRange
            (
                new Brand
                {
                    BrandId = 1,
                    BrandName = "Peugeot",
                },

                new Brand
                {
                    BrandId = 2,
                    BrandName = "Citroën",
                }
            );



            if (context.CarModels.Any())
            {
                return;
            }
            context.CarModels.AddRange
            (
                new CarModel
                {
                    Id = 1,
                    Name = "205",
                    AssociatedBrandId = 1,
                },

                new CarModel
                {
                    Id = 2,
                    Name = "206",
                    AssociatedBrandId = 1,
                },

                new CarModel
                {
                    Id = 3,
                    Name = "Xantia",
                    AssociatedBrandId = 2,
                },

                new CarModel
                {
                    Id = 4,
                    Name = "Xsara",
                    AssociatedBrandId = 2,
                }
            );


            if (context.FinishTypes.Any())
            {
                return;
            }
            context.FinishTypes.AddRange
            (
                new FinishType
                {
                    FinishTypeId = 1,
                    FinishTypeName = "Blanc",
                    AssociatedBrandsIds = { 1, 2 },
                    AssociatedCarModelIds = { 1, 2, 3, 4 },
                },
                new FinishType
                {
                    FinishTypeId = 2,
                    FinishTypeName = "Gris",
                    AssociatedBrandsIds = { 1, 2 },
                    AssociatedCarModelIds = { 1, 2, 3, 4 },
                },
                new FinishType
                {
                    FinishTypeId = 3,
                    FinishTypeName = "Rouge",
                    AssociatedBrandsIds = { 1, 2 },
                    AssociatedCarModelIds = { 1, 2, 3, 4 },
                },
                new FinishType
                {
                    FinishTypeId = 4,
                    FinishTypeName = "Bleu",
                    AssociatedBrandsIds = { 1, 2 },
                    AssociatedCarModelIds = { 1, 2, 3, 4 },
                }

            );


            if (context.Cars.Any())
            {
                return;
            }
            context.Cars.AddRange
            (

                new Car
                {
                    CarId = 1,
                    CarBrandId = 1,
                    CarModelId = 1,
                    CarFinishTypeId = 1,
                    CarVinCode = "AF-852-89",
                    CarYear = new DateOnly(01, 01, 1999),
                    CarBuyDate = new DateOnly(05, 05, 2026),
                    CarAddAvailabilityDate = new DateOnly(05, 05, 2026),
                    CarDescription = "Voiture à vendre, bon état",
                    CarBuyPrice = 5000,
                    CarPublished = true,
                    CarSellingPrice = 5500,
                },

                new Car
                {
                    CarId = 2,
                    CarBrandId = 1,
                    CarModelId = 2,
                    CarFinishTypeId = 2,
                    CarVinCode = "AC-838-14",
                    CarYear = new DateOnly(01, 01, 2005),
                    CarBuyDate = new DateOnly(06, 05, 2026),
                    CarAddAvailabilityDate = new DateOnly(20, 05, 2026),
                    CarDescription = "Voiture à vendre, bon état",
                    CarBuyPrice = 7000,
                    CarPublished = true,
                    CarSellingPrice = 7500,
                },

                new Car
                {
                    CarId = 3,
                    CarBrandId = 2,
                    CarModelId = 3,
                    CarFinishTypeId = 3,
                    CarVinCode = "AC-894-10",
                    CarYear = new DateOnly(01, 01, 2002),
                    CarBuyDate = new DateOnly(06, 06, 2026),
                    CarAddAvailabilityDate = new DateOnly(20, 06, 2026),
                    CarDescription = "Voiture à vendre, bon état",
                    CarBuyPrice = 4000,
                    CarPublished = true,
                    CarSellingPrice = 4500,
                },


                new Car
                {
                    CarId = 4,
                    CarBrandId = 2,
                    CarModelId = 4,
                    CarFinishTypeId = 2,
                    CarVinCode = "AA-2158-40",
                    CarYear = new DateOnly(01, 01, 2003),
                    CarBuyDate = new DateOnly(06, 06, 2026),
                    CarAddAvailabilityDate = new DateOnly(20, 06, 2026),
                    CarDescription = "Voiture à vendre, bon état",
                    CarBuyPrice = 4500,
                    CarPublished = true,
                    CarSellingPrice = 5000,
                }

            );

            context.SaveChanges();
        }
    }

}
