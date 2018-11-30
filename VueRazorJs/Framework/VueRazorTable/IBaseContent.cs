using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueRazorJs.Framework.VueRazorTable
{
    public interface IBaseContent
    {
        IHtmlContent Content { get; set; }
        string CssClasses { get; set; }
    }
}
