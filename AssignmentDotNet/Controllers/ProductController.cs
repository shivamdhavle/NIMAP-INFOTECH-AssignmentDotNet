using AssignmentDotNet.Models;
using AssignmentDotNet.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AssignmentDotNet.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly ProductDb conn;

        public ProductController(IProductService _productService, ProductDb context)
        {
            productService = _productService;
            conn = context;
        }

        public IActionResult Index(int page = 1, int pageSize = 10)
        {
            var products = productService.GetProducts(); 
            var totalProducts = products.Count();
            var totalPages = (int)Math.Ceiling(totalProducts / (double)pageSize);

            var paginatedProducts = products
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = totalPages;

            return View(paginatedProducts);
        }

        [HttpGet]
        public IActionResult PostProduct()
        {
           
            ViewBag.CategoryList = new SelectList(conn.categories, "CategoryId", "CategoryName");
            return View();
        }

        [HttpPost]
        public IActionResult PostProduct(Product product)
        {
            try
            {
                productService.AddProduct(product);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(product);
            }
        }

        public IActionResult EditProduct(int id)
        {
            try
            {
                var product = productService.GetProductById(id);
                ViewBag.CategoryList = new SelectList(conn.categories, "CategoryId", "CategoryName");
                return View(product);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult EditProduct(Product product)
        {
            try
            {
                productService.UpdateProduct(product);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(product);
            }
        }

        public IActionResult DeleteProduct(int id)
        {
            try
            {
                productService.DeleteProduct(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
