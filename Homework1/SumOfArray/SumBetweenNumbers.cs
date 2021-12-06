using System;

namespace SumOfArray
{
    internal class SumBetweenNumbers
    {
        //Calculates the sum of numbers between the smallest and the biggest values in the array
        public int PrintSumOfRequaredNumbers(string userInputNumbers)
        {
            int[] convertedNumbers = ConvertsStringToInt(userInputNumbers);
            int maxIndex = FindsMaxValueIndex(convertedNumbers);
            int minIndex = FindsMinValueIndex(convertedNumbers);
            int sumOfRequaredNumbers = 0;

            if (minIndex < maxIndex)
            {
                for (int i = minIndex; i <= maxIndex; i++)
                {
                    sumOfRequaredNumbers += convertedNumbers[i];
                }
            }
            else
            {
                for (int i = maxIndex; i <= minIndex; i++)
                {
                    sumOfRequaredNumbers += convertedNumbers[i];
                }
            }

            return sumOfRequaredNumbers;
        }

        //Converts user input string to int array
        public int[] ConvertsStringToInt(string userInpput)
        {
            string[] arrayOfStrings = userInpput.Split(',');
            int[] userInputNumbers = new int[arrayOfStrings.Length];

            for (int i = 0; i < userInputNumbers.Length; i++)
            {
                userInputNumbers[i] = int.Parse(arrayOfStrings[i]);
            }

            return userInputNumbers;
        }

        //Calculates the biggest most right-hand side number in the array
        public int FindsMaxValueIndex(int[] userInputNumbers)
        {
            int maxValueIndex = 0;

            for (int i = 1; i < userInputNumbers.Length; i++)
            {
                if (userInputNumbers[maxValueIndex] <= userInputNumbers[i])
                {
                    maxValueIndex = i;
                }
            }
            return maxValueIndex;
        }

        //Calculates the smallest most left-hand side number in the array
        public int FindsMinValueIndex(int[] userInputNumbers)
        {
            int minValueIndex = 0;

            for (int i = 1; i < userInputNumbers.Length; i++)
            {
                if (userInputNumbers[minValueIndex] > userInputNumbers[i])
                {
                    minValueIndex = i;
                }
            }
            return minValueIndex;
        }
    }
}
