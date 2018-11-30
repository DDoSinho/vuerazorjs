using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueRazorJs.Framework.VueRazorTable
{
    public class Table
    {
        public IList DataSource { get; set; }
        public IList<ColumnContext> Columns { get; set; }
        public VueRazorPaginator Paginator { get; set; }
    }
}
