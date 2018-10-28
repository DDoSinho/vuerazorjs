using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VueRazorJs.Framework.TagHelpers
{
    [HtmlTargetElement("vue-razor-table-paginator", Attributes = "count")]
    public class VueRazorTablePaginatorTagHelper : TagHelper
    {
        [HtmlAttributeName("count")]
        public int Count { get; set; }

        [HtmlAttributeName("pagesize")]
        public int PageSize { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if(this.Count > 0)
            {
                var liBuilder = new StringBuilder();

                int numberOfPages = (Count / PageSize); 

                if(numberOfPages == 1)
                {
                    liBuilder.Append("<li class='page-item'><a class='page-link' href='#'>1</a></li>");
                }
                else
                {
                    liBuilder.Append("<li class='page-item'><a class='page-link' href='#' onClick='previousPage()'>Previous</a></li>");

                    for(int i = 0; i < numberOfPages; i++)
                        liBuilder.Append($"<li class='page-item'><a class='page-link page-index' href='#' onClick='movePage({i})'>{i+1}</a></li>");

                    liBuilder.Append("<li class='page-item'><a class='page-link' href='#' onClick='nextPage()'>Next</a></li>");
                }

                var htmlBuilder = new StringBuilder($"<nav aria-label='Page navigation example'><ul class='pagination'>{liBuilder.ToString()}</ul></nav>");

                output.Content.AppendHtml(htmlBuilder.ToString());
            }
            else
            {
                //error handling
            }
        }
    }
}
