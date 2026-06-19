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
        private readonly IFixService _fixService;
        private readonly IPhotoService _photoService;
        private readonly IPhotoRepository _photoRepository;












        public HomeController(ICarService carService, ICarRepository carRepository, IBrandService brandService, ICarModelService carModelService,
           IFixService fixService, IFinishTypeService finishTypeService, IPhotoService photoService, IPhotoRepository photoRepository)
        {
            _carService = carService;
            _carRepository = carRepository;
            _brandService = brandService;
            _carModelService = carModelService;
            _finishTypeService = finishTypeService;
            _fixService = fixService;
            _photoService = photoService;
            _photoRepository = photoRepository;

        }

        public IActionResult Index()
        {
            var cars = _carService.GetAllCars();
            var brands = _brandService.GetAllBrands();
            var carModels = _carModelService.GetAllCarModels();
            var finishTypes = _finishTypeService.GetAllFinishTypes();
            var photos = _photoService.GetAllPhotos();


            var viewModel = new HomeViewModel
            {
                Cars = cars,
                Brands = brands,
                CarModels = carModels,
                FinishTypes = finishTypes,

                
            };

            return View(cars);
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
