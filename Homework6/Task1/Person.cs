using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [TrackingEntity]
    public class Person
    {
        [TrackingProperty]
        public string Name { get; set; }
        public string LastNmae { get; set; }
        public int Age { get; set; }

        public Person()
        {
        }
    }
}
