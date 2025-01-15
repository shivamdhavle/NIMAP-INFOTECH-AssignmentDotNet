using AssignmentDotNet.Models;
using AssignmentDotNet.Service;
using Microsoft.AspNetCore.Mvc;

namespace AssignmentDotNet.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }

        // Get all categories (no pagination)
        public IActionResult GetCategory()
        {
            var categories = categoryService.GetCategories(); // Get all categories without pagination

            return View(categories); // Return the list of categories to the view
        }

        // Add a new category (GET)
        [HttpGet]
        public IActionResult PostCategory()
        {
            return View();
        }

        // Add a new category (POST)
        [HttpPost]
        public IActionResult PostCategory(Category category)
        {
            try
            {
                categoryService.AddCategory(category); // Add the category to the service
                return RedirectToAction("GetCategory"); // Redirect back to the category list
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(category); // If error, stay on the form
            }
        }

        // Edit a category (GET)
        public IActionResult EditCategory(int id)
        {
            var category = categoryService.GetCategoryById(id); // Get category by ID
            if (category == null)
            {
                return NotFound(); // Return 404 if category doesn't exist
            }
            return View(category); // Return the category to the view
        }

        // Edit a category (POST)
        [HttpPost]
        public IActionResult EditCategory(Category category)
        {
            try
            {
                categoryService.UpdateCategory(category); // Update the category in the service
                return RedirectToAction("GetCategory"); // Redirect back to the category list
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(category); // If error, stay on the form
            }
        }

        // Delete a category (GET)
        public IActionResult DeleteCategory(int id)
        {
            categoryService.DeleteCategory(id); // Delete the category
            return RedirectToAction("GetCategory"); // Redirect back to the category list
        }
    }
}
