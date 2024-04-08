using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShop.Services;

namespace PetShop.Client.Controllers
{
    public class CatalogController : Controller
    {
        private readonly IAnimalsService _animalService;
        private readonly ICommentsService _commentService;
        private readonly ICategoriesService _categoryService;

        public CatalogController(IAnimalsService animalService,
            ICommentsService commentService,
            ICategoriesService categoryService)
        {
            _animalService = animalService;
            _commentService = commentService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var animals = await _animalService.GetAllAnimals();
            var categories = await _categoryService.GetAllCategories();
            var categoryNames = categories.Select(c => new SelectListItem { Text = c.Name, Value = c.CategoryId.ToString() });

            ViewBag.Categories = new SelectList(categoryNames, "Value", "Text");

            if (id == null)
            {
                return View(animals);
            }
            else
            {
                var animalsByCategory = await _animalService.GetAnimalsByCategory(animals, (int)id);
                return View(animalsByCategory);
            }
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var animalById = await _animalService.GetAnimalById(id);
            return View(animalById);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(int Animalid, string textToAdd)
        {
            await _commentService.AddComment(Animalid, textToAdd);
            return RedirectToAction("Details", new { id = Animalid });
        }

    }
}
