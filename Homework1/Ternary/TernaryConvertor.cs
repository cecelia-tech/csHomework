using System;
using System.Text;

namespace Ternary
{
    class TernaryConvertor
    {
        //Method checks for numbers satisfying the task in the range given
        public void CheckForAppropriateInteger(int numberFrom, int numberTo)
        {
            for (int i = numberFrom; i <= numberTo; i++)
            {
                if (CheckForTwos(ConvertToTernary(i)))
                {
                    NumberPrint(i);
                }
            }
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

            //since ternary base is 3, it is okay to hardcode it
            int quotient = number / 3;
            int remainder = number % 3;

            //the ternaryString is made by adding each number to the front of
            //the array
            ternaryString.Insert(0, remainder);

            if (quotient >= 3)
            {
                ternaryString.Insert(0, ConvertToTernary(quotient));
            }
            else
            {
                //ternary number system first number always is 1
                ternaryString.Insert(0, 1);
            }

            return ternaryString;
        }

        public void NumberPrint(int number)
        {
            Console.WriteLine(number);
        }
    }
}
