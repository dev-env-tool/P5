using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using P5WebApp.Models;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.Services;
using P5WebApp.Models.ViewModels;
using System.Diagnostics;

namespace P5WebApp.Controllers
{
    public class HomeController : Controller
    {

        private readonly ICarService _carService;
        private readonly ICarRepository _carRepository;
        private readonly IBrandService _brandService;
        private readonly ICarModelService _carModelService;
        private readonly IFinishTypeService _finishTypeService;
        private readonly IPhotoService _photoService;
        private readonly IPhotoRepository _photoRepository;


        public HomeController(ICarService carService, ICarRepository carRepository, IBrandService brandService, ICarModelService carModelService,
            IFinishTypeService finishTypeService, IPhotoService photoService, IPhotoRepository photoRepository)
        {
            _carService = carService;
            _carRepository = carRepository;
            _brandService = brandService;
            _carModelService = carModelService;
            _finishTypeService = finishTypeService;
            _photoService = photoService;
            _photoRepository = photoRepository;

        }

        public IActionResult Index()
        {
            
            var cars = _carService.GetAllCars().Where(c => c.CarPublished == true).ToList();
            var brands = _brandService.GetAllBrands().ToList();
            var carModels = _carModelService.GetAllCarModels().ToList();
            var finishTypes = _finishTypeService.GetAllFinishTypes().ToList();
            var photos = _photoService.GetAllPhotos().ToList();

            //var testPhoto = photos.FirstOrDefault(p => p.AssociatedCarId == 180);

            //var homeViewModel =
            //                    (
            //                    from car in cars
            //                    join brand in brands on car.CarBrandId equals brand.BrandId
            //                    join carModel in carModels on car.CarModelId equals carModel.Id
            //                    join finishType in finishTypes on car.CarFinishTypeId equals finishType.FinishTypeId
            //                    from AssociatedPhotoIds in car.AssociatedPhotoIds
            //                    let firstPhoto = (from photo in photos
            //                                      where photo.AssociatedCarId == car.CarId
            //                                      select photo).FirstOrDefault()

            //                    select new HomeViewModel
            //                    {
            //                        CarModelName = carModel.Name,
            //                        BrandName = brand.BrandName,
            //                        CarYear = car.CarYear,
            //                        CarSellingPrice = car.CarSellingPrice,
            //                        FinishTypeName = finishType.FinishTypeName,
            //                        PhotoPath = firstPhoto?.PhotoPath,
            //                    }).ToList();


            //var testCarId = cars.First().CarId;
            //var photoTest = photos.FirstOrDefault(p => p.AssociatedCarId == testCarId);
            //Console.WriteLine(photoTest != null ? photoTest.PhotoPath : "Pas de photo");

            var homeViewModel = cars.Select(car =>
            {
                var brand = brands.FirstOrDefault(b => b.BrandId == car.CarBrandId);
                var carModel = carModels.FirstOrDefault(cm => cm.Id == car.CarModelId);
                var finishType = finishTypes.FirstOrDefault(ft => ft.FinishTypeId == car.CarFinishTypeId);
                var firstPhoto = photos.FirstOrDefault(p => p.AssociatedCarId == car.CarId);
                var carId = car.CarId;

                return new HomeViewModel
                {
                    Id = carId,
                    CarModelName = carModel?.Name,
                    BrandName = brand?.BrandName,
                    CarYear = car.CarYear,
                    CarSellingPrice = car.CarSellingPrice,
                    FinishTypeName = finishType?.FinishTypeName,
                    PhotoPath = firstPhoto?.PhotoPath,
                    isIdPair = carId % 2 == 0,
                    CarDateSold = car.CarDateSold,
                };
            }).ToList();

            return View(homeViewModel.OrderByDescending(c => c.Id));
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
