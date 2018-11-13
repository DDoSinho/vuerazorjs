using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueRazorJs.Framework.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class VueRazorTableDisplayName : Attribute
    {
        private string name;

        public string Name { get { return name; } }

        public VueRazorTableDisplayName(string name)
        {
            this.name = name;
        }
    }
}
