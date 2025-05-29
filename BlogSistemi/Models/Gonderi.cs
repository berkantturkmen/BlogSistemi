namespace BlogSistemi.Models
{
    public class Gonderi
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public string ResimYolu { get; set; }
        public DateTime Tarih { get; set; }

        public int KategoriId { get; set; }
        public Kategori Kategori { get; set; }
    }
}
