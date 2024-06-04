using basit_e_ticaret_uygulaması_crud.Models;
using basit_e_ticaret_uygulaması_crud.Services;
using Microsoft.AspNetCore.Mvc;

namespace basit_e_ticaret_uygulaması_crud.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext context;
        public ProductsController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult Index()
        {
            var products = context.Products.OrderByDescending(p => p.Id).ToList();
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductDto productDto)
        {
            if (productDto.ImageFile == null) {
                ModelState.AddModelError("ImageFile", "Ürün görseli gereklidir!");
            }
            if (!ModelState.IsValid) {
            return View(productDto);
            }
            return RedirectToAction("Index", "Products");
        }
    }
}
