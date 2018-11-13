using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VueRazorJs.Framework.Attributes;

namespace VueRazorJs
{
    public class PersonProvider
    {
        public static List<Person> PersonList { get; set; }

        static PersonProvider()
        {
            PersonList = new List<Person>(100);

            for (int i = 0; i < 100; i++)
            {
                PersonList.Add(new Person()
                {
                    Name = "Sanyi" + i.ToString(),
                    Age = i + 1,
                    Weight = 80
                });
            }
        }
    }

    [VueRazorTableModel]
    public class Person
    {
        [VueRazorTableDisplayName("Nameee")]
        public string Name { get; set; }

        public int Age { get; set; }

        [VueRazorTableDisplayName("Weight")]
        public int Weight { get; set; }
    }
}
