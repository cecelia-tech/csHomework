﻿using System;

namespace SumOfArray
{
    class SumBetweenNumbers
    {
        //Converts user input string to int array
        public int[] StringToInt(string userInpput)
        {
            int[] userInputNumbers = new int[userInpput.Length];

            for (int i = 0; i < userInputNumbers.Length; i++)
            {
                if (userInpput[i] == '-')
                {
                    userInputNumbers[i] = (int)Char.GetNumericValue(userInpput[i]);
                }
                userInputNumbers[i] = (int)Char.GetNumericValue(userInpput[i]);
            }

            return userInputNumbers;
        }

        //Finds index of max value in the array
        public int MaxValueIndex(int[] userInputNumbers)
        {
            int maxValueIndex = 0;

            for (int i = 1; i < userInputNumbers.Length; i++)
            {
                if (userInputNumbers[maxValueIndex] > userInputNumbers[i])
                {
                    maxValueIndex = i;
                }
            }
            return maxValueIndex;
        }

        //Finds index of min value in the array
        public int MinValueIndex(int[] userInputNumbers)
        {
            int minValueIndex = 0;

            for (int i = 1; i < userInputNumbers.Length; i++)
            {
                if (userInputNumbers[minValueIndex] < userInputNumbers[i])
                {
                    minValueIndex = i;
                }
            }
            return minValueIndex;
        }

        //Calculates the sum of numbers between the smallest and the biggest values in the array
        public int SumOfRequaredNumbers(string userInputNumbers)
        {
            int[] convertedNumbers = StringToInt(userInputNumbers);
            int minIndex = MinValueIndex(convertedNumbers);
            int maxIndex = MaxValueIndex(convertedNumbers);
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

        //public void Print(int[] userInputNumbers, int sumOfRequaredNumbers)
        //{
        //    Console.WriteLine(userInputNumbers);
        //    Console.WriteLine(sumOfRequaredNumbers);
        //}
    }
}
