using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ProductRepository.Models;
using ProductRepository.ViewModels;

namespace ProductRepository.Views.Shared.ViewComponents
{
    public class VisitorViewComponent : ViewComponent
    {
        private readonly ProductDbContext _context;
        private readonly IMapper _mapper;

        public VisitorViewComponent(ProductDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var visitors = _context.Visitors.ToList();
            var visitorViewModels = _mapper.Map<List<VisitorViewModel>>(visitors);
            ViewBag.visitorViewModels = visitorViewModels;
            return View();
        }
    }
}
