using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
                    Name = Guid.NewGuid().ToString(),
                    Age = i + 1,
                    Weight = 80
                });
            }
        }
    }

    public class Person
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public int Weight { get; set; }
    }
}
