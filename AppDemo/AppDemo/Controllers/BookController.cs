using Microsoft.AspNetCore.Mvc;

namespace AppDemo.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
