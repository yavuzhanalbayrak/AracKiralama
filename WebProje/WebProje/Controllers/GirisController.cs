using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebProje.DBAccess;
using WebProje.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebProje.Controllers
{
    public class GirisController : Controller
    {
        AppDbContext _context = new AppDbContext();

        List<Claim> claims = new List<Claim>
                {

                    new Claim(ClaimTypes.Name, " "),
                    new Claim(ClaimTypes.Role," ")


                };



        public IActionResult KullaniciGiris()
        {
            return View();
        }
        public IActionResult Kaydol()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> KayitIslemiAsync(Kullanici kayit)
        {
            if (ModelState.IsValid)
            {
                var userinfo = await _context.kullanici.FirstOrDefaultAsync(x => x.kullaniciAdi == kayit.kullaniciAdi);     //Kullanıcı var mı kontrol!
                if (userinfo == null)
                {
   
                    kayit.rol = "uye";
                    _context.kullanici.Add(kayit);
                    _context.SaveChanges();
                    TempData["hata"] = "Kayıt başarılı";
                    return RedirectToAction("Kaydol");
                }
                else
                {
                    TempData["hata"] = "Bu kullanıcı adı kullanılmış";
                    return RedirectToAction("Kaydol");
                }
            }
            else {
                TempData["hata"] = "Lütfen Gerekli alanları doldurunuz";
                return RedirectToAction("Kaydol");
            }
          

        }

        [HttpPost]
        public async Task<IActionResult> KullaniciGirisKontrol(Kullanici kullanici)
        {

           
            var userinfo = await _context.kullanici.FirstOrDefaultAsync(x => x.kullaniciAdi == kullanici.kullaniciAdi && x.sifre == kullanici.sifre);





            if (userinfo != null)
            {
                claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userinfo.kullaniciAdi),
                    new Claim(ClaimTypes.Role,userinfo.rol)


                };




                var claimsIdentify = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties();

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentify),
                    authProperties);

                if (userinfo.rol == "admin")
                {
                    return RedirectToAction("Index", "Admin");

                }
                else
                {

                    int id = userinfo.id;

                    Response.Cookies.Append("id", id.ToString());   //Cookie Oluşturma. (id)


                    return RedirectToAction("Index", "Home");
                }

            }
            else
            {
                TempData["Girishata"] = "Kullanıcı Adı veya Şifre hatalı";
                return RedirectToAction("KullaniciGiris", "Giris");
            }
          


        }

        public async Task<IActionResult> Cikis()
        {







            Response.Cookies.Delete("id");   //Cookie Silme. (id)

            claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, " "),
                    new Claim(ClaimTypes.Role," ")


                };


            var claimsIdentify = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties();

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentify),
                authProperties);



            return RedirectToAction("Index", "Home");
        }
    }
}




