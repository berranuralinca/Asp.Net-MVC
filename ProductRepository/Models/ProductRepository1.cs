/*namespace ProductRepository.Models
{
    //ürünleri yöneten sınıfımız.
    public class ProductRepository1
    {
        // nesneleri tutacak liste
        public static List<Product>? _products = new List<Product>()
        {
            new() { Id = 1, Name = "Pen", Price = 3, Stock = 5 },
            new() { Id = 2, Name = "Book", Price = 5, Stock = 3 },
            new() { Id = 3, Name = "Bag", Price = 10, Stock = 1 }
        };

        // liste dışarıya döner
        public List<Product>? Products() => _products;

        // products a newproduct ı ekler
        public void Add(Product newProduct) => _products.Add(newProduct);

        // id ile eşleşen productsı siler
        public void Remove(int id)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == id); //ilk eşleşen id ile
            if (hasProduct == null)
                throw new Exception($"No product found with id {id} "); 
            _products.Remove(hasProduct);

        }
        public void Update(Product updateProduct)
        {
            var hasProduct = _products.FirstOrDefault(x => x.Id == updateProduct.Id);
            if (hasProduct == null)
            {
                throw new Exception($"No product found with id {updateProduct.Id} ");
             }
            hasProduct.Name = updateProduct.Name;
            hasProduct.Price = updateProduct.Price;
            hasProduct.Stock = updateProduct.Stock;

            var Index = _products.FindIndex(x => x.Id == updateProduct.Id);
            _products[Index] = hasProduct;

        }
    } }
*/