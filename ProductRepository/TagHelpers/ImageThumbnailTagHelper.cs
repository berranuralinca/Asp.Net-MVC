using Microsoft.AspNetCore.Razor.TagHelpers;
using System.IO;

namespace ProductRepository.TagHelpers
{
    public class ImageThumbnailTagHelper : TagHelper
    {
        public string ImageSrc { get; set; } = string.Empty;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            output.TagMode = TagMode.SelfClosing;

            if (string.IsNullOrWhiteSpace(ImageSrc))
            {
                // Eğer boşsa hiç render etme
                output.SuppressOutput();
                return;
            }

            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(ImageSrc);
            string fileExtension = Path.GetExtension(ImageSrc);
            string thumbnailPath = $"/images/{fileNameWithoutExtension}-100x100{fileExtension}";

            output.Attributes.SetAttribute("src", thumbnailPath);
            output.Attributes.SetAttribute("class", "img-fluid"); // Bootstrap class
            output.Attributes.SetAttribute("alt", fileNameWithoutExtension); // Alternatif metin
        }
    }
}
