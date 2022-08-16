using Microsoft.AspNetCore.Mvc;

namespace AppDemo.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
