📘 BT Blog Yönetim Paneli
BT Blog Yönetim Paneli, ASP.NET Core ve MySQL kullanılarak geliştirilmiş profesyonel bir blog yönetim sistemidir. Bu sistem, blog gönderilerini, kategorileri ve kullanıcı oturumlarını yönetmek için modern, responsive ve şık bir admin paneli sunar. Proje hem teknik olarak sağlam hem de görsel açıdan zengindir.

🛠️ Kullanılan Teknolojiler
Katman	Teknoloji / Araçlar
Backend	ASP.NET Core MVC (.NET 7+)
Veritabanı	MySQL
ORM	Entity Framework Core
Frontend	HTML5, CSS3, Bootstrap 5, Razor
UI Kit	Font Awesome
Session Yönetimi	ASP.NET Core HttpContext.Session
Ortam	Visual Studio 2022

📂 Proje Klasör Yapısı
BlogSistemi/
│
├── Controllers/
│   └── AdminController.cs
│
├── Models/
│   ├── Gonderi.cs
│   ├── Kategori.cs
│   ├── Kullanici.cs
│   └── DataContext.cs
│
├── Views/
│   └── Admin/
│       ├── Dashboard.cshtml
│       ├── GonderiEkle.cshtml
│       ├── GonderiDetay.cshtml
│       ├── GonderiGuncelle.cshtml
│       ├── KategoriEkle.cshtml
│       ├── KategoriGuncelle.cshtml
│       ├── Kategoriler.cshtml
│       ├── Login.cshtml
│
├── wwwroot/
│   └── resimler/
│       └── <gönderi resimleri>
│
├── appsettings.json
└── Program.cs
🔐 Kullanıcı Giriş Sistemi
Login.cshtml: Admin kullanıcı adı ve şifresi girilerek oturum başlatılır.

Session ile oturum kontrolü yapılır.

Başarılı girişte Dashboard’a yönlendirme yapılır.

Oturum açık değilse hiçbir admin sayfasına erişim sağlanamaz.

🧾 Özellikler
✅ 1. Dashboard
Gönderi, kategori ve günlük görüntülenme sayıları.

En son eklenen gönderiler kart biçiminde listelenir.

Her gönderiye tıklanarak GonderiDetay sayfasına ulaşılır.

✅ 2. Gönderi Ekle
Başlık, içerik, kategori seçimi ve resim yükleme.

Dosya sunucuya kaydedilir, ResimYolu alanına yazılır.

Kategori verileri ViewBag ile combobox’a gelir.

✅ 3. Gönderi Detay
Gönderi tüm verileriyle birlikte (resim, içerik, kategori) gösterilir.

Güncelle ve Sil butonları vardır.

✅ 4. Gönderi Güncelle
Formda mevcut veriler doldurulmuş halde gelir.

Kategori combobox’unda seçili kategori belirlenir.

Yeni resim yüklenirse eskisi güncellenir.

✅ 5. Gönderi Sil
Gönderi veritabanından silinir.

Silme işlemi AdminController içinde yapılır.

📂 Kategori Yönetimi
✅ Kategoriler.cshtml
Kategori listesi tablo halinde görüntülenir.

Güncelle ve Sil işlemleri yapılabilir.

✅ Kategori Ekle
Sadece Ad girilerek yeni kategori eklenir.

✅ Kategori Güncelle
Mevcut kategori adı formda gelir.

Güncelleme sonrası listeye geri yönlendirme yapılır.

🧠 Veri Modeli (Entities)
Gonderi.cs
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
Kategori.cs
public class Kategori
{
    public int Id { get; set; }
    public string Ad { get; set; }
    public ICollection<Gonderi> Gonderiler { get; set; }
}
Kullanici.cs
public class Kullanici
{
    public int Id { get; set; }
    public string KullaniciAdi { get; set; }
    public string Sifre { get; set; }
}
⚙️ Veritabanı Konfigürasyonu
appsettings.json
json

"ConnectionStrings": {
  "DefaultConnection": "server=localhost;database=blogdb;user=root;password=porola12;"
}
Program.cs
builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
    new MySqlServerVersion(new Version(8, 0, 25))));
🧪 Test İçeriği
Admin girişi: admin / admin123

Gönderi test: "ASP.NET ile Modern Web Geliştirme"

Resim: ASP.NET logosu (kaydedilmiş olarak /wwwroot/resimler/ klasörüne yüklenir)

🖼️ Ekran Görüntüleri

✅ Eklenecek

🧼 Bonus: Tasarımsal Detaylar
Tüm sayfalarda:

Navbar üstte ve responsive.

Footer, scroll sona gelince görünür şekilde yerleştirildi.

Gönderi kartları hover animasyonlu.

Formlar modern Bootstrap stiliyle uyumlu hale getirildi.

BT logosu dairesel yapıya sahip.

📌 Nasıl Başlatılır?
Veritabanını oluştur:
CREATE DATABASE blogdb;
Connection string'i appsettings.json içinde güncelle.

Projeyi çalıştır (Visual Studio veya CLI):
dotnet run
Tarayıcıdan aç:
https://localhost:portnumarası/Admin/Login


📣 Geliştirici
👨‍💻 Proje Sahibi: Berkant Türkmen
🔗 Instagram: @berkantturkmen37
🔗 X (Twitter): @berkantturkmenn
🔗 LinkedIn: linkedin.com/in/berkantturkmen
🔗 GitHub: github.com/berkantturkmen

📄 Lisans
Bu proje MIT lisansı ile lisanslanmıştır. Özgürce kullanabilir ve geliştirebilirsiniz.

