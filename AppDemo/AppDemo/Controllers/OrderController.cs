using AppDemo.Data;
using AppDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;

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
