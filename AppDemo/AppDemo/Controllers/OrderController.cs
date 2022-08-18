using AppDemo.Data;
using AppDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AppDemo.Controllers
{
    public class OrderController : Controller
    {
        //khai báo ApplicationDbContext để truy xuất và thay đổi dữ liệu của bảng
        private ApplicationDbContext context;
        public OrderController(ApplicationDbContext applicationDbContext)
        {
            context = applicationDbContext;
        }

        [HttpPost]
        public IActionResult Make(int id, int quantity)
        {
            //tạo Order mới
            var order = new Order();
            //set giá trị trong từng thuộc tính của Order
            var book = context.Book.Find(id);
            order.Book = book;
            order.BookId = id;
            order.OrderQuantity = quantity;
            order.OrderPrice = book.Price * quantity;
            order.OrderDate = DateTime.Now;
            order.UserEmail = User.Identity.Name;
            //add Order vào DB
            context.Order.Add(order);
            //trừ quantity của mobile
            book.Quantity -= quantity;
            context.Book.Update(book);
            //lưu cập nhật vào DB
            context.SaveChanges();
            //gửi về thông báo order thành công
            TempData["Success"] = "Order book successfully !";
            //redirect về trang mobile store
            return RedirectToAction("Store", "Book");
        }
    }
}
