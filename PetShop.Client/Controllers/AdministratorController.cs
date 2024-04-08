using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PetShop.Models.Dtos;
using PetShop.Models.Entities;
using PetShop.Services;
using System.Drawing;

namespace PetShop.Client.Controllers
{
    public class AdministratorController : Controller
    {
        private readonly IAnimalsService _animalService;
        private readonly ICategoriesService _categoriesService;
        private readonly IWebHostEnvironment _webEnviroment;

        public AdministratorController(IAnimalsService animalService,
            ICategoriesService categoriesService,
            IWebHostEnvironment webEnviroment)
        {
            _animalService = animalService;
            _categoriesService = categoriesService;
            _webEnviroment = webEnviroment;
        }

        public async Task<IActionResult> Index(int? id)
        {
            var animals = await _animalService.GetAllAnimals();
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
        public async Task<IActionResult> AddAnimal()
        {
            var animalModel = new AnimalDto();
            await GetCategoriesDropDown();
            return View(animalModel);
        }

        [HttpPost]
        public async Task<IActionResult> AddAnimal(AnimalDto animalModel)
        {
            if (ModelState.IsValid)
            {
                await UploadImage(animalModel);
                await _animalService.AddAnimal(animalModel);
                ModelState.Clear();
                return RedirectToAction("Index");

            }


            await GetCategoriesDropDown();
            return View("AddAnimal",animalModel);


        }

        [HttpGet]
        public async Task<IActionResult> EditAnimal(int? id)
        {
            if (id == null)
            {
                return NotFound("Sorry but there was no result found");
            }
            else
            {
                var animalModel = await _animalService.GetAnimalById((int)id);
                await GetCategoriesDropDown();
                return View(animalModel);
            }

        }

       

        [HttpPost]
        public async Task<IActionResult> EditAnimal(AnimalDto animalModel)
        {
            if (ModelState.IsValid)
            {
                await UploadImage(animalModel);
                await _animalService.UpdateAnimal(animalModel);
                return RedirectToAction("Index");
            }
            else
            {
                await GetCategoriesDropDown();
                return View("EditAnimal", animalModel);
            }

        }

        public async Task<IActionResult> DeleteAnimal(int? id)
        {
            if (id == null)
            {
                return NotFound("Sorry no animal was found");
            }
            else
            {
                //await DeleteImage((int)id);
                await _animalService.DeleteAnimal((int)id);
                return RedirectToAction("Index");
            }

        }


        private async Task UploadImage(AnimalDto animalModel)
        {
            if (animalModel.AnimalPhoto != null)
            {
                string folder = "Images/";
                folder += Guid.NewGuid() + "_" + animalModel.AnimalPhoto.FileName;
                string serverFolder = Path.Combine(_webEnviroment.WebRootPath, folder);
                using (var stream = new FileStream(serverFolder, FileMode.Create))
                {
                    await animalModel.AnimalPhoto.CopyToAsync(stream);
                }
                animalModel.PhotoUri = "/" + folder;
                
            }

        }
        //doesnt work, need to fix the combined path
        private async Task DeleteImage(int id)
        {
            var animalModel = await _animalService.GetAnimalById(id);
            
            
            

            if (animalModel.PhotoUri != null)
            {

                
                string fullPath = Path.Combine(_webEnviroment.WebRootPath, animalModel.PhotoUri.TrimStart('/', '\\'));

                System.IO.File.Delete(fullPath);
            }
        }

        private async Task GetCategoriesDropDown()
        {
            var categories = await _categoriesService.GetAllCategories();
            var categoryNames = categories.Select(c => new SelectListItem { Text = c.Name, Value = c.CategoryId.ToString() });

            ViewBag.Categories = new SelectList(categoryNames, "Value", "Text");
        }
       
    }
    
}
