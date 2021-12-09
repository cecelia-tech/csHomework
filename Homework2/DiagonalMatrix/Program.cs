using System;

namespace DiagonalMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] numbersArray = { 1, 2, 3, 4, 5 };

            int[] numbersArray2 = { 6, 7, 8 };

            DiagonalMatrix diagonalMatrix = new DiagonalMatrix(numbersArray);

            diagonalMatrix.PrintDiagonalMatrix();

            Console.WriteLine(diagonalMatrix.ToString());

            DiagonalMatrix diagonalMatrix2 = new DiagonalMatrix(numbersArray2);

            diagonalMatrix2.PrintDiagonalMatrix();

            var addedMatrices = diagonalMatrix.AddsTwoDiagonalMatrices(diagonalMatrix2);

            Console.WriteLine("----------------");

            addedMatrices.PrintDiagonalMatrix();
        }
    }
}
