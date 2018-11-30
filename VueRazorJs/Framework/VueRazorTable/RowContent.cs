using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueRazorJs.Framework.VueRazorTable
{
    public class RowContent : IBaseContent
    {
        public IHtmlContent Content { get; set; }
        public string CssClasses { get; set; }
    }
}
