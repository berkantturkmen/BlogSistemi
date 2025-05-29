using Microsoft.AspNetCore.Mvc;
using BlogSistemi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace BlogSistemi.Controllers
{
    public class AdminController : Controller
    {
        private readonly DataContext _context;
        private readonly IWebHostEnvironment _env;

        // ✅ Tek constructor – ikisini de burada alıyoruz
        public AdminController(DataContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // Login GET
        public IActionResult Login() => View();

        // Login POST
        [HttpPost]
        public IActionResult Login(string kullaniciAdi, string sifre)
        {
            var user = _context.Kullanicilar.FirstOrDefault(x => x.KullaniciAdi == kullaniciAdi && x.Sifre == sifre);
            if (user != null)
            {
                HttpContext.Session.SetString("admin", user.KullaniciAdi);
                return RedirectToAction("Dashboard");
            }
            ViewBag.Hata = "Kullanıcı adı veya şifre hatalı.";
            return View();
        }

        // Dashboard
        public IActionResult Dashboard()
        {
            var gonderiler = _context.Gonderiler.Include(x => x.Kategori).ToList();
            return View(gonderiler);
        }

        // Gönderi Ekle - GET
        [HttpGet]
        public IActionResult GonderiEkle()
        {
            ViewBag.Kategoriler = _context.Kategoriler.ToList();
            return View();
        }

        // Gönderi Ekle - POST
        [HttpPost]
        public IActionResult GonderiEkle(Gonderi gonderi, IFormFile Resim)
        {
            if (Resim != null && Resim.Length > 0)
            {
                var dosyaAdi = Guid.NewGuid().ToString() + Path.GetExtension(Resim.FileName);
                var yol = Path.Combine(_env.WebRootPath, "resimler", dosyaAdi);

                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    Resim.CopyTo(stream);
                }

                gonderi.ResimYolu = "/resimler/" + dosyaAdi;
            }

            gonderi.Tarih = DateTime.Now;
            _context.Gonderiler.Add(gonderi);
            _context.SaveChanges();

            return RedirectToAction("Dashboard");
        }

        // Logout
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("admin");
            return RedirectToAction("Login");
        }

        // ====================================
        // 1. KATEGORİ LİSTESİ
        // ====================================
        public IActionResult Kategoriler()
        {
            var kategoriler = _context.Kategoriler.ToList();
            return View(kategoriler);
        }

        // ====================================
        // 2. KATEGORİ EKLE - GET
        // ====================================
        [HttpGet]
        public IActionResult KategoriEkle()
        {
            return View();
        }

        // ====================================
        // 3. KATEGORİ EKLE - POST
        // ====================================
        [HttpPost]
        public IActionResult KategoriEkle(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _context.Kategoriler.Add(kategori);
                _context.SaveChanges();
                return RedirectToAction("Kategoriler");
            }
            return View(kategori);
        }

        // ====================================
        // 4. KATEGORİ SİL
        // ====================================
        public IActionResult KategoriSil(int id)
        {
            var kategori = _context.Kategoriler.FirstOrDefault(k => k.Id == id);
            if (kategori != null)
            {
                _context.Kategoriler.Remove(kategori);
                _context.SaveChanges();
            }
            return RedirectToAction("Kategoriler");
        }

        
        // ====================================
        // 5. KATEGORİ GÜNCELLE - GET
        // ====================================
        [HttpGet]
        public IActionResult KategoriGuncelle(int id)
        {
            var kategori = _context.Kategoriler.FirstOrDefault(k => k.Id == id);
            if (kategori == null)
            {
                return NotFound();
            }
            return View(kategori);
        }

        // ====================================
        // 6. KATEGORİ GÜNCELLE - POST
        // ====================================
        [HttpPost]
        public IActionResult KategoriGuncellePost(Kategori kategori)
        {
            if (ModelState.IsValid)
            {
                _context.Kategoriler.Update(kategori);
                _context.SaveChanges();
                return RedirectToAction("Kategoriler");
            }
            return View("KategoriGuncelle", kategori); // View ismi burada GET methodunun adıyla aynı
        }
        [HttpGet]
        public IActionResult GonderiDetay(int id)
        {
            var gonderi = _context.Gonderiler
        .Include(g => g.Kategori)
        .FirstOrDefault(g => g.Id == id);

            if (gonderi == null)
            {
                return NotFound();
            }

            return View(gonderi);
        }

        [HttpGet]
        public IActionResult GonderiGuncelle(int id)
        {
            var gonderi = _context.Gonderiler.FirstOrDefault(x => x.Id == id);
            if (gonderi == null) return NotFound();
            ViewBag.Kategoriler = _context.Kategoriler.ToList();
            return View(gonderi);
        }

        [HttpPost]
        public IActionResult GonderiGuncelle(Gonderi gonderi, IFormFile Resim)
        {
            var mevcut = _context.Gonderiler.Find(gonderi.Id);
            if (mevcut == null) return NotFound();

            mevcut.Baslik = gonderi.Baslik;
            mevcut.Icerik = gonderi.Icerik;
            mevcut.KategoriId = gonderi.KategoriId;

            if (Resim != null)
            {
                var dosyaAdi = Guid.NewGuid() + Path.GetExtension(Resim.FileName);
                var yol = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/resimler", dosyaAdi);
                using (var stream = new FileStream(yol, FileMode.Create))
                {
                    Resim.CopyTo(stream);
                }
                mevcut.ResimYolu = "/resimler/" + dosyaAdi;
            }

            _context.Gonderiler.Update(mevcut);
            _context.SaveChanges();
            return RedirectToAction("Dashboard");
        }

        public IActionResult GonderiSil(int id)
        {
            var gonderi = _context.Gonderiler.FirstOrDefault(g => g.Id == id);
            if (gonderi != null)
            {
                _context.Gonderiler.Remove(gonderi);
                _context.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }
    }
}
