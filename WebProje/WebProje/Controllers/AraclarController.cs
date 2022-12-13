using Microsoft.AspNetCore.Mvc;

namespace WebProje.Controllers
{
    public class AraclarController : Controller
    {
        public IActionResult Araba()
        {
            return View();
        }
        public IActionResult Ticari()
        {
            return View();
        }
        public IActionResult Kamyon()
        {
            return View();
        }
        public IActionResult Motor()
        {
            return View();
        } public IActionResult Tekne()
        {
            return View();
        }
    }
}
