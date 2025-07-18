using Microsoft.AspNetCore.Mvc;
using ProductRepository.Models;
using ProductRepository.ViewModels;

namespace ProductRepository.ViewComponents

{ //dısarıdan almak yerine iceride alır
    public class ProductListViewComponent : ViewComponent
    {
        private readonly ProductDbContext _context;
        public ProductListViewComponent(ProductDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        { 

            var viewmodels = _context.Products.Select(x => new ProductListComponentViewModel()
            {
               Color = x.Color
            }).ToList();

            
              return View("ProductList", viewmodels);
        }
    }
}
