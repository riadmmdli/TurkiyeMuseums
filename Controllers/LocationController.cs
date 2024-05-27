using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using turkey_museum.Models.Domain;
using turkey_museum.Repositories.Abstract;

namespace turkey_museum.Controllers
{
    [Authorize]
    public class LocationController : Controller
    {   
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Location model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _locationService.Add(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(Add));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }
            
            
        }

        public IActionResult Edit(int id)
        {
            var data = _locationService.GetById(id);
            return View(data);
        }
        [HttpPost]
        public IActionResult Update(Location model)
        {
            if (!ModelState.IsValid)
                return View(model);
            var result = _locationService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(LocationList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }

            
        }

        public IActionResult LocationList() 
        {
            var data = this._locationService.List().ToList();
            return View(data);
        }

        public IActionResult Delete(int id)
        {
            var result = _locationService.Delete(id);
            return RedirectToAction(nameof(LocationList));
        }



    }
}
