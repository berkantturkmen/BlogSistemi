using Microsoft.AspNetCore.Mvc;
using BlogSistemi.Models;
using Microsoft.EntityFrameworkCore;

public class HomeController : Controller
{
    private readonly DataContext _context;
    public HomeController(DataContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var yazilar = _context.Gonderiler.Include(x => x.Kategori).OrderByDescending(x => x.Tarih).ToList();
        return View(yazilar);
    }
}
