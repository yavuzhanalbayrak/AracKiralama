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
        public IActionResult Araba(int id, string aracTur)
        {

            var cookieValue = Request.Cookies["id"];    //Cookie Çağırma (id) KULLANICI ADI TUTMA
            var kul = _context.kullanici.FirstOrDefault(x => x.id == int.Parse(cookieValue));
            ViewBag.name = kul.kullaniciAdi;    
            ValuesController api = new ValuesController();



            return View(api.Getir(id, aracTur));    //Apiden filtrelenmiş araçlar çekildi.
        }
        public IActionResult Ticari(int id, string aracTur)
        {

            var cookieValue = Request.Cookies["id"];    //Cookie Çağırma (id)
            var kul = _context.kullanici.FirstOrDefault(x => x.id == int.Parse(cookieValue));
            ViewBag.name = kul.kullaniciAdi;

            ValuesController api = new ValuesController();



            return View(api.Getir(id, aracTur));    //Apiden filtrelenmiş araçlar çekildi.
        }
        public IActionResult Kamyon(int id, string aracTur)
        {
            var cookieValue = Request.Cookies["id"];    //Cookie Çağırma (id)
            var kul = _context.kullanici.FirstOrDefault(x => x.id == int.Parse(cookieValue));
            ViewBag.name = kul.kullaniciAdi;

            

            ValuesController api = new ValuesController();
            


            return View(api.Getir(id, aracTur));    //Apiden filtrelenmiş araçlar çekildi.
        }
        public IActionResult Motor(int id, string aracTur)
        {
            var cookieValue = Request.Cookies["id"];    //Cookie Çağırma (id)
            var kul = _context.kullanici.FirstOrDefault(x => x.id == int.Parse(cookieValue));
            ViewBag.name = kul.kullaniciAdi;

            ValuesController api = new ValuesController();



            return View(api.Getir(id, aracTur));    //Apiden filtrelenmiş araçlar çekildi.
        } 
        public IActionResult Tekne(int id, string aracTur)
        {
            var cookieValue = Request.Cookies["id"];    //Cookie Çağırma (id)
            var kul = _context.kullanici.FirstOrDefault(x => x.id == int.Parse(cookieValue));
            ViewBag.name = kul.kullaniciAdi;


            ValuesController api = new ValuesController();



            return View(api.Getir(id, aracTur));    //Apiden filtrelenmiş araçlar çekildi.
        }
        
        public IActionResult Detay(int? id, Kiralama kira)
        {

                int kullaniciId = int.Parse(Request.Cookies["id"]);
                var kullanici=_context.kullanici.FirstOrDefault(x => x.id == kullaniciId);  //kullanıcı id'si alındı
                var arac=_context.araclar.FirstOrDefault(x => x.id == id);  //araç id'si alındı
                arac.durum = "kiralandi";
                arac.sahibi = kullanici.kullaniciAdi;
                _context.araclar.Update(arac);  //araç kiralandı olarak değiştirildi
                kira.id = null;
                kira.aracAdi = arac.marka;
                kira.aracModeli = arac.model;
                kira.aracId = id;
                kira.kullaniciId = int.Parse(Request.Cookies["id"]);
                _context.Add(kira); //araç ve kullanıcı id'siyle sipariş oluşturuldu.
                _context.SaveChanges();

            TempData["iade"] = arac.id + " id'li " + arac.marka + " " + arac.model + " Kiralandı.";
            return RedirectToAction("KiralananAraclar");
            

           
        }
        public IActionResult KiralananAraclar()     //Kullanıcıya ait kiralanan araçlar getirildi.
        {
            int kullanici=int.Parse(Request.Cookies["id"]);
            var kul=_context.kullanici.FirstOrDefault(x=>x.id==kullanici);
            var kira = _context.kiralama.Where(x => x.kullaniciId == kullanici);
            return View(kira);
        }
        public IActionResult Iade(int id)   //Araç iade edildi.
        {
            var kira = _context.kiralama.FirstOrDefault(x => x.id == id);
            var arac = _context.araclar.FirstOrDefault(x=>x.id==kira.aracId);

            arac.sahibi = null;
            arac.durum = "listede";
            _context.araclar.Update(arac);  //araç listeye yeniden eklendi.


            _context.kiralama.Remove(kira); //Sipariş silme
            _context.SaveChanges();

            TempData["iade"] = arac.id + " id'li " + arac.marka+" " + arac.model + " iade edildi.";
            return RedirectToAction("KiralananAraclar");
            
        }
    }
}
