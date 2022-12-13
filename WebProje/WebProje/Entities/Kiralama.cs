using System.ComponentModel.DataAnnotations;

namespace WebProje.Entities
{
    public class Kiralama
    {
        [Key]
        public int? id { get; set; }
        public int? kullaniciId { get; set; }
        public int? aracId { get; set; }
        public string? aracAdi { get; set;}
        public string? aracModeli { get; set;}
    }
  }
