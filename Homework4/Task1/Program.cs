using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 1, 2, 3 };
            int[] array2 = { 4, 5, 6, 7 };

            DiagonalMatrix<int> intMatrix1 = new DiagonalMatrix<int>(3, array1);
            DiagonalMatrix<int> intMatrix2 = new DiagonalMatrix<int>(4, array2);

            DiagonalMatrix<int> addedMatrix = intMatrix2.Add(intMatrix2, (a, b) => a + b);

            Console.WriteLine(addedMatrix.ToString());

            MatrixTracker<int> matrixTracker = new MatrixTracker<int>(intMatrix1);

            intMatrix1[0, 0] = 11;
            intMatrix1[1, 1] = 22;
            intMatrix1[2, 2] = 33;

            matrixTracker.Undo();

            Console.WriteLine(intMatrix1.ToString());
        }
    }
}