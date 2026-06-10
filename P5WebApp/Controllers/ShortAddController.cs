using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using Newtonsoft.Json.Linq;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.Services;
using P5WebApp.Models.ViewModels;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace P5WebApp.Controllers
{
    public class ShortAddController : Controller
    {

        private readonly ICarService _carService;
        private readonly IBrandService _brandService;
        private readonly ICarModelService _carModelService;
        private readonly IFinishTypeService _finishTypeService;
        private readonly IFinishTypeRepository _finishTypeRepository;
        private readonly IFixService _fixService;
        private readonly IFixRepository _fixRepository;
        private readonly IShortAddService _shortAddService;
        private readonly IShortAddRepository _shortAddRepository;

        public ShortAddController(ICarService carService,
            IBrandService brandService, ICarModelService carModelService, IFinishTypeService finishTypeService, IFinishTypeRepository finishTypeRepository,
            IFixService fixService, IFixRepository fixRepository, IShortAddService shortAddService, IShortAddRepository shortAddRepository)
        {
            _carService = carService;
            _brandService = brandService;
            _carModelService = carModelService;
            _finishTypeService = finishTypeService;
            _finishTypeRepository = finishTypeRepository;
            _fixService = fixService;
            _fixRepository = fixRepository;
            _shortAddService = shortAddService;
            _shortAddRepository = shortAddRepository;

        }


        // GET: ShortAddController
        public ActionResult Index()
        {

            return View();
        }

        [Authorize]

        // GET: View only for registered admin user. ShortAdd list to see all ShortAdds.
        public IActionResult Admin()
        {
            ShortAddViewModel shortAddViewModel = new ShortAddViewModel();
            ViewBag.CarModels = _carModelService.GetAllCarModels().Where(c => c.Id >= 0).SelectMany(c => c.Name);
            return View(_shortAddService.GetAllShortAddsViewModel().OrderByDescending(s => s.ShortAddId));
        }



        [Authorize]

        // GET: View only for registered admin user. ShortAdd list to see one ShortAdds.
        public IActionResult Read(int id)
        {
            ViewBag.Brands = _brandService.GetAllBrands();
            ViewBag.CarModels = _carModelService.GetAllCarModels();
            ViewBag.FinishTypes = _finishTypeService.GetAllFinishTypes();

            ShortAddViewModel shortAddViewModel = _shortAddService.GetShortAddByIdViewModel(id);
           

            return View(shortAddViewModel);
        }





        // GET: ShortAddController/Details/5
        public IActionResult Details(int id)
        {
            IEnumerable<ShortAddViewModel> shortAdds = _shortAddService.GetAllShortAddsViewModel();
            return View();
        }

        // GET: ShortAddController/Create
        [Authorize]


        public ViewResult Create(int id)
        {

            ShortAddViewModel shortAddViewModel = new ShortAddViewModel();
            shortAddViewModel.Car = new Car();
            shortAddViewModel.CarViewModel = new CarViewModel();
            shortAddViewModel.CarViewModel.SelectedVinCode = "test";
            shortAddViewModel.CarViewModel.CarVinCodes = new List<string>();
            shortAddViewModel.CarViewModel.CarVinCodes = _carService.GetAllCars().Where(c => c.CarId > 0).Select(c => c.CarVinCode).ToList();

            var carInfosBuffer = new List<SelectListItem>();

            foreach (var vinCode in shortAddViewModel.CarViewModel.CarVinCodes)
            {
                var text = vinCode + " - " + (_carService.GetCarModelCarBrandAndYearNameByVinCode(vinCode) ?? "N/A");
                var item = new SelectListItem { Value = vinCode, Text = text };
                carInfosBuffer.Add(item);
            }
            ViewBag.CarInfos = carInfosBuffer;


            return View(shortAddViewModel);
        }
        // POST: ShortAddController/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ShortAddViewModel shortAdd)
        {
            
            shortAdd.Car = new Car();

            shortAdd.Car.CarVinCode = shortAdd.CarViewModel.SelectedVinCode;

            shortAdd.CarViewModel = new CarViewModel();

        
            shortAdd.CarViewModel.CarVinCodes = new List<string>();
            shortAdd.CarViewModel.CarVinCodes = _carService.GetAllCars().Where(c => c.CarId > 0).Select(c => c.CarVinCode).ToList();

            var carInfosBuffer = new List<SelectListItem>();

            foreach (var vinCode in shortAdd.CarViewModel.CarVinCodes)
            {
                var text = vinCode + " - " + (_carService.GetCarModelCarBrandAndYearNameByVinCode(vinCode) ?? "N/A");
                var item = new SelectListItem { Value = vinCode, Text = text };
                carInfosBuffer.Add(item);
            }
            ViewBag.CarInfos = carInfosBuffer;



            shortAdd.CarViewModel = _carService.GetCarByIdViewModel(shortAdd.Car.CarId);




            Dictionary<string, string> modelErrors = _shortAddService.CheckShortAddModelErrors(shortAdd);


            foreach (var key in modelErrors)
            {
                string field = key.Key;
                string error = key.Value;

                ModelState.AddModelError(field, error);
            }
            if (ModelState.IsValid)
            {
                _shortAddService.SaveShortAdd(shortAdd);
                return RedirectToAction("Admin");
            }
            else
            {
                return View(shortAdd);
            }

        }


        // GET: ShortAddController/Edit/5
        public ActionResult Edit(int id)
        {
            ShortAddViewModel shortAddViewModel = _shortAddService.GetShortAddByIdViewModel(id);
            var editShortAdd = _shortAddService.GetShortAddById(id);

            shortAddViewModel.CarsList = new List<Car>();
            shortAddViewModel.CarsList = _carService.GetAllCars();


            return View(shortAddViewModel);
        }

        // POST: ShortAddController/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ShortAddViewModel shortAdd)
        {
            
            Dictionary<string, string> modelErrors = _shortAddService.CheckShortAddModelErrors(shortAdd);


            foreach (var key in modelErrors)
            {
                string field = key.Key;
                string error = key.Value;

                ModelState.AddModelError(field, error);
            }
            if (ModelState.IsValid)
            {
                _shortAddService.UpdateShortAddInfos(shortAdd);
                return RedirectToAction("Admin");
            }
            else
            {
                return View(shortAdd);
            }
        }




        // GET: ShortAddController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ShortAddController/Delete/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            {
                _shortAddService.DeleteShortAdd(id);
                return RedirectToAction("Admin");
            }
        }
    }
}
