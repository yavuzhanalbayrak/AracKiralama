using System.ComponentModel.DataAnnotations;

namespace WebProje.Entities
{
    public class Arac
    {
        [Key]
        public int id { get; set; }
        public string? marka { get; set; }
        public string? model { get; set; }
        public string yil { get; set; }
        public string? renk { get; set;}
        public string? aracResmi { get; set; }
        public string? tur { get; set; }
        public string? durum { get; set; }
        public string? sahibi { get; set; }
    }
    
}
