using System;

namespace DiagonalMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = { 1, 2, 3, 4, 5 };

            int[] numbersArray2 = { 11, 22, 33 };

            DiagonalMatrix diagonalMatrix = new DiagonalMatrix(numbersArray);

            Console.WriteLine("ToString method: ");
            Console.WriteLine(diagonalMatrix.ToString());
            Console.WriteLine("----------------");

            DiagonalMatrix diagonalMatrix2 = new DiagonalMatrix(numbersArray2);

            Console.WriteLine("Checking the Add method");
            var addedMatrices = diagonalMatrix2.Add(diagonalMatrix);

            Console.WriteLine(addedMatrices.ToString());
            Console.WriteLine("----------------");

            Console.WriteLine("Equals method: ");
            Console.WriteLine(diagonalMatrix2.Equals(diagonalMatrix));
            Console.WriteLine("----------------");

            Console.WriteLine("Indexer check: ");
            Console.WriteLine(diagonalMatrix2[0, 0]);
            Console.WriteLine(diagonalMatrix2[0, 7]);
            diagonalMatrix2[0, 0] = 44;
            Console.WriteLine(diagonalMatrix2[0, 0]);
            Console.WriteLine("----------------");

            Console.WriteLine("Size of the first matrix: ");
            Console.WriteLine(diagonalMatrix.Size);
            Console.WriteLine("----------------");

            Console.WriteLine("Track method of the second matrix: ");
            Console.WriteLine(diagonalMatrix2.Track());
        }
    }
}
