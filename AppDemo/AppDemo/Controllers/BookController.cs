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
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            var books = context.Book.OrderByDescending(b => b.Id).ToList();
            return View(books);
        }
        [Authorize(Roles = "Customer")]
        public IActionResult Store()
        {
            return View(context.Book.ToList());
        }
        [Authorize(Roles = "Admin,Customer")]
        public IActionResult Detail(int id)
        {
            var book = context.Book.Include(m => m.Category)  
                                        .Include(b => b.Author)                       
                                        .FirstOrDefault(b => b.Id == id);
            return View(book);
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            var mobile = context.Book.Find(id);
            context.Book.Remove(mobile);
            context.SaveChanges();
            TempData["Message"] = "Delete mobile successfully !";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Category = context.Category.ToList();
            ViewBag.Author = context.Author.ToList();
            return View();
        }

        
        //hàm 2: nhận và xử lý dữ liệu được gửi từ form
        [HttpPost]
        public IActionResult Create(Book book )
        {
            //check tính hợp lệ của dữ liệu 
            if (ModelState.IsValid)
            {
                //add dữ liệu vào DB
                context.Add(book);
                context.SaveChanges();
                //hiển thị thông báo thành công về view
                TempData["Message"] = "Add book successfully !";
                //quay ngược về trang index
                return RedirectToAction(nameof(Index));
            }
            //nếu dữ liệu không hợp lệ thì trả về form để nhập lại
            return View(book);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Category = context.Category.ToList();
            ViewBag.Author = context.Author.ToList();
            return View(context.Book.Find(id));
        }


        [HttpPost]
        public IActionResult Edit(Book book)
        {
            //check tính hợp lệ của dữ liệu 
            if (ModelState.IsValid)
            {
                //update dữ liệu vào DB
                context.Update(book);
                context.SaveChanges();
                //hiển thị thông báo thành công về view
                TempData["Message"] = "Edit book successfully !";
                //quay ngược về trang index
                return RedirectToAction(nameof(Index));
            }
            //nếu dữ liệu không hợp lệ thì trả về form để nhập lại
            return View(book);
        }
    }
}
