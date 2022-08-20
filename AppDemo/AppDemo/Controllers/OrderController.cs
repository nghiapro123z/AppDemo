﻿using AppDemo.Data;
using AppDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AppDemo.Controllers
{
    public class OrderController : Controller
    {
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
            var mobile = context.Book.Find(id);
            order.Book = mobile;
            order.BookId = id;
            order.OrderQuantity = quantity;
            order.OrderPrice = mobile.Price * quantity;
            order.OrderDate = DateTime.Now;
            order.UserEmail = User.Identity.Name;
            //add Order vào DB
            context.Order.Add(order);
            //trừ quantity của mobile
            mobile.Quantity -= quantity;
            context.Book.Update(mobile);
            //lưu cập nhật vào DB
            context.SaveChanges();
            //gửi về thông báo order thành công
            TempData["Success"] = "Order mobile successfully !";
            //redirect về trang mobile store
            return RedirectToAction("Store", "Mobile");
        }
    }
}
