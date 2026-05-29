using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P5WebApp.Models.Entities;
using P5WebApp.Models.Repositories;
using P5WebApp.Models.Services;
using P5WebApp.Models.ViewModels;

namespace P5WebApp.Controllers
{
    public class BrandController : Controller
    {

        private readonly IBrandService _brandService;
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandService brandService, IBrandRepository brandRepository)
        {
            _brandService = brandService;
            _brandRepository = brandRepository;
        }


        // GET: BrandController
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]

        // GET: View only for registered admin user. Brand list to see all brands.
        public IActionResult Admin()
        {
            return View(_brandService.GetAllBrandsViewModel().OrderByDescending(b => b.BrandId));
        }


        // GET: BrandController/Details/5
        public IActionResult Details(int id)
        {
            IEnumerable<BrandViewModel> brands = _brandService.GetAllBrandsViewModel();
            return View();
        }

        // GET: BrandController/Create
        [Authorize]

        public ViewResult Create()
        {
            return View();
        }

        // POST: BrandController/Create
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BrandViewModel brand)
        {
            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}
            if (ModelState.IsValid)
            {
                _brandService.SaveBrand(brand);
                return RedirectToAction("Admin");
            }
            else
            {
                return View(brand);
            }

        }

        // GET: BrandController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: BrandController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BrandViewModel brandViewModel)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
            //if (ModelState.IsValid)
            //{
            //    _brandService.SaveBrand(brand);
            //    return RedirectToAction("Admin");
            //}
            //else
            //{
            //    return View(brand);
            //}
        }

        // GET: BrandController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BrandController/Delete/5
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            //try
            //{
            //    return RedirectToAction(nameof(Index));
            //}
            //catch
            //{
            //    return View();
            //}


            {
                _brandService.DeleteBrand(id);
                return RedirectToAction("Admin");
            }



        }
    }
}
