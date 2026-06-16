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
    public class CarController : Controller
    {

        private readonly ICarService _carService;
        private readonly ICarRepository _carRepository;
        private readonly IBrandService _brandService;
        private readonly ICarModelService _carModelService;
        private readonly IFinishTypeService _finishTypeService;
        private readonly IFinishTypeRepository _finishTypeRepository;
        private readonly IFixService _fixService;
        private readonly IFixRepository _fixRepository;

        public CarController(ICarService carService, ICarRepository carRepository,
            IBrandService brandService, ICarModelService carModelService, IFinishTypeService finishTypeService, IFinishTypeRepository finishTypeRepository,
            IFixService fixService, IFixRepository fixRepository)
        {
            _carService = carService;
            _carRepository = carRepository;
            _brandService = brandService;
            _carModelService = carModelService;
            _finishTypeService = finishTypeService;
            _finishTypeRepository = finishTypeRepository;
            _fixService = fixService;
            _fixRepository = fixRepository;
        }


        // GET: CarController
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]

        // GET: View only for registered admin user. Car list to see all Cars.
        public IActionResult Admin()
        {
            ViewBag.Brands = _brandService.GetAllBrands();
            ViewBag.CarModels = _carModelService.GetAllCarModels();
            ViewBag.FinishTypes = _finishTypeService.GetAllFinishTypes();
            
            return View(_carService.GetAllCarsViewModel().OrderByDescending(f => f.CarId));
        }



        [Authorize]

        // GET: View only for registered admin user. Car list to see one Cars.
        public IActionResult Read(int id)
        {
            ViewBag.Brands = _brandService.GetAllBrands();
            ViewBag.CarModels = _carModelService.GetAllCarModels();
            ViewBag.FinishTypes = _finishTypeService.GetAllFinishTypes();

            CarViewModel CarViewModel = _carService.GetCarByIdViewModel(id);
            var editCar = _carService.GetCarById(id);


            CarViewModel.CarBrands = new List<Brand>();
            CarViewModel.CarBrands = _brandService.GetAllBrands();

            CarViewModel.CarModels = new List<CarModel>();
            CarViewModel.CarModels = _carModelService.GetAllCarModels();

            CarViewModel.FinishTypes = new List<FinishType>();
            CarViewModel.FinishTypes = _finishTypeService.GetAllFinishTypes();


            //CarViewModel.CarFixesList = new List<FinishType>();
            //CarViewModel.CarFixesList = _fixService.GetAllFixes();
            //CarViewModel.AssociatedFixIds = CarViewModel.AssociatedFixIds;

            CarViewModel.CarModels = new List<CarModel>();
            CarViewModel.CarModels = _carModelService.GetAllCarModels();
            CarViewModel.CarModelId = CarViewModel.CarModelId;

            return View(CarViewModel);
        }





        // GET: CarController/Details/5
        public IActionResult Details(int id)
        {
            IEnumerable<CarViewModel> Cars = _carService.GetAllCarsViewModel();
            return View();
        }

        // GET: CarController/Create
        [Authorize]

        public ViewResult Create(int id)
        {
            ViewBag.Fixes = _fixService.GetAllFixes().Where(f => f.AssociatedCarId == id);

            CarViewModel CarViewModel = new CarViewModel();
            CarViewModel.Car = new Car();

            CarViewModel.CarBrands = new List<Brand>();
            CarViewModel.CarBrands = _brandService.GetAllBrands();

            CarViewModel.CarModels = new List<CarModel>();
            CarViewModel.CarModels = _carModelService.GetAllCarModels();

            CarViewModel.FinishTypes = new List<FinishType>();
            CarViewModel.FinishTypes = _finishTypeService.GetAllFinishTypes();

            CarViewModel.CarFixesViewModelList = new List<FixViewModel> { new FixViewModel() };


            return View(CarViewModel);
        }


        // GET: CarController/Create
        [Authorize]

        public ViewResult ConfirmCreated()
        {
            return View();
        }



        //// POST: CarController/Create
        //[Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CarViewModel Car)
        {

            var transaction = _carService.BeginTransaction();

            try
            {
                

                foreach (var fix  in Car.CarFixesViewModelList) 
                {
                    Dictionary<string, string> modelErrorsForFixes = _fixService.CheckFixModelErrors(fix);

                    foreach (var key in modelErrorsForFixes)
                    {
                        string field = key.Key;
                        string error = key.Value;

                        ModelState.AddModelError(field, error);
                    }
                }

                Dictionary<string, string> modelErrorsForCar = _carService.CheckCarModelErrors(Car);

                foreach (var key in modelErrorsForCar)
                {
                    string field = key.Key;
                    string error = key.Value;

                    ModelState.AddModelError(field, error);
                }
                if (ModelState.IsValid)
                {

                    // var to retrieve Car.Id generated automatically via SQL
                    var createdCar = _carService.SaveCar(Car);

                    return RedirectToAction("ConfirmCreated");
                    //ViewBag.Fixes = _fixService.GetAllFixes().Where(f => f.AssociatedCarId == Car.CarId);

                    //return View(Car);

                }
                else
                {
                    //reload menus for brands car models finishtypes

                    Car.CarBrands = new List<Brand>();
                    Car.CarBrands = _brandService.GetAllBrands();

                    Car.CarModels = new List<CarModel>();
                    Car.CarModels = _carModelService.GetAllCarModels();

                    Car.FinishTypes = new List<FinishType>();
                    Car.FinishTypes = _finishTypeService.GetAllFinishTypes();
                    return View(Car);
                }
            }
            catch(Exception)
            {
                await transaction.Result.RollbackAsync();
                throw;
            }


        }
        //// GET: CarController/Create after newly a created fix
        //[Authorize]


        //public ViewResult CreateAfterFixCreated(int id)
        //{

        //    ViewBag.Fixes = _fixService.GetAllFixes().Where(f => f.AssociatedCarId == id);
        //    //ViewBag.Fixes = _fixService.GetAllFixes();


        //    CarViewModel CarViewModel = new CarViewModel();

        //    CarViewModel.CarId = _carRepository.GetMaxCarId() + 1;

        //    CarViewModel.CarBrands = new List<Brand>();
        //    CarViewModel.CarBrands = _brandService.GetAllBrands();

        //    CarViewModel.CarModels = new List<CarModel>();
        //    CarViewModel.CarModels = _carModelService.GetAllCarModels();

        //    CarViewModel.FinishTypes = new List<FinishType>();
        //    CarViewModel.FinishTypes = _finishTypeService.GetAllFinishTypes();



        //    return View(CarViewModel);
        //}

        //// POST: CarController/Create
        //[Authorize]
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult CreateAfterFixCreated(CarViewModel Car)
        //{

        //    Dictionary<string, string> modelErrors = _carService.CheckCarModelErrors(Car);


        //    foreach (var key in modelErrors)
        //    {
        //        string field = key.Key;
        //        string error = key.Value;

        //        ModelState.AddModelError(field, error);
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        _carService.SaveCar(Car);
        //        return RedirectToAction("Admin");
        //    }
        //    else
        //    {
        //        return View(Car);
        //    }

        //}

        // GET: CarController/Edit/5
        public ActionResult Edit(int id)
        {

            ViewBag.Fixes = _fixService.GetAllFixes().Where(f => f.AssociatedCarId == id);
            
            CarViewModel CarViewModel = _carService.GetCarByIdViewModel(id);
            //var editCar = _carService.GetCarById(id);


            CarViewModel.CarBrands = new List<Brand>();
            CarViewModel.CarBrands = _brandService.GetAllBrands();

            CarViewModel.CarModels = new List<CarModel>();
            CarViewModel.CarModels = _carModelService.GetAllCarModels();
            CarViewModel.CarModelId = CarViewModel.CarModelId;

            CarViewModel.FinishTypes = new List<FinishType>();
            CarViewModel.FinishTypes = _finishTypeService.GetAllFinishTypes();


            //CarViewModel.CarFixesList = new List<Fix>();
            //CarViewModel.CarFixesList = _fixService.GetAllFixes();
            //CarViewModel.AssociatedFixIds = CarViewModel.AssociatedFixIds;




            return View(CarViewModel);
        }

        // POST: CarController/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CarViewModel CarViewModel)
        {
            
            Dictionary<string, string> modelErrors = _carService.CheckCarModelErrors(CarViewModel);


            foreach (var key in modelErrors)
            {
                string field = key.Key;
                string error = key.Value;

                ModelState.AddModelError(field, error);
            }
            if (ModelState.IsValid)
            {
                _carService.UpdateCarInfos(CarViewModel);
                return RedirectToAction("Admin");
            }
            else
            {
                return View(CarViewModel);
            }
        }

        public JsonResult GetModelByBrandId(int brandId)
        {
            return Json(_carModelService.GetAllCarModels().Where(b => b.AssociatedBrandId == brandId).ToList());
        }








        // GET: CarController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CarController/Delete/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            {
                _carService.DeleteCar(id);
                return RedirectToAction("Admin");
            }
        }
    }
}
