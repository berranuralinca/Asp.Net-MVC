namespace ProductRepository.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public decimal Price { get; set; }

        public int Stock { get; set; }

        // ilk tablodan farklı değişiklik olucaksa yeniden migration oluştur.

        public string? Color { get; set; }

        //datetime
        public DateTime? ProductDate { get; set; }

        // radio
        public int Size { get; set; }

        
    }
}
