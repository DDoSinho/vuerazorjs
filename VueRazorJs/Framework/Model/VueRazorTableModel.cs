using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueRazorJs.Framework.Model
{
    public class VueRazorTableModel
    {
        public IList DataSource { get; set; }
        public IList<string> ColumnNames { get; set; }
    }
}
