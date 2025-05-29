using Microsoft.EntityFrameworkCore;

namespace BlogSistemi.Models
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Gonderi> Gonderiler { get; set; }
    }
}