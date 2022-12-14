using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebProje.DBAccess;
using WebProje.Entities;

namespace WebProje.Controllers
{
    [Authorize(Roles = "uye")]
    public class AraclarController : Controller
    {
        AppDbContext _context=new AppDbContext();
        public IActionResult Araba(int id)
        {

            var cookieValue = Request.Cookies["id"];    //Cookie Çağırma (id) KULLANICI ADI TUTMA
            var kul = _context.kullanici.FirstOrDefault(x => x.id == int.Parse(cookieValue));
            ViewBag.name = kul.kullaniciAdi;

            var arac = _context.araclar.Where(x => x.tur == "araba" && x.durum == "listede");
            if (id==2) {    //FİLTRELEME İŞLEMİ
                arac = _context.araclar.Where(x => x.tur == "araba" && x.durum == "listede").OrderByDescending(x => x.id);//İlk Yüklenen
            }
            else if (id==3)
            {
                arac = _context.araclar.Where(x => x.tur == "araba" && x.durum == "listede").OrderBy(x => x.yil);//Artan 
            }
            else if (id==4)
            {
                arac = _context.araclar.Where(x => x.tur == "araba" && x.durum == "listede").OrderByDescending(x => x.yil);//Azalan
            }
            else arac = _context.araclar.Where(x => x.tur == "araba" && x.durum == "listede").OrderBy(x => x.id);//Son Yüklenen


          
           
            return View(arac);
        }
        public IActionResult Ticari(int id)
        {

            var cookieValue = Request.Cookies["id"];    //Cookie Çağırma (id)
            var kul = _context.kullanici.FirstOrDefault(x => x.id == int.Parse(cookieValue));
            ViewBag.name = kul.kullaniciAdi;

            var arac = _context.araclar.Where(x => x.tur == "ticari" && x.durum == "listede");
            if (id == 2)
            {
                arac = _context.araclar.Where(x => x.tur == "ticari" && x.durum == "listede").OrderByDescending(x => x.id);//İlk Yüklenen
            }
            else if (id == 3)
            {
                arac = _context.araclar.Where(x => x.tur == "ticari" && x.durum == "listede").OrderBy(x => x.yil);//Artan 
            }
            else if (id == 4)
            {
                arac = _context.araclar.Where(x => x.tur == "ticari" && x.durum == "listede").OrderByDescending(x => x.yil);//Azalan
            }
            else arac = _context.araclar.Where(x => x.tur == "ticari" && x.durum == "listede").OrderBy(x => x.id);//Son Yüklenen
            
            return View(arac);
        }
        public IActionResult Kamyon(int id)
        {
            var cookieValue = Request.Cookies["id"];    //Cookie Çağırma (id)
            var kul = _context.kullanici.FirstOrDefault(x => x.id == int.Parse(cookieValue));
            ViewBag.name = kul.kullaniciAdi;

            var arac = _context.araclar.Where(x => x.tur == "kamyon" && x.durum == "listede");
            if (id == 2)
            {
                arac = _context.araclar.Where(x => x.tur == "kamyon" && x.durum == "listede").OrderByDescending(x => x.id);//İlk Yüklenen
            }
            else if (id == 3)
            {
                arac = _context.araclar.Where(x => x.tur == "kamyon" && x.durum == "listede").OrderBy(x => x.yil);//Artan 
            }
            else if (id == 4)
            {
                arac = _context.araclar.Where(x => x.tur == "kamyon" && x.durum == "listede").OrderByDescending(x => x.yil);//Azalan
            }
            else arac = _context.araclar.Where(x => x.tur == "kamyon" && x.durum == "listede").OrderBy(x => x.id);//Son Yüklenen

            return View(arac);
        }
        public IActionResult Motor(int id)
        {
            var cookieValue = Request.Cookies["id"];    //Cookie Çağırma (id)
            var kul = _context.kullanici.FirstOrDefault(x => x.id == int.Parse(cookieValue));
            ViewBag.name = kul.kullaniciAdi;

            var arac = _context.araclar.Where(x => x.tur == "motor" && x.durum == "listede");
            if (id == 2)
            {
                arac = _context.araclar.Where(x => x.tur == "motor" && x.durum == "listede").OrderByDescending(x => x.id);//İlk Yüklenen
            }
            else if (id == 3)
            {
                arac = _context.araclar.Where(x => x.tur == "motor" && x.durum == "listede").OrderBy(x => x.yil);//Artan 
            }
            else if (id == 4)
            {
                arac = _context.araclar.Where(x => x.tur == "motor" && x.durum == "listede").OrderByDescending(x => x.yil);//Azalan
            }
            else arac = _context.araclar.Where(x => x.tur == "motor" && x.durum == "listede").OrderBy(x => x.id);//Son Yüklenen
            return View(arac);
        } 
        public IActionResult Tekne(int id)
        {
            var cookieValue = Request.Cookies["id"];    //Cookie Çağırma (id)
            var kul = _context.kullanici.FirstOrDefault(x => x.id == int.Parse(cookieValue));
            ViewBag.name = kul.kullaniciAdi;

            var arac = _context.araclar.Where(x => x.tur == "tekne" && x.durum == "listede");
            if (id == 2)
            {
                arac = _context.araclar.Where(x => x.tur == "tekne" && x.durum == "listede").OrderByDescending(x => x.id);//İlk Yüklenen
            }
            else if (id == 3)
            {
                arac = _context.araclar.Where(x => x.tur == "tekne" && x.durum == "listede").OrderBy(x => x.yil);//Artan 
            }
            else if (id == 4)
            {
                arac = _context.araclar.Where(x => x.tur == "tekne" && x.durum == "listede").OrderByDescending(x => x.yil);//Azalan
            }
            else arac = _context.araclar.Where(x => x.tur == "tekne" && x.durum == "listede").OrderBy(x => x.id);//Son Yüklenen
            return View(arac);
        }
        
        public IActionResult Detay(int? id, Kiralama kira)
        {

                int kullaniciId = int.Parse(Request.Cookies["id"]);
                var kullanici=_context.kullanici.FirstOrDefault(x => x.id == kullaniciId); 
                var arac=_context.araclar.FirstOrDefault(x => x.id == id);
                arac.durum = "kiralandi";
                arac.sahibi = kullanici.kullaniciAdi;
                _context.araclar.Update(arac);
                kira.id = null;
                kira.aracAdi = arac.marka;
                kira.aracModeli = arac.model;
                kira.aracId = id;
                kira.kullaniciId = int.Parse(Request.Cookies["id"]);
                _context.Add(kira);
                _context.SaveChanges();

            TempData["iade"] = arac.id + " id'li " + arac.marka + " " + arac.model + " Kiralandı.";
            return RedirectToAction("KiralananAraclar");
            

           
        }
        public IActionResult KiralananAraclar()
        {
            int kullanici=int.Parse(Request.Cookies["id"]);
            var kul=_context.kullanici.FirstOrDefault(x=>x.id==kullanici);
            ViewBag.kul = kul.kullaniciAdi;
            var kira = _context.kiralama.Where(x => x.kullaniciId == kullanici);
            return View(kira);
        }
        public IActionResult Iade(int id)
        {
            var kira = _context.kiralama.FirstOrDefault(x => x.id == id);
            var arac = _context.araclar.FirstOrDefault(x=>x.id==kira.aracId);

            arac.sahibi = null;
            arac.durum = "listede";
            _context.araclar.Update(arac);


            _context.kiralama.Remove(kira);
            _context.SaveChanges();

            TempData["iade"] = arac.id + " id'li " + arac.marka+" " + arac.model + " iade edildi.";
            return RedirectToAction("KiralananAraclar");
            
        }
    }
}
