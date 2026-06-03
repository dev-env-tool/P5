using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Identity.Client;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.Services;
using P5WebApp.Models.ViewModels;

namespace P5WebApp.Controllers
{
    public class CarModelController : Controller
    {

        private readonly ICarModelService _carModelService;
        private readonly ICarModelRepository _carModelRepository;
        private readonly IBrandService _brandService;

        public CarModelController(ICarModelService CarModelService, ICarModelRepository CarModelRepository, IBrandService brandService)
        {
            _carModelService = CarModelService;
            _carModelRepository = CarModelRepository;
            _brandService = brandService;
        }


        // GET: CarModelController
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]

        // GET: View only for registered admin user. CarModel list to see all CarModels.
        public IActionResult Admin()
        {
            return View(_carModelService.GetAllCarModelsViewModel().OrderByDescending(c => c.Id));
        }


        // GET: CarModelController/Details/5
        public IActionResult Details(int id)
        {
            IEnumerable<CarModelViewModel> CarModels = _carModelService.GetAllCarModelsViewModel();
            return View();
        }

        // GET: CarModelController/Create
        [Authorize]


        public ViewResult Create(int id)
        {
            CarModelViewModel CarModel = new CarModelViewModel();
            CarModel.Brands = new List<Brand>();
            CarModel.Brands = _brandService.GetAllBrands();
            return View(CarModel);
        }

        // POST: CarModelController/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CarModelViewModel CarModel)
        {

            Dictionary<string, string> modelErrors = _carModelService.CheckCarModelModelErrors(CarModel);


            foreach (var key in modelErrors)
            {
                string field = key.Key;
                string error = key.Value;

                ModelState.AddModelError(field, error);
            }
            if (ModelState.IsValid)
            {
                _carModelService.SaveCarModel(CarModel);
                return RedirectToAction("Admin");
            }
            else
            {
                return View(CarModel);
            }

        }

        // GET: CarModelController/Edit/5
        public ActionResult Edit(int id)
        {
            CarModelViewModel CarModelViewModel = _carModelService.GetCarModelByIdViewModel(id);
            var editCarModel = _carModelService.GetCarModelById(id);
            CarModelViewModel.Brands = new List<Brand>();
            CarModelViewModel.Brands = _brandService.GetAllBrands();
            CarModelViewModel.AssociatedBrandId = editCarModel.AssociatedBrandId;
            return View(CarModelViewModel);
        }

        // POST: CarModelController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CarModelViewModel CarModel)
        {
            
            Dictionary<string, string> modelErrors = _carModelService.CheckCarModelModelErrors(CarModel);


            foreach (var key in modelErrors)
            {
                string field = key.Key;
                string error = key.Value;

                ModelState.AddModelError(field, error);
            }
            if (ModelState.IsValid)
            {
                _carModelService.UpdateCarModel(CarModel);
                return RedirectToAction("Admin");
            }
            else
            {
                return View(CarModel);
            }
        }

        // GET: CarModelController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarModelController/Delete/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            {
                _carModelService.DeleteCarModel(id);
                return RedirectToAction("Admin");
            }
        }
    }
}
