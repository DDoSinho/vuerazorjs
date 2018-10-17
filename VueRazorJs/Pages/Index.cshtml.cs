using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace VueRazorJs.Pages
{
    public class IndexModel : PageModel
    {
        public TempClass TempClass { get; set; } = new TempClass()
        {
            Cica = "asd",
            Kutya = "lel"
        };

        public void OnGet()
        {

        }
    }
}
