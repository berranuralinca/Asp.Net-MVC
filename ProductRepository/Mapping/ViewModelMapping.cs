using AutoMapper;
using ProductRepository.Models;
using ProductRepository.ViewModels;

namespace ProductRepository.Mapping
{
    public class ViewModelMapping:Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Product,ProductViewModel>().ReverseMap();
            CreateMap<Visitor, VisitorViewModel>().ReverseMap();

        }
    }
}
