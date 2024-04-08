using Microsoft.AspNetCore.Mvc;
using PetShop.Client.Models;
using PetShop.Services;
using System.Diagnostics;

namespace PetShop.Client.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IAnimalsService _animalService;

        public HomeController(ILogger<HomeController> logger,IAnimalsService animalService)
        {
            _logger = logger;
            _animalService = animalService;
        }

        public async Task<IActionResult> Index()
        {
            var allAnimals = await _animalService.GetAllAnimals();
            var top2Animals = _animalService.GetTopCommentedAnimals(allAnimals);
            return View(top2Animals);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
