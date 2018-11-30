using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueRazorJs.Framework.VueRazorTable
{
    public class ColumnContext
    {
        public HeaderContent HeaderContent { get; set; }
        public RowContent RowContent { get; set; }
        public string For { get; set; }
    }
}
