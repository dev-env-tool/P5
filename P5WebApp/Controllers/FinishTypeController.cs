using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Identity.Client;
using NuGet.Protocol.Core.Types;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.Services;
using P5WebApp.Models.ViewModels;

namespace P5WebApp.Controllers
{
    public class FinishTypeController : Controller
    {

        private readonly IFinishTypeService _finishTypeService;
        private readonly IFinishTypeRepository _finishTypeRepository;
        private readonly IBrandService _brandService;
        private readonly ICarModelService _carModelService;
        private readonly ICarModelRepository _carModelRepository;

        public FinishTypeController(IFinishTypeService finishTypeService, IFinishTypeRepository finishTypeRepository,
            IBrandService brandService, ICarModelService carModelService, ICarModelRepository carModelRepository)
        {
            _finishTypeService = finishTypeService;
            _finishTypeRepository = finishTypeRepository;
            _brandService = brandService;
            _carModelService = carModelService;
            _carModelRepository = carModelRepository;
        }


        // GET: FinishTypeController
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]

        // GET: View only for registered admin user. FinishType list to see all FinishTypes.
        public IActionResult Admin()
        {
            ViewBag.Brands = _brandService.GetAllBrands();
            ViewBag.CarModels = _carModelService.GetAllCarModels();
            return View(_finishTypeService.GetAllFinishTypesViewModel().OrderByDescending(f => f.FinishTypeId));
        }


        // GET: FinishTypeController/Details/5
        public IActionResult Details(int id)
        {
            IEnumerable<FinishTypeViewModel> FinishTypes = _finishTypeService.GetAllFinishTypesViewModel();
            return View();
        }

        // GET: FinishTypeController/Create
        [Authorize]


        public ViewResult Create(int id)
        {

            FinishTypeViewModel FinishTypeViewModel = new FinishTypeViewModel();
            FinishTypeViewModel.Brands = new List<Brand>();
            FinishTypeViewModel.Brands = _brandService.GetAllBrands();

            //FinishTypeViewModel.CarModels = new List<CarModel>();
            //FinishTypeViewModel.CarModels = _carModelService.GetAllCarModels();

            return View(FinishTypeViewModel);
        }



        //[HttpGet]
        //public JsonResult GetCarModelList([FromQuery] int[] id)
        //{
        //    if (id == null || id.Length == 0)
        //    { 
        //        return Json(new List<object>());
        //    }

        //    var selectedCarModels = _carModelService.GetAllCarModels()
        //        .Where(x => id.Contains(x.AssociatedBrandId))
        //        .Select(x => new { x.Id, x.Name })
        //        .ToList();

        //    return Json(selectedCarModels);


        //}
        [HttpGet]
        public JsonResult GetCarModelList(int[] id)
        {
            var selectedCarModels = _carModelRepository.GetCarModelsByBrandIds(id)
                .Select(x => new { x.Id, x.Name })
                .ToList();

            return Json(selectedCarModels);

        }

        // POST: FinishTypeController/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FinishTypeViewModel FinishType)
        {

            Dictionary<string, string> modelErrors = _finishTypeService.CheckFinishTypeModelErrors(FinishType);


            foreach (var key in modelErrors)
            {
                string field = key.Key;
                string error = key.Value;

                ModelState.AddModelError(field, error);
            }
            if (ModelState.IsValid)
            {
                _finishTypeService.SaveFinishType(FinishType);
                return RedirectToAction("Admin");
            }
            else
            {
                return View(FinishType);
            }

        }

        // GET: FinishTypeController/Edit/5
        public ActionResult Edit(int id)
        {
            FinishTypeViewModel FinishTypeViewModel = _finishTypeService.GetFinishTypeByIdViewModel(id);
            var editFinishType = _finishTypeService.GetFinishTypeById(id);
            FinishTypeViewModel.Brands = new List<Brand>();
            FinishTypeViewModel.Brands = _brandService.GetAllBrands();
            FinishTypeViewModel.AssociatedBrandsIds = FinishTypeViewModel.AssociatedBrandsIds;

            FinishTypeViewModel.CarModels = new List<CarModel>();
            FinishTypeViewModel.CarModels = _carModelService.GetAllCarModels();
            FinishTypeViewModel.AssociatedCarModelIds = FinishTypeViewModel.AssociatedCarModelIds;

            return View(FinishTypeViewModel);
        }

        // POST: FinishTypeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FinishTypeViewModel FinishType)
        {
            
            Dictionary<string, string> modelErrors = _finishTypeService.CheckFinishTypeModelErrors(FinishType);


            foreach (var key in modelErrors)
            {
                string field = key.Key;
                string error = key.Value;

                ModelState.AddModelError(field, error);
            }
            if (ModelState.IsValid)
            {
                _finishTypeService.UpdateFinishType(FinishType);
                return RedirectToAction("Admin");
            }
            else
            {
                return View(FinishType);
            }
        }

        public JsonResult GetModelByBrandId(int brandId)
        {
            return Json(_carModelService.GetAllCarModels().Where(b => b.AssociatedBrandId == brandId).ToList());
        }








        // GET: FinishTypeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FinishTypeController/Delete/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            {
                _finishTypeService.DeleteFinishType(id);
                return RedirectToAction("Admin");
            }
        }
    }
}
