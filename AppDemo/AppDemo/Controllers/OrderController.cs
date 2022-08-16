using Microsoft.AspNetCore.Mvc;

namespace AppDemo.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
