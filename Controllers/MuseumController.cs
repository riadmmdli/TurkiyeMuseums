using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using turkey_museum.Models.Domain;
using turkey_museum.Repositories.Abstract;

namespace turkey_museum.Controllers
{
    [Authorize]
    public class MuseumController : Controller
    {   
        private readonly IMuseumService _museumService;
        private readonly IFileService _fileService;
        private readonly ILocationService _locService;

        public MuseumController(IMuseumService MuseumService, IFileService fileService , ILocationService locService)
        {
            _museumService = MuseumService;
            _fileService = fileService;
            _locService = locService;
        }
        public IActionResult Add()
        {
            var model = new Museum();
            model.LocationList = _locService.List().Select(a => new SelectListItem { Text = a.LocationName, Value= a.Id.ToString()});
            return View(model);
        }
        [HttpPost]
        public IActionResult Add(Museum model)
        {
            model.LocationList = _locService.List().Select(a => new SelectListItem { Text = a.LocationName, Value = a.Id.ToString() });
            if (model.ImageFile != null)
            {
                var fileReult = this._fileService.SaveImage(model.ImageFile);
                if (fileReult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileReult.Item2;
                model.MuseumImage = imageName;
            }
            var result = _museumService.Add(model);
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
            var model = _museumService.GetById(id);
            var selectedLocations = _museumService.GetLocationByMuseumId(model.Id);
            SelectList LocationList = new SelectList(_locService.List(), "Id", "LocationName", selectedLocations);
            model.LocationList = LocationList;
            
            return View(model);
        }
        [HttpPost]
        public IActionResult Edit(Museum model)
        {
            var selectedLocations = _museumService.GetLocationByMuseumId(model.Id);
            SelectList LocationList = new SelectList(_locService.List(), "Id", "LocationName", selectedLocations);
            model.LocationList = LocationList;
            if (!ModelState.IsValid)
                return View(model);
            if (model.ImageFile != null)
            {
                var fileReult = this._fileService.SaveImage(model.ImageFile);
                if (fileReult.Item1 == 0)
                {
                    TempData["msg"] = "File could not saved";
                    return View(model);
                }
                var imageName = fileReult.Item2;
                model.MuseumImage = imageName;
            }
            var result = _museumService.Update(model);
            if (result)
            {
                TempData["msg"] = "Added Successfully";
                return RedirectToAction(nameof(MuseumList));
            }
            else
            {
                TempData["msg"] = "Error on server side";
                return View(model);
            }

            
        }

        public IActionResult MuseumList() 
        {
            var data = this._museumService.List();
            return View(data);
        }
            
        public IActionResult Delete(int id)
        {
            var result = _museumService.Delete(id);
            return RedirectToAction(nameof(MuseumList));
        }



    }
}
