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

            Console.WriteLine("hereseeddata");

            if (context.Brands.Any())
            {
                return;
            }
            var peugeot = new Brand { BrandName = "Peugeot" };
            var citroen = new Brand { BrandName = "Citroën" };

            context.Brands.AddRange(peugeot, citroen);
            context.SaveChanges();

            if (context.CarModels.Any())
            {
                return;
            }

            var p205 = new CarModel { Name = "205", AssociatedBrandId = peugeot.BrandId };
            var p206 = new CarModel { Name = "206", AssociatedBrandId = peugeot.BrandId };
            var xantia = new CarModel { Name = "Xantia", AssociatedBrandId = citroen.BrandId };
            var xsara = new CarModel { Name = "Xsara", AssociatedBrandId = citroen.BrandId };

            context.CarModels.AddRange(p205, p206, xantia, xsara);
            context.SaveChanges();

            if (context.FinishTypes.Any())
            {
                return;
            }


            var blanc = new FinishType 
            { 
                FinishTypeName = "Blanc",
                AssociatedBrandsIds = { peugeot.BrandId, citroen.BrandId },
                AssociatedCarModelIds = { p205.Id, p206.Id, xantia.Id, xsara.Id },
            };
            var gris = new FinishType 
            { 
                FinishTypeName = "Gris",
                AssociatedBrandsIds = { peugeot.BrandId, citroen.BrandId },
                AssociatedCarModelIds = { p205.Id, p206.Id, xantia.Id, xsara.Id },
            };
            var rouge = new FinishType 
            { 
                FinishTypeName = "Rouge",
                AssociatedBrandsIds = { peugeot.BrandId, citroen.BrandId },
                AssociatedCarModelIds = { p205.Id, p206.Id, xantia.Id, xsara.Id },
            };
            var bleu = new FinishType 
            { 
                FinishTypeName = "Bleu",
                AssociatedBrandsIds = { peugeot.BrandId, citroen.BrandId },
                AssociatedCarModelIds = { p205.Id, p206.Id, xantia.Id, xsara.Id },
            };

            context.FinishTypes.AddRange(blanc, gris, rouge, bleu);
            context.SaveChanges();




            if (context.Cars.Any())
            {
                return;
            }


            var car1 = new Car
            {
                CarBrandId = peugeot.BrandId,
                CarModelId = p205.Id,
                CarFinishTypeId = blanc.FinishTypeId,
                CarVinCode = "AF-852-89",
                CarYear = new DateOnly(1999, 01, 01),
                CarBuyDate = new DateOnly(2026, 05, 05),
                CarAddAvailabilityDate = new DateOnly(2026, 05, 06),
                CarDescription = "Voiture à vendre, bon état",
                CarBuyPrice = 5000,
                CarPublished = true,
                CarSellingPrice = 5500,
            };

            var car2 = new Car
            {
                CarBrandId = peugeot.BrandId,
                CarModelId = p206.Id,
                CarFinishTypeId = gris.FinishTypeId,
                CarVinCode = "AC-838-14",
                CarYear = new DateOnly(2005, 01, 01),
                CarBuyDate = new DateOnly(2026, 06, 05),
                CarAddAvailabilityDate = new DateOnly(2026, 06, 10),
                CarDescription = "Voiture à vendre, bon état",
                CarBuyPrice = 7000,
                CarPublished = true,
                CarSellingPrice = 7500,
            };

            var car3 = new Car
            {
                CarBrandId = citroen.BrandId,
                CarModelId = xantia.Id,
                CarFinishTypeId = rouge.FinishTypeId,
                CarVinCode = "AC-894-10",
                CarYear = new DateOnly(2002, 01, 01),
                CarBuyDate = new DateOnly(2026, 06, 06),
                CarAddAvailabilityDate = new DateOnly(2026, 06, 20),
                CarDescription = "Voiture à vendre, bon état",
                CarBuyPrice = 4000,
                CarPublished = true,
                CarSellingPrice = 4500,
            };


            var car4 = new Car
            {
                CarBrandId = citroen.BrandId,
                CarModelId = xsara.Id,
                CarFinishTypeId = gris.FinishTypeId,
                CarVinCode = "AA-2158-40",
                CarYear = new DateOnly(2003, 01, 01),
                CarBuyDate = new DateOnly(2026, 06, 06),
                CarAddAvailabilityDate = new DateOnly(2026, 06, 10),
                CarDescription = "Voiture à vendre, bon état",
                CarBuyPrice = 4500,
                CarPublished = true,
                CarSellingPrice = 5000,
                CarDateSold = new DateOnly(2026, 06, 20),
            };

            context.Cars.AddRange(car1, car2, car3, car4);
            context.SaveChanges();

            if (context.Fixes.Any())
            {
                return;
            }

            var fix1 = new Fix
            {
                FixDate = new DateOnly(),
                FixDescription = "Changement des pneus / Géométrie",
                FixCost = 200,
                AssociatedCarId = p205.Id,
            };
            var fix2 = new Fix
            {
                FixDate = new DateOnly(),
                FixDescription = "Vidange",
                FixCost = 40,
                AssociatedCarId = p205.Id,
            };
            var fix3 = new Fix
            {
                FixDate = new DateOnly(),
                FixDescription = "Distribution",
                FixCost = 150,
                AssociatedCarId = p206.Id,
            };
            var fix4 = new Fix
            {
                FixDate = new DateOnly(),
                FixDescription = "Suspensions",
                FixCost = 200,
                AssociatedCarId = p205.Id,
            };
            var fix5 = new Fix
            {
                FixDate = new DateOnly(),
                FixDescription = "Carrosserie aile avant droite",
                FixCost = 40,
                AssociatedCarId = xantia.Id,
            };
            var fix6 = new Fix
            {
                FixDate = new DateOnly(),
                FixDescription = "Batterie",
                FixCost = 60,
                AssociatedCarId = xsara.Id,
                
            };

            context.Fixes.AddRange(fix1, fix2, fix3, fix4, fix5, fix6);
            context.SaveChanges();

            if (context.Photos.Any())
            {
                return;
            }

            var photo1 = new Photo
            {
                PhotoName = "205_white",
                PhotoPath = "Cars/Images/03f4cf14-c641-48b3-93d0-8c4b9429815e_205_white.jpg",
                AssociatedCarId = car1.CarId,
            };
            var photo2 = new Photo
            {
                PhotoName = "206_grey",
                PhotoPath = "Cars/Images/8ac2d467-cd73-442e-a0a6-019b26fab0cf_206_grey_2.jpg",
                AssociatedCarId = car2.CarId,
            };
            var photo3 = new Photo
            {
                PhotoName = "205_white",
                PhotoPath = "Cars/Images/fg52d524-5f56-5256-a125-a85564fd4546f_Xantia_red4.jpg",
                AssociatedCarId = car3.CarId,
            };
            var photo4 = new Photo
            {
                PhotoName = "205_white",
                PhotoPath = "Cars/Images/a169d321-104d-4c61-97d1-78932ab3a691_Xsara_grey_2.jpg",
                AssociatedCarId = car4.CarId,
            };


            context.Photos.AddRange(photo1, photo2, photo3, photo4);
            context.SaveChanges();

        }

}}
