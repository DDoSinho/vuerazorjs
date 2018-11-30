using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueRazorJs.Framework.VueRazorTable
{
    public class VueRazorPaginator
    {
        public HtmlString PaginatorHtmlString { get; set; }
        public int Count { get; set; }
        public int PageSize { get; set; }
        public string Url { get; set; }
        public Position PaginatorPosition { get; set; }
    }
}
