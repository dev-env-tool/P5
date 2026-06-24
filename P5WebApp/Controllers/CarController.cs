using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Identity.Client;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.Services;
using P5WebApp.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Runtime.ConstrainedExecution;

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
        private readonly IPhotoService _photoService;
        private readonly IPhotoRepository _photoRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CarController(ICarService carService, ICarRepository carRepository,
            IBrandService brandService, ICarModelService carModelService, IFinishTypeService finishTypeService, IFinishTypeRepository finishTypeRepository,
            IFixService fixService, IFixRepository fixRepository, IWebHostEnvironment webHostEnvironment, IPhotoService photoService, IPhotoRepository photoRepository)
        {
            _carService = carService;
            _carRepository = carRepository;
            _brandService = brandService;
            _carModelService = carModelService;
            _finishTypeService = finishTypeService;
            _finishTypeRepository = finishTypeRepository;
            _fixService = fixService;
            _fixRepository = fixRepository;
            _photoService = photoService;
            _photoRepository = photoRepository;
            _webHostEnvironment = webHostEnvironment;
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





        // GET: View only for every user. Car list to see one Car.
        public IActionResult Read(int id)
        {
            ViewBag.Brands = _brandService.GetAllBrands();
            ViewBag.CarModels = _carModelService.GetAllCarModels();
            ViewBag.FinishTypes = _finishTypeService.GetAllFinishTypes();

            CarViewModel CarViewModel = _carService.GetCarByIdViewModel(id);

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
            //ViewBag.Fixes = _fixService.GetAllFixes().Where(f => f.AssociatedCarId == id);

            CarViewModel CarViewModel = new CarViewModel();
            //CarViewModel.Car = new Car();

            CarViewModel.CarBrands = new List<Brand>();
            CarViewModel.CarBrands = _brandService.GetAllBrands();

            CarViewModel.CarModels = new List<CarModel>();
            CarViewModel.CarModels = _carModelService.GetAllCarModels();

            CarViewModel.FinishTypes = new List<FinishType>();
            CarViewModel.FinishTypes = _finishTypeService.GetAllFinishTypes();


            CarViewModel.CarFixesViewModelList = new List<FixViewModel>();


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

            // Remove from memory "dummyfix1980" from CarFixesViewModelList. Avoiding any dummy fix to be recorded in Db
            // "dummyfix1980" comes from the front-end as hidden entry to enable form validation without any fix
            // Hence required and other fix validation attribute work on manual fix entries.

            //FixViewModel dummyfix1980 = new FixViewModel();
                
            //dummyfix1980 = Car.CarFixesViewModelList.SingleOrDefault(f => f.FixDescription == "dummyfix1900");

            //if (dummyfix1980 != null)
            //{
            //    Car.CarFixesViewModelList.Remove(dummyfix1980);
            //}





            // Here, transaction will help data recording into distinct tables.
            // If one object is not valid or complete, then transaction stops and rollbacks the tables in the databse.
            // Rollback means it manages to let the whole database as it was before transaction started.
            try
            {
                if (!TryValidateModel(Car))
                {
                    
                }
                //if (Car.CarFixesViewModelList != null)
                //{ 
                //    foreach (var fix  in Car.CarFixesViewModelList) 
                //    {
                //        Dictionary<string, string> modelErrorsForFixes = _fixService.CheckFixModelErrors(fix);

                //        foreach (var key in modelErrorsForFixes)
                //        {
                //            string field = key.Key;
                //            string error = key.Value;

                //            ModelState.AddModelError(field, error);
                //        }
                //    }
                //}

                //var validationContext = new ValidationContext(Car, null, null);
                //var validationResults = Car.Validate(validationContext);


                //for (int i = 0; i < Car.CarFixesViewModelList.Count; i++)
                //{
                //    var fix = Car.CarFixesViewModelList[i];

                //    var errors = validationResults;


                //    foreach (var error in errors)
                //    {
                //        ModelState.AddModelError($"CarFixesViewModelList[{i}].{error.MemberNames}", error.ErrorMessage);
                //    }
                //}

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
                    // fixes are created via var createdCar = _carService.SaveCar(Car);
                    var createdCar = _carService.SaveCar(Car);


                    if (Car.Photo != null)
                    {
                        string folder = "P5WebApp/P5WebApp/wwwroot/Cars/Images";
                        // Check if the folder exists or not
                        bool isDirExisting = Directory.Exists(folder);
                        // Create the directory in case it doesn't exist
                        if(!isDirExisting)
                        {
                            Directory.CreateDirectory(folder);
                        }
                        // Use a new Guid to create a unique photo Id
                        folder += Guid.NewGuid().ToString() + "_" + Car.Photo.FileName;
                        string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folder);

                        // Copy the uploaded photo and paste it into our new web folder
                        await Car.Photo.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

                        Car.PhotoForDb.PhotoName = Car.Photo.FileName;
                        Car.PhotoForDb.PhotoPath = folder;
                        Car.PhotoForDb.AssociatedCarId = createdCar.CarId;

                        _photoService.SavePhoto(Car.PhotoForDb);
                    }

                    return RedirectToAction("ConfirmCreated");
                    //ViewBag.Fixes = _fixService.GetAllFixes().Where(f => f.AssociatedCarId == Car.CarId);

                    //return View(Car);

                }
                else
                {
                    //ViewBag.Fixes = _fixService.GetAllFixes().Where(f => f.AssociatedCarId == Car.CarId);
                    //reload menus for brands car models finishtypes

                    Car.CarBrands = new List<Brand>();
                    Car.CarBrands = _brandService.GetAllBrands();

                    Car.CarModels = new List<CarModel>();
                    Car.CarModels = _carModelService.GetAllCarModels();

                    Car.FinishTypes = new List<FinishType>();
                    Car.FinishTypes = _finishTypeService.GetAllFinishTypes();
                    //ModelState.Remove("CarBuyDate");
                    //foreach (var error in ModelState["CarBuyDate"]?.Errors ?? Enumerable.Empty<ModelError>())
                    //{
                    //    Console.WriteLine(error.ErrorMessage);
                    //    ViewBag.CarBuyDateErrors = ModelState["CarBuyDate"]?.Errors.Select(e => e.ErrorMessage).ToList();
                    //}
                    //ModelState.AddModelError("CarBuyDate", "Test message d'erreur manuel");
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
            var photos = _photoService.GetAllPhotos().ToList();

            ViewBag.PhotoPath = photos.FirstOrDefault(p => p.AssociatedCarId == id);
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
                int photoId = _photoService.GetPhotoIdByAssociatedCarId(id);
                if (photoId != 0)
                { 
                    _photoService.DeletePhoto(photoId);
                }
                _carService.DeleteCar(id);
                return RedirectToAction("Admin");
            }
        }
    }
}
