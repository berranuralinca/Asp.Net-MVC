using System.ComponentModel.DataAnnotations.Schema;

namespace ThirdApp.Models
{
    public class Item   // tablo verileri
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int Price { get; set; }  //add-migration, update-database ile eklenen database de güncellenir.
       
        public int? SerialNumberId { get; set; }

        public SerialNumber? SerialNumber { get; set; }

        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category? Category { get; set; }

        // bir item birden fazla sunucuya sahip olabilir.
        public List<ItemClient>? ItemClients { get; set; }
    }
}
