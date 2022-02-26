using System;

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
        public int Age;


        public Person(string name, string lastNmae, int age, string address)
        {
            Name = name;
            LastNmae = lastNmae;
            Age = age;
            Address = address;
        }
    }
}
