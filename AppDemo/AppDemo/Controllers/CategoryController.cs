using Microsoft.AspNetCore.Mvc;

namespace AppDemo.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
