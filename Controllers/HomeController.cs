using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project1670.Data;
using Project1670.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Project1670.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            this.context = context;
        }

        public IActionResult Index()
        {
            //lấy ra dữ liệu từ bảng Category và lưu vào list
            var categories = context.Categories.ToList();

            //dữ liệu đẩy vào ViewBag để gọi đến trong View
            ViewBag.Categories = categories;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
