using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace VueRazorJs.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; }

        public List<Person> DataSource { get; set; }

        public void OnGet()
        {
            DataSource = PersonProvider.PersonList.Skip(0 * 10).Take(10).ToList();
        }

        public IActionResult OnGetPage()
        {
            DataSource = PersonProvider.PersonList.Skip(PageNumber * 10).Take(10).ToList();
            
            var partialPageResult = new PartialViewResult()
            {
                ViewName = "Shared/_VueRazorTable",
                ViewData = new ViewDataDictionary<List<Person>>(ViewData, DataSource)
            };

            return partialPageResult;
        }

        public Person Person1 { get; set; } = new Person()
        {
            Name = "Sanyi",
            Age = 10,
            Weight = 40
        };

        public Person Person2 { get; set; } = new Person()
        {
            Name = "Lali",
            Age = 20,
            Weight = 82
        };
    }

    

}
