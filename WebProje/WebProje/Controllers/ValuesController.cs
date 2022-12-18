using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebProje.DBAccess;
using WebProje.Entities;

namespace WebProje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]   
        public System.Linq.IQueryable Getir(int id , string aracTur)//Filtreleme işlemi yapmaya yarayan api
        {
            AppDbContext _context=new AppDbContext();
            System.Linq.IQueryable arac;
            if (id == 2)
            {
                arac = _context.araclar.Where(x => x.tur == aracTur && x.durum == "listede").OrderByDescending(x => x.id);//İlk Yüklenen
            }
            else if (id == 3)
            {
                arac = _context.araclar.Where(x => x.tur == aracTur && x.durum == "listede").OrderBy(x => x.yil);//Artan 
            }
            else if (id == 4)
            {
                arac = _context.araclar.Where(x => x.tur == aracTur && x.durum == "listede").OrderByDescending(x => x.yil);//Azalan
            }
            else arac = _context.araclar.Where(x => x.tur == aracTur && x.durum == "listede").OrderBy(x => x.id);//Son Yüklenen

            return arac;    //araç filtrelenmiş şekilde döndürülür.
        }
    }
}
