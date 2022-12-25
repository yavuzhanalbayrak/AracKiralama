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


        public IActionResult Index(int id)
        {


            var arac =  _context.araclar.OrderBy(x=>x.tur);
            if (id == 2)
            {    //FİLTRELEME İŞLEMİ
                arac = _context.araclar.Where(x=>x.durum=="listede").OrderBy(x => x.tur);//Listedekiler
            }
            else if (id == 3)
            {
                arac = _context.araclar.Where(x => x.durum == "kiralandi").OrderBy(x => x.tur);//Kiralananlar
            }
            else if (id == 4)
            {
                arac = _context.araclar.Where(x => x.tur == "araba" ).OrderBy(x => x.marka);//Arabalar
            }
             else if (id == 5)
            {
                arac = _context.araclar.Where(x => x.tur == "motor" ).OrderBy(x => x.marka);//Motorlar
            }
             else if (id == 6)
            {
                arac = _context.araclar.Where(x => x.tur == "kamyon" ).OrderBy(x => x.marka);//Kamyonlar
            }
             else if (id == 7)
            {
                arac = _context.araclar.Where(x => x.tur == "tekne" ).OrderBy(x => x.marka);//Tekneler
            }
              else if (id == 8)
            {
                arac = _context.araclar.Where(x => x.tur == "ticari" ).OrderBy(x => x.marka);//Ticariler
            }

            else arac = _context.araclar.OrderBy(x => x.tur);//HEPSİ



            return View(arac);
        } 
        public IActionResult AracEkle()     //Araç ekleme sayfası
        {

            return View();
        }
        public IActionResult AracDuzenle(int? id)   //Var olan aracı update etme
        {
            var arac = _context.araclar.FirstOrDefault(x => x.id == id);

            if (id is null || arac.durum=="kiralandi")  //Araç kiralanmışsa düzeltme yapılamaz
            {
                TempData["msj"] = "Seçilen araç kiralanmış veya mevcut değil.";
                return RedirectToAction("Index");
            }
         
            if (arac is null)//olmayan araç düzeltilemez.
            {
                TempData["msj"] = "Düzenlenecek herhangi bir araç yok.";
                return RedirectToAction("Index");

            }
            return View(arac);
        }
        [HttpPost]
        public IActionResult AracDuzenle(int? id, Arac arac)    //Formdan alınan bilgiler eşliğinde update işlemini gerçekleştirir.
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
        public IActionResult AracEkle(Arac arac)    //Araç eklemeyi gerçekleştiren action.
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

        public IActionResult AracSil(int? id)   //Araç silme işlemleri gerçekleştirildi.
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
