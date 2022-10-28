using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project1670.Data;
using Project1670.Models;
using System.Data;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace Project1670.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext context;

        public CategoryController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Index()
        {
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            return View(categories);
        }

        public IActionResult Detail(int? id)
        {
            if (id == null)
            {
                //nếu id không tìm thấy thì trả về not found
                return NotFound();
            }
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;

            var category = context.Categories.Include(c => c.Books).FirstOrDefault(c => c.Id == id);
            return View(category);
        }

        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Add(Category category)
        {
            //nếu người dùng nhập đủ và đúng thông tin vào form
            //thì dữ liệu sẽ được add vào database
            if (ModelState.IsValid)
            {
                context.Categories.Add(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = context.Categories.Find(id);
            return View(category);
        }


        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                context.Categories.Update(category);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult Remove(int id)
        {
            //tìm ra object category có id được yêu cầu
            var category = context.Categories.Find(id);

            //xóa object category vừa tìm thấy
            context.Categories.Remove(category);

            //lưu lại thay đổi trong db
            context.SaveChanges();

            //quay trở lại trang index sau khi thành công
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Search(string keyword)
        {
            var cates = context.Categories.Where(b => b.Name.Contains(keyword)).ToList();
            if (cates.Count == 0)
            {
                TempData["Message"] = "No category found";
            }
            return View("Index", cates);
        }
    }
}
