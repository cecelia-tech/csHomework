using System;

namespace Ternary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter first integer: ");
            int countFrom = int.Parse(Console.ReadLine());
            Console.Write("Enter second integer: ");
            int countTo = int.Parse(Console.ReadLine());

            TernaryConvertor ternaryConvertor = new TernaryConvertor();

            ternaryConvertor.CheckForAppropriateInteger(countFrom, countTo);
        }
    }
}
