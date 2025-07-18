using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ProductRepository.TagHelpers
{
    public class ItalicTagHelper:TagHelper
    {
        // <i>italic</li>
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
             
            output.PreContent.SetHtmlContent("<i>");
            output.PostContent.SetHtmlContent("</li>");
        }
    }
}
