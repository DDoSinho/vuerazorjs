using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using VueRazorJs.Framework.Model;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace VueRazorJs.Pages
{
    public class IndexModel : PageModel
    {
        public VueRazorTableModel Model { get; set; } = new VueRazorTableModel()
        {
            ColumnNames = new List<string>()
            {
                "Name",
                "Age",
                "Weight"
            }
        };

        public static List<Person> DataSource { get; set; }

        [BindProperty(SupportsGet = true)]
        public int PageNumber { get; set; }

        public IndexModel()
        {
            DataSource = new List<Person>();

            for (int i = 0; i < 100; i++)
            {
                DataSource.Add(new Person()
                {
                    Name = "Sanyi" + i.ToString(),
                    Age = i + 1,
                    Weight = 80
                });
            }
        }

        public void OnGet()
        {
            Model.DataSource = DataSource.Skip(0 * 10).Take(10).ToList();
        }

        public IActionResult OnGetOne()
        {
            Model.DataSource = DataSource.Skip(PageNumber * 10).Take(10).ToList();

            var partialPageResult = new PartialViewResult()
            {
                ViewName = "Shared/Table",
                ViewData = new ViewDataDictionary<VueRazorTableModel>(ViewData, Model)
            };

            return partialPageResult;
        }

        public Person Person { get; set; } = new Person()
        {
            Name = "Sanyi",
            Age = 10,
            Weight = 40
        };
    }

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
    }

}
