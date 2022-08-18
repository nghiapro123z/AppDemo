using AppDemo.Data;
using AppDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AppDemo.Controllers
{
    public class BookController : Controller
    {
        private ApplicationDbContext context;
        public BookController(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }
        public IActionResult Index()
        {
            var books = context.Book.ToList();
            return View(books);
        }
        public IActionResult Store()
        {
            return View(context.Book.ToList());
        }
    }
}
