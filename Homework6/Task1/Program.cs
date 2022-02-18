using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger test = new Logger("test");

            Person person = new Person("Simon", "Rogers", 47, "address");

            test.Tracker(person);
        }
    }
}
