using Microsoft.EntityFrameworkCore;

namespace ProductRepository.Models
{
    public class ProductDbContext:DbContext
    {
        public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) 
        {
        
        
        
        }
        //code first -> products isimli tablo oluşturur -> migration
        public DbSet<Product> Products { get; set; }

        public DbSet<Visitor> Visitors { get; set; }



    }
}
