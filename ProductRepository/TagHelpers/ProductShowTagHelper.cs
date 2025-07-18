using Microsoft.AspNetCore.Razor.TagHelpers;
using ProductRepository.Models;

namespace ProductRepository.TagHelpers
{
    public class ProductShowTagHelper : TagHelper
    {
        public Product? Product { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.SetAttribute("class", "list-group list-group-flush");

            if (Product != null)
            {
                output.Content.SetHtmlContent($@"
                    <ul>
                        <li class='list-group-item'>Name: {Product.Name}</li>
                        <li class='list-group-item'>Price: {Product.Price:C}</li>
                        <li class='list-group-item'>Stock: {Product.Stock}</li>
                    </ul>
                ");
            }
            else
            {
                output.Content.SetHtmlContent("<p>Product not found.</p>");
            }
        }
    }
}
