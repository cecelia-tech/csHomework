using System;
using System.Text;

namespace Ternary
{
    internal class TernaryConvertor
    {
        //Method prints numbers satisfying the task in the range given
        public void PrintNumberWith2Twos(int numberFrom, int numberTo)
        {
            for (int i = numberFrom; i <= numberTo; i++)
            {
                if (!CheckForZeroAndNegatives(i) && CheckForTwos(ConvertToTernary(i)))
                {
                    Console.WriteLine(i);
                }
            }
        }

        //Checks for zeros and negative cases before converting to ternary
        public bool CheckForZeroAndNegatives(int number)
        {
            return (number == 0 || number < 0);
        }

        //checks how many number 2 has the string and returns true if it has two 2s
        public bool CheckForTwos(StringBuilder ternaryString)
        {
            int numberOf2InString = 0;

            for (int i = 0; i < ternaryString.Length; i++)
            {
                if (ternaryString[i] == '2')
                {
                    numberOf2InString++;
                }
            }
            return numberOf2InString == 2;
        }

        //This method converts given number  to ternary number system and returns
        //it as a string
        public StringBuilder ConvertToTernary(int number)
        {
            StringBuilder ternaryString = new StringBuilder();

            if (number == 0)
            {
                return ternaryString;
            }

            int quotient = number / 3;
            int remainder = number % 3;

            ternaryString = ConvertToTernary(quotient);

            ternaryString.Append(remainder);

            return ternaryString;
        }
    }
}
