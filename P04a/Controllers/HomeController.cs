using Microsoft.AspNetCore.Mvc;
using P04a.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace P04a.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpContextAccessor contxt;
        public HomeController(IHttpContextAccessor httpContextAccessor)
        {
            contxt = httpContextAccessor;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(IFormCollection fc)
        {
            string res = fc["txtname"];
            return View();

        }

        public IActionResult Index()
        {
            contxt.HttpContext.Session.SetString("StudentName", "Tim");
            contxt.HttpContext.Session.SetInt32("StudentId", 50);

            return View();
        }

        public IActionResult Privacy()
        {
            string StudentName = contxt.HttpContext.Session.GetString("StudentName");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
