using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using WebProje.Entities;

namespace WebProje.DBAccess
{
    public class AppDbContext:DbContext
    {
       
        public DbSet<Arac> araclar { get; set; }
        public DbSet<Kullanici> kullanici { get; set; }
        public DbSet<Kiralama> kiralama { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=AracKiralamaSon;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
