using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace ProductRepository.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [StringLength(25,MinimumLength =1,   ErrorMessage = "Maximum 25 characters can be entered")]
        [Required (ErrorMessage ="Please enter name")]
        [Remote(action:"HasProductName",controller:"Products")]
        public string? Name { get; set; }

        // required yapıcaksan nullable yap yoksa hata verir.

        [RegularExpression(@"^(?:0\.(?:0[1-9]|[1-9][0-9]?)|[1-9]\d{0,4}(?:\.\d{1,2})?)$", ErrorMessage = "Enter a valid price")]
        [Required(ErrorMessage = "Please enter price")]
        public decimal? Price { get; set; }


        [Required(ErrorMessage = "Please enter stock")]
        [Range(1, 100, ErrorMessage = "Must be between 1-100")]
        public int? Stock { get; set; }

        // ilk tablodan farklı değişiklik olucaksa yeniden migration oluştur.
        [Required(ErrorMessage = "Please enter color")]
        public string? Color { get; set; }

        //datetime
        [Required(ErrorMessage = "Please enter datetime")]
        public DateTime? ProductDate { get; set; }

        // radio
        [Required(ErrorMessage = "Please enter size")]
        public int? Size { get; set; }

        
    }
}
