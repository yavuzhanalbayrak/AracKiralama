using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using System.Data;
using System.Diagnostics;
using WebProje.DBAccess;
using WebProje.Entities;
using WebProje.Models;

namespace WebProje.Controllers
{
    [Authorize(Roles = "uye")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        AppDbContext _context = new AppDbContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        
        public  IActionResult Index()
        { 
            var cookieValue = Request.Cookies["id"];    //Cookie Çağırma (id)
            var kul = _context.kullanici.FirstOrDefault(x=>x.id==int.Parse(cookieValue));
            ViewBag.name = kul.kullaniciAdi;    //Viewbag ile kullanıcı adı view'a gönderildi.

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