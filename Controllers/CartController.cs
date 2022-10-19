using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project1670.Data;
using Project1670.Models;
using System;
using System.Data;
using System.Linq;

namespace Project1670.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext context;

        public CartController(ApplicationDbContext context)
        {
            this.context = context;
        }

        public IActionResult Add(int id, int quantity)
        {
            var cart = new Cart();
            //set giá trị trong từng thuộc tính của Order
            var book = context.Books.Find(id);
            cart.Book = book;
            cart.BookId = id;
            cart.OrderQuantity = quantity;
            cart.OrderPrice = book.Price * quantity;
            cart.OrderDate = DateTime.Now;
            cart.UserEmail = User.Identity.Name;
            //add Order vào DB
            context.Carts.Add(cart);
            //lưu cập nhật vào DB
            context.SaveChanges();
            //gửi về thông báo order thành công
            TempData["Success"] = "Order book successfully !";
            //redirect về trang mobile store
            return RedirectToAction("List", "Book");
        }
        public IActionResult Cart()
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            var books = context.Books.ToList();
            ViewBag.Books = books;
            var carts = context.Carts.ToList();
            return View(carts);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var cart = context.Carts.Find(id);
                context.Carts.Remove(cart);
                context.SaveChanges();
                TempData["Message"] = "Delete book successfully !";
                return RedirectToAction("Cart",cart);
            }
        }
    }
}
