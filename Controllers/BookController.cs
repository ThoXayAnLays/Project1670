using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1670.Data;
using Project1670.Models;
using System.Data;
using System.Linq;

namespace Project1670.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext context;
        public BookController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [Authorize(Roles = "StoreOwner")]
        public IActionResult Index()
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            return View(context.Books.ToList());
        }
            
        
        public IActionResult List()
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            return View(context.Books.ToList());
        }


        public IActionResult Detail(int id)
        {
            var book = context.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == id);
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            return View(book);
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public IActionResult Add()
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            return View();
        }


        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        public IActionResult Add(Book book)
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                TempData["Message"] = "Add book successfully !";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = context.Categories.ToList();
                return View(book);
            }
        }


        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            return View(context.Books.Find(id));
        }


        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            if (ModelState.IsValid)
            {
                context.Books.Update(book);
                context.SaveChanges();
                TempData["Message"] = "Edit book successfully !";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Categories = context.Categories.ToList();
                return View(book);
            }
        }


        [Authorize(Roles = "StoreOwner")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var book = context.Books.Find(id);
                context.Books.Remove(book);
                context.SaveChanges();
                TempData["Message"] = "Delete book successfully !";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Search(string keyword)
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            var books = context.Books.Where(b => b.Title.Contains(keyword)).ToList();
            if (books.Count == 0)
            {
                TempData["Message"] = "No book found";
            }
            return View("Search",books);
        }

        [HttpPost]
        public IActionResult SOS(string keyword)
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            var books = context.Books.Where(b => b.Title.Contains(keyword)).ToList();
            if (books.Count == 0)
            {
                TempData["Message"] = "No book found";
            }
            return View("SOS", books);
        }
        public IActionResult BookByCateCust(int? id)
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            var books = context.Books.Where(b => b.CategoryId == id).ToList();
            return View("Search", books);
        }
        public IActionResult BookByCateSO(int? id)
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            var books = context.Books.Where(b => b.CategoryId == id).ToList();
            return View("SOS", books);
        }

        public IActionResult SortNameAsc()
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            return View("List", context.Books.OrderBy(s => s.Title).ToList());
        }

        public IActionResult SortNameDesc()
        {
            var categories = context.Categories.ToList();
            ViewBag.Categories = categories;
            return View("List", context.Books.OrderByDescending(s => s.Title).ToList());
        }
    }
}
