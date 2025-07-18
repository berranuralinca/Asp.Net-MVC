using System.Diagnostics;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductRepository.Models;
using ProductRepository.ViewModels;
using static ProductRepository.ViewModels.ProductListPartialViewModel;

namespace ProductRepository.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ProductDbContext _context;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, ProductDbContext context, IMapper mapper)
        {
            _logger = logger;
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            
            var products = _context.Products.OrderByDescending(x => x.Id).Select(x =>
            new ProductPartialViewModel()
            {
                Name = x.Name,
                Price = x.Price,
                Color = x.Color,
                Size = x.Size
            });
          
            
            ViewBag.productListPartialViewModel = new ProductListPartialViewModel()
            {
                Products = products.ToList()
            };

            return View();
        }

        public IActionResult Privacy()
        {

       
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Visitor()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SaveVisitor(VisitorViewModel visitorViewModel)
        {
            var visitor =_mapper.Map<Visitor>(visitorViewModel);
            visitor.VisitDate = DateTime.Now;
            _context.Visitors.Add(visitor);
            _context.SaveChanges();

            TempData["Message"] = "saved succesfully";
            return RedirectToAction(nameof(HomeController.Visitor));
        }
    }
}
