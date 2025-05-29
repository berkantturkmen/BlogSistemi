BT Blog Yönetim Sistemi

Bu proje, ASP.NET Core MVC ve MySQL kullanılarak geliştirilmiş modern bir blog yönetim panelidir.
Amaç, kullanıcıların blog gönderilerini görsel destekli olarak ekleyebildiği, güncelleyebildiği ve silebildiği profesyonel bir panel sunmaktır.
Sistem, kategori yönetimi, kullanıcı girişi, görsel yükleme ve veri listeleme gibi temel özellikleri içermektedir.

🔐 Kullanıcı Girişi

- Kullanıcılar sisteme kullanıcı adı ve şifre ile giriş yapar.
- Session ile giriş yapan kullanıcı doğrulanır.
- Giriş yapılmadan admin sayfalarına erişim engellenmiştir.

📊 Dashboard Özellikleri

- Gönderi, kategori ve günlük görüntülenme istatistikleri gösterilir.
- En son eklenen gönderiler kart görünümünde listelenir.
- Gönderilere tıklanarak detay sayfasına ulaşılır.

📝 Gönderi İşlemleri

- Başlık, içerik, kategori seçimi ve resim yükleme ile gönderi eklenebilir.
- GönderiDetay sayfasında gönderi tüm verileriyle birlikte görüntülenir.
- Buradan gönderi güncellenebilir veya silinebilir.
- GönderiGuncelle formunda veriler dolu gelir, kategori combobox’ı seçili olur.
- Yeni resim yüklenirse eskisinin üzerine yazılır.

🗑️ Gönderi Silme

- GönderiDetay sayfasında “Sil” butonuna basıldığında gönderi veritabanından silinir.
- Silme işlemi controller üzerinden yapılır.

📂 Kategori Yönetimi

- Kategoriler.cshtml sayfasında kategori listesi tablo olarak görüntülenir.
- Her kategori için Güncelle ve Sil butonları bulunur.
- Yeni kategori sadece Ad alanıyla eklenebilir.
- Kategori güncelleme formunda mevcut veriler dolu şekilde gelir.

🔗 Sosyal Medya ve Tasarım

- Tasarım full responsive ve Bootstrap 5 ile yapılmıştır.
- Footer kısmında geliştiriciye ait sosyal medya bağlantıları yer alır.

🔗 Proje Bağlantıları
GitHub: https://github.com/berkantturkmen

LinkedIn: https://www.linkedin.com/in/berkantturkmen

Instagram: https://www.instagram.com/berkantturkmen37

X (Twitter): https://x.com/berkantturkmenn


