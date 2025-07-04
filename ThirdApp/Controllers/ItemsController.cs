using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ThirdApp.Data;
using ThirdApp.Models;  //tanım

namespace ThirdApp.Controllers
{
    // tablodaki verileri cekip view olusturma
    public class ItemsController : Controller
    {
        private readonly ThirdAppContext _context;


        //constructor
        public ItemsController(ThirdAppContext context) { _context = context; }


        //ındex sayfası
        // tüm verileri liste olarak ceker
        public async Task<IActionResult> Index()  // context i liste halinde
        {
            var item = await _context.Items.Include(s => s.SerialNumber).
                Include(c => c.Category)
                .Include(ic=>ic.ItemClients)
                .ThenInclude(c => c.Client)
                .ToListAsync();
            return View(item);
        }

        //CREATE
        //get:kullanıcıdan veri alır->create sayfası
        public IActionResult Create() // create view icin controller
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }
        //post
        [HttpPost]  // formdan veri alır
        public async Task<IActionResult> Create([Bind("Id,Name,Price,CategoryId")] Item item)
        {
            if (ModelState.IsValid) // gelen veri uygun mu
            {
                _context.Items.Add(item);  //contexte eklesin
                await _context.SaveChangesAsync();  //degisiklikleri kaydetsin
                return RedirectToAction("Index"); // anasayfaya yönlendirir
            }
            return View(item);
        }


        // update
        //get:veriyi bulur
        public async Task<IActionResult> Edit(int id)
        {
            ViewData["Categories"] = new SelectList(_context.Categories, "Id", "Name");
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);

        }
        [HttpPost]
        //post
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Price,CategoryId")] Item item)
        {
            if (ModelState.IsValid) // veri uygun mu
            {
                _context.Items.Update(item);  //güncellesin
                await _context.SaveChangesAsync();  //degisiklikleri kaydetsin
                return RedirectToAction("Index");
            }
            return View(item);
        }

        //delete 
        //get
        public async Task<IActionResult> Delete(int id) //silinecek veriyi bulsun
        {
            var item = await _context.Items.FirstOrDefaultAsync(x => x.Id == id);
            return View(item);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var item = await _context.Items.FindAsync(id);
            if (item != null)
            {
                _context.Items.Remove(item);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }


    }
}
