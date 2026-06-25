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
    public class FixController : Controller
    {

        private readonly IFixService _fixService;
        private readonly IFixRepository _fixRepository;
        private readonly ICarService _carService;
        private readonly ICarRepository _carRepository;
        private readonly IBrandService _brandService;
        private readonly ICarModelService _carModelService;
        private readonly IFinishTypeService _finishTypeService;
        private readonly IFinishTypeRepository _finishTypeRepository;

        public FixController(IFixService fixService, IFixRepository fixRepository, ICarService carService, ICarRepository carRepository,
        IBrandService brandService, ICarModelService carModelService, IFinishTypeService finishTypeService, IFinishTypeRepository finishTypeRepository)
        {
            _fixService = fixService;
            _fixRepository = fixRepository;
            _carService = carService;
            _carRepository = carRepository;
            _brandService = brandService;
            _carModelService = carModelService;
            _finishTypeService = finishTypeService;
            _finishTypeRepository = finishTypeRepository;
        }


        // GET: FixController
        public ActionResult Index()
        {
            return View();
        }



        // GET: FixController/Details/5
        public IActionResult Details(int id)
        {
            IEnumerable<FixViewModel> Fixs = _fixService.GetAllFixesViewModel();
            return View();
        }

        // GET: FixController/Create
        [Authorize]


        public ViewResult Create(int id)
        {
            FixViewModel FixViewModel = new FixViewModel();
            //FixViewModel.AssociatedCarId = _carRepository.GetMaxCarId();

            return View(FixViewModel);
        }

        // POST: FixController/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(FixViewModel Fix)
        {

            Dictionary<string, string> modelErrors = _fixService.CheckFixModelErrors(Fix);


            foreach (var key in modelErrors)
            {
                string field = key.Key;
                string error = key.Value;

                ModelState.AddModelError(field, error);
            }
            if (ModelState.IsValid)
            {
                _fixService.SaveFix(Fix);
                return RedirectToAction("Create", "Car");
            }
            else
            {
                return View(Fix);
            }

        }

        // GET: FixController/Edit/5
        public ActionResult Edit(int id)
        {
            FixViewModel FixViewModel = _fixService.GetFixByIdViewModel(id);
            return View(FixViewModel);
        }

        // POST: FixController/Edit/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(FixViewModel Fix)
        {
            
            Dictionary<string, string> modelErrors = _fixService.CheckFixModelErrors(Fix);


            foreach (var key in modelErrors)
            {
                string field = key.Key;
                string error = key.Value;

                ModelState.AddModelError(field, error);
            }
            if (ModelState.IsValid)
            {
                _fixService.UpdateFixInfos(Fix);
                return RedirectToAction("Edit", "Car");
            }
            else
            {
                return View(Fix);
            }
        }




        // GET: FixController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: FixController/Delete/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            {
                _fixService.DeleteFix(id);
                return RedirectToAction("Create", "Car");

            }
        }
    }
}
