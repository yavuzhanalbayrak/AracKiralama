using System.ComponentModel.DataAnnotations;

namespace WebProje.Entities
{
    public class Kullanici
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "Kullanıcı Adı Zorunludur")]
        [Display(Name = "Kullanıcı Adı: ")]
        [StringLength (50,MinimumLength =3,ErrorMessage ="Lütfen Kullanıcı Adı 3 ile 50 Karakter uzunluğunda olsun!")]
        public string? kullaniciAdi { get; set; }

        [Required(ErrorMessage = "Şifre Zorunludur")]
        [Display(Name = "Şifre: ")]
        [StringLength(15, MinimumLength = 3, ErrorMessage = "Lütfen Şifre 3 ile 15 Karakter uzunluğunda olsun!")]
        public string? sifre { get; set; }
        public string? rol { get; set; }
    }
}
