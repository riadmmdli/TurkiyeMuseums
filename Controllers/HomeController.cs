using Microsoft.AspNetCore.Mvc;
using TurkiyeMuseums.Repositories.Abstract;

namespace TurkiyeMuseums.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IMuseumService _museumService;
        
        public HomeController(IMuseumService museumService)
        {
            _museumService = museumService;
        }
        public IActionResult Index(string term="" , int currentPage = 1 , int pageSize = 10)
        {
            var museums = _museumService.List(term , true , currentPage);
            return View(museums);
        }

        public IActionResult MuseumDetail(int museumId)
        {
            var museum = _museumService.GetById(museumId);
            return View(museum);
        }
        public ActionResult About()
        {
            return View();
        }


    }
}
