using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1670.Data;
using Project1670.Models;
using System;
using System.Data;
using System.Linq;
using System.Reflection;

namespace Project1670.Controllers
{
    public class OrderController : Controller
    {
        private readonly ApplicationDbContext context;

        public OrderController(ApplicationDbContext context)
        {
            this.context = context;
        }
        [Authorize(Roles = "Customer")]
        public IActionResult Add(int id, int quantity)
        {
            var order = new Order();
            //set giá trị trong từng thuộc tính của Order
            var book = context.Books.Find(id);
            order.Book = book;
            order.BookId = id;
            order.OrderQuantity = quantity;
            order.OrderPrice = book.Price * quantity;
            order.OrderDate = DateTime.Now;
            order.UserEmail = User.Identity.Name;
            //add Order vào DB
            context.Orders.Add(order);
            //trừ quantity của book
            book.Quantity -= quantity;
            context.Books.Update(book);
            //lưu cập nhật vào DB
            context.SaveChanges();
            //gửi về thông báo order thành công
            TempData["Success"] = "Order book successfully !";
            //redirect về trang book store
            return RedirectToAction("List", "Book");
        }
        [Authorize(Roles = "Customer")]
        public IActionResult Order()
        {
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;

            //lấy ra dữ liệu từ bảng Book và lưu vào list
            var books = context.Books.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Books = books;

            //lấy ra dữ liệu từ bảng Order và lưu vào list
            var orders = context.Orders.ToList();
            return View(orders);
        }
        [Authorize(Roles = "StoreOwner")]
        public IActionResult CustOrder()
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            var books = context.Books.ToList();
            ViewBag.Books = books;
            var orders = context.Orders.ToList();
            return View(orders);
        }
        [Authorize(Roles = "Customer")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                //tìm ra object order có id được yêu cầu
                var order = context.Orders.Find(id);

                //xóa object order vừa tìm thấy
                context.Orders.Remove(order);
                var book = context.Books.Find(order.BookId);
                book.Quantity += order.OrderQuantity;
                context.Books.Update(book);

                //lưu lại thay đổi trong db
                context.SaveChanges();

                //gửi thông báo về trang Index
                TempData["Message"] = "Delete book successfully !";
                return RedirectToAction("Order", order);
            }
        }
    }
}
