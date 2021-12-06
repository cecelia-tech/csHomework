using System;

namespace SumOfArray
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter at least two integer digits separated by comma: ");
            string userInputNumbers = Console.ReadLine();

            SumBetweenNumbers sumOfArray = new SumBetweenNumbers();
            Console.WriteLine(userInputNumbers);
            Console.WriteLine(sumOfArray.PrintSumOfRequaredNumbers(userInputNumbers));
        }
    }
}
