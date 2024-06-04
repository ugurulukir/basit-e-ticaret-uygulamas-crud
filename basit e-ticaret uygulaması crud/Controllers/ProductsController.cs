using basit_e_ticaret_uygulaması_crud.Models;
using basit_e_ticaret_uygulaması_crud.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace basit_e_ticaret_uygulaması_crud.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment environment;

        public ProductsController(ApplicationDbContext context, IWebHostEnvironment environment)
        {
            this.context = context;
            this.environment = environment;
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

            //save the image file

            string newFileName = DateTime.Now.ToString("yyyymmddHHmmssfff");
            newFileName += Path.GetExtension(productDto.ImageFile!.FileName);

            string imageFullPath = environment.WebRootPath + "/products/" + newFileName;
            using(var stream=System.IO.File.Create(imageFullPath))
            {
                productDto.ImageFile.CopyTo(stream);
            }
            return RedirectToAction("Index", "Products");
        }


    }
}
