using AppDemo.Data;
using AppDemo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AppDemo.Controllers
{
    public class CategoryController : Controller
    {
        private ApplicationDbContext context;
        public CategoryController (ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }
        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            return View(context.Category.ToList());
        }
        public IActionResult Delete(int id)
        {
            var Category = context.Category.Find(id);
            context.Category.Remove(Category);
            context.SaveChanges();
            TempData["Message"] = "Delete brand successfully !";
            return RedirectToAction("Index");
        }
         public IActionResult Detail (int id)
        {
            var category = context.Category.Include(b => b.Books)  //Brand - Mobile : 1 - M
                                       //Brand - Country : M - 1
                                     .FirstOrDefault(b => b.Id == id);
            return View(category);
        }

        //hàm 2: nhận và xử lý dữ liệu được gửi từ form
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add (Category category)
        {
            //check tính hợp lệ của dữ liệu 
            if (ModelState.IsValid)
            {
                //add dữ liệu vào DB
                context.Add(category);
                context.SaveChanges();
                //hiển thị thông báo thành công về view
                TempData["Message"] = "Add category successfully !";
                //quay ngược về trang index
                return RedirectToAction(nameof(Index));
            }
            //nếu dữ liệu không hợp lệ thì trả về form để nhập lại
            return View(category);
        }

        //sửa dữ liệu của bảng
        [HttpGet]
        public IActionResult Edit(int id)
        {

            return View(context.Category.Find(id));
        }

        [HttpPost]
        public IActionResult Edit (Category category)
        {
            //check tính hợp lệ của dữ liệu 
            if (ModelState.IsValid)
            {
                //update dữ liệu vào DB
                context.Update(category);
                context.SaveChanges();
                //hiển thị thông báo thành công về view
                TempData["Message"] = "Edit category successfully !";
                //quay ngược về trang index
                return RedirectToAction(nameof(Index));
            }
            TempData["Message"] = "Edit category FAil !";
            //nếu dữ liệu không hợp lệ thì trả về form để nhập lại
            return View(category);
        }
    }
}