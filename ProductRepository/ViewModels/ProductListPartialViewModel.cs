namespace ProductRepository.ViewModels
{
    //partial view model olusturduk.
    public class ProductListPartialViewModel
    {


        public List<ProductPartialViewModel> Products { get; set; }
        public class ProductPartialViewModel
        {
            public string Name { get; set; }
            public decimal Price { get; set; }
            public string Color { get; set; }

            public int Size { get; set; }
        }

    }
}
