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
        //attribute
        private readonly ApplicationDbContext context;
        public BookController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [Authorize(Roles = "StoreOwner")]
        public IActionResult Index()
        {
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;

            return View(context.Books.ToList());
        }
            
        
        public IActionResult List()
        {
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;

            return View(context.Books.ToList());
        }


        public IActionResult Detail(int id)
        {
            var book = context.Books.Include(b => b.Category).FirstOrDefault(b => b.Id == id);
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;

            return View(book);
        }

        [Authorize(Roles = "StoreOwner")]
        [HttpGet]
        public IActionResult Add()
        {
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;

            return View();
        }


        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        public IActionResult Add(Book book)
        {
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;

            //nếu người dùng nhập đủ và đúng thông tin vào form
            //thì dữ liệu sẽ được add vào database
            if (ModelState.IsValid)
            {
                context.Books.Add(book);
                context.SaveChanges();
                TempData["Message"] = "Add book successfully !";
                return RedirectToAction("Index");
            }
            //ngược lại nếu người dùng nhập sai thì quay ngược trở lại form để add
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
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;

            return View(context.Books.Find(id));
        }


        [Authorize(Roles = "StoreOwner")]
        [HttpPost]
        public IActionResult Edit(Book book)
        {
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
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
                //nếu id không tìm thấy thì trả về not found
                return NotFound();
            }
            else
            {
                //tìm ra object book có id được yêu cầu
                var book = context.Books.Find(id);

                //xóa object book vừa tìm thấy
                context.Books.Remove(book);

                //lưu lại thay đổi trong db
                context.SaveChanges();

                //gửi thông báo về trang Index
                TempData["Message"] = "Delete book successfully !";

                //quay trở lại trang index sau khi thành công
                //return RedirectToAction("Index");
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Search(string keyword)
        {
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
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
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
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
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;

            var books = context.Books.Where(b => b.CategoryId == id).ToList();
            return View("Search", books);
        }
        public IActionResult BookByCateSO(int? id)
        {
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;

            var books = context.Books.Where(b => b.CategoryId == id).ToList();
            return View("SOS", books);
        }

        public IActionResult SortNameAsc()
        {
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;

            return View("List", context.Books.OrderBy(s => s.Title).ToList());
        }

        public IActionResult SortNameDesc()
        {
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;

            return View("List", context.Books.OrderByDescending(s => s.Title).ToList());
        }
    }
}
