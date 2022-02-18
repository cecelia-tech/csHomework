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
        public string Address { get; set; }
        [TrackingProperty]
        public string Name { get; set; }
        [TrackingProperty(PropertyName = "Last name")]
        public string LastNmae { get; set; }
        [TrackingProperty(PropertyName = "Age")]
        public int age;


        public Person()
        {
        }

        public Person(string name, string lastNmae, int age, string address)
        {
            Name = name;
            LastNmae = lastNmae;
            this.age = age;
            Address = address;
        }
    }
}
