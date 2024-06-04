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
    }
}
