using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProductRepository.Models;
using ProductRepository.ViewModels;

namespace ProductRepository.Controllers
{
    public class ProductsController : Controller
    {
        //nesne olusturduk
        private readonly ProductDbContext _context;

        //automap
        private readonly IMapper _mapper;

       // private readonly ProductRepository1 _productRepository;
        public ProductsController(ProductDbContext context,IMapper mapper)
        {
            // _productRepository = new ProductRepository1();

            _context = context;
            _mapper = mapper;

            //_context boşsa ekler
            if (!_context.Products.Any())
            { 

                _context.Products.Add(new Product() { Name="Phone",Price=3000,Stock=3,Color="Blue",Size = 4});
                _context.Products.Add(new Product() { Name = "Laptop", Price =10000, Stock = 5 ,Color="Red",Size = 17});
                _context.Products.Add(new Product() { Name = "Tablet", Price = 2500, Stock = 1,Color="Black",Size = 9 });

                _context.SaveChanges();
            }
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View("Index",_mapper.Map<List<ProductViewModel>>(products));
        }

        // routing ornegi
        public IActionResult GetById(int id)
        {
            var product = _context.Products.Find(id);
            
            return View(_mapper.Map<ProductViewModel>(product));
        }
        public IActionResult Remove(int id)
        {
            var product = _context.Products.Find(id);

            if (product == null)
            {
                TempData["message"] = "Product not found.";
                return RedirectToAction("Index");
            }

            _context.Products.Remove(product);
            _context.SaveChanges();

            TempData["message"] = "Product deleted.";
            return RedirectToAction("Index");
        }



        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Size = new Dictionary<string, int>() { { "1'", 1 }, { "4'", 4 }, { "9'", 9 }, { "17'", 17 } };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new() {Data ="Black",Value="Black"},
                new() {Data ="Blue",Value="Blue"},
                new() {Data ="Grey",Value="Grey"},
                new() {Data ="White",Value="White"}

            }, "Value", "Data");


            return View();
        }

        [HttpPost]
        // 2.yöntemde parametre olarak verilir.(string Name,decimal Price,int Stock,string Color)
        // SaveProduct() -> Add() parametre aldıgı için yapılabilir.
        public IActionResult Add(ProductViewModel newProduct)
        {
            //1.yöntem
            //bilgileri alma
            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price = decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());
            //var color = HttpContext.Request.Form["Color"].ToString();

            //nesne oluşturma
            //2.yöntem için
            // Product newProduct = new Product() {Name=Name,Price=Price,Stock=Stock,Color=Color };

            if (ModelState.IsValid)
            {
                _context.Products.Add(_mapper.Map<Product>(newProduct));
                _context.SaveChanges();

                TempData["message"] = "Product added.";
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Size = new Dictionary<string, int>() { { "1'", 1 }, { "4'", 4 }, { "9'", 9 }, { "17'", 17 } };

                ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
                {
                new() {Data ="Black",Value="Black"},
                new() {Data ="Blue",Value="Blue"},
                new() {Data ="Grey",Value="Grey"},
                new() {Data ="White",Value="White"}

                }, "Value", "Data");
                return View();
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);

            ViewBag.Size = new Dictionary<string, int>() { { "1'", 1 }, { "4'", 4 }, { "9'", 9 }, { "17'", 17 } };



            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
            {
                new() {Data ="Black",Value="Black"},
                new() {Data ="Blue",Value="Blue"},
                new() {Data ="Grey",Value="Grey"},
                new() {Data ="White",Value="White"}

            },"Value","Data");


            return View(_mapper.Map<ProductViewModel>(product));
        }

        [HttpPost]
        public IActionResult Update(ProductViewModel updateProduct)
        {

            if (ModelState.IsValid)
            {
                _context.Products.Update(_mapper.Map<Product>(updateProduct));
                _context.SaveChanges();

                TempData["message"] = "Product updated.";
                return RedirectToAction("Index");
            }

            ViewBag.Size = new Dictionary<string, int>() { { "1'", 1 }, { "4'", 4 }, { "9'", 9 }, { "17'", 17 } };

            ViewBag.ColorSelect = new SelectList(new List<ColorSelectList>()
                {
                new() {Data ="Black",Value="Black"},
                new() {Data ="Blue",Value="Blue"},
                new() {Data ="Grey",Value="Grey"},
                new() {Data ="White",Value="White"}

                }, "Value", "Data");
            return View();
        }

        // daha önce var mıydı

        [AcceptVerbs("GET", "POST")]
        public IActionResult HasProductName(string Name)
        {
            // eger bossa
            if (string.IsNullOrWhiteSpace(Name))
            {
                return Json("Product name cannot be empty");
            }
            
            var anyProduct = _context.Products.Any(x => x.Name.ToLower() == Name.ToLower());
            // ürün zaten varsa
            if (anyProduct)
            {
                return Json("This product already exists");
            }

            return Json(true);
        }


    }
}
