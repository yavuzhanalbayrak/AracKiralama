using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebProje.DBAccess;
using WebProje.Entities;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace WebProje.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        AppDbContext _context = new AppDbContext();


        public IActionResult Index()
        {

            var araclar =  _context.araclar;

            return View(araclar);
        } 
        public IActionResult AracEkle()
        {

            return View();
        }
        public IActionResult AracDuzenle(int? id)
        {
            var arac = _context.araclar.FirstOrDefault(x => x.id == id);

            if (id is null || arac.durum=="kiralandi")
            {
                TempData["msj"] = "Seçilen araç kiralanmış veya mevcut değil.";
                return RedirectToAction("Index");
            }
         
            if (arac is null)
            {
                TempData["msj"] = "Düzenlenecek herhangi bir araç yok.";
                return RedirectToAction("Index");

            }
            return View(arac);
        }
        [HttpPost]
        public IActionResult AracDuzenle(int? id, Arac arac)
        {
            if (id != arac.id)
            {
                TempData["hata"] = "Güncelleme Yapılmaz.";
                return RedirectToAction("AracDuzenle");
            }
            if (ModelState.IsValid)
            {

                arac.durum = "listede";
                _context.araclar.Update(arac);
               
                _context.SaveChanges();
                TempData["msj"] = arac.marka + " " + arac.model + " aracı düzenlendi.";
                return RedirectToAction("Index");
            }
            TempData["hata"] = "Lütfen verileri eksiksiz girin.";
            return RedirectToAction("AracDuzenle");
        }
        [HttpPost]
        public IActionResult AracEkle(Arac arac)
        {
            if (ModelState.IsValid)
            {
                arac.durum = "listede";
                _context.Add(arac);
                _context.SaveChanges();
                TempData["msj"] = arac.marka+" "+arac.model + " aracı eklendi.";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["hata"] = "Lütfen Gerekli alanları doldurunuz.";
                return RedirectToAction("AracEkle");
            }

        }

        public IActionResult AracSil(int? id)
        {
            if (id is null)
            {
                TempData["msj"] = "Silme kısmı çalışamaz.";
                return RedirectToAction("Index");
            }
            var y = _context.araclar.FirstOrDefault(x => x.id == id);
            if (y is null)
            {
                TempData["msj"] = "Silinecek herhangi bir araç yok.";
                return RedirectToAction("Index");
            }
            if (y.durum == "kiralandi")
            {
                TempData["msj"] = "Araç Kiralık olduğundan silme işlemi yapılamaz.";
                return RedirectToAction("Index");
            }
            _context.araclar.Remove(y);
            _context.SaveChanges();
            TempData["msj"] = y.durum+" "+y.marka + " aracı silindi.";
            return RedirectToAction("Index");


        }
    }
}
