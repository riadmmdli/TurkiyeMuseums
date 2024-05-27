using Microsoft.AspNetCore.Mvc;
using turkey_museum.Repositories.Abstract;

namespace turkey_museum.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly IMuseumService _museumService;
        
        public HomeController(IMuseumService museumService)
        {
            _museumService = museumService;
        }
        public IActionResult Index(string term="" , int currentPage = 1 )
        {
            var museums = _museumService.List(term , true , currentPage);
            return View(museums);
        }

        public IActionResult MuseumDetail(int museumId)
        {
            var museum = _museumService.GetById(museumId);
            return View(museum);
        }

        
    }
}
