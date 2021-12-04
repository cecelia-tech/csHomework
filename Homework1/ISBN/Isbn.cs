using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISBN
{
    class Isbn
    {
        //This method takes a string and conversts to int array
        public string StringToIntArrayConvertor(string numbersInString)
        {
            int[] arrayOfNum = new int[numbersInString.Length];

            for (int i = 0; i < arrayOfNum.Length; i++)
            {
                arrayOfNum[i] = (int)Char.GetNumericValue(numbersInString[i]);
            }

            return MultiplicationOfNumbers(arrayOfNum);
        }

        //Multiplies and sums up the array of integers accordingly to ISBN counting standart
        public string MultiplicationOfNumbers(int[] arrayOfNumbers)
        {
            int sumOfMultipliedNumbers = 0;

            for (int i = 0, count = 10; i < arrayOfNumbers.Length; i++, count--)
            {
                sumOfMultipliedNumbers += arrayOfNumbers[i] * count;

            }

            return CheckDigit(sumOfMultipliedNumbers);

        }

        //Calculates check digit
        public string CheckDigit(int sumOfMultipliedNumbers)
        {
            int remainder = sumOfMultipliedNumbers % 11;

            if (remainder == 10)
            {
                return "X";
            }
            else
            {
                int digit = 11 - remainder;

                return digit.ToString();
            }
        }

        //Method combines ISBN code
        public void IsbnNumericCode(string userInput)
        {
            string finalIsbn = "ISBN ";

            for (int i = 0; i < userInput.Length; i++)
            {
                if (i == 0 || i == 6 || i == 8)
                {
                    finalIsbn += userInput[i] + "-";
                }
                else
                {
                    finalIsbn += userInput[i];
                }
            }
            string checkDigit = StringToIntArrayConvertor(userInput);

            Print(finalIsbn += checkDigit);
        }

        public void Print(string isbnCode)
        {
            Console.WriteLine(isbnCode);
        }
    }
}
