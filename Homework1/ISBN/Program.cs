using System;

namespace ISBN
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter 9 integer digits: ");
            string numbersArray = Console.ReadLine();

            Isbn isbn = new Isbn();
            Console.WriteLine(isbn.GetIsbnNumericCode(numbersArray));
        }
    }
}
