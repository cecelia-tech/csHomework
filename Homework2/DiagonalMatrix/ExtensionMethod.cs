using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalMatrix
{
    internal static class ExtensionMethod
    {
        public static DiagonalMatrix Add(this DiagonalMatrix firstMatrix, DiagonalMatrix secondMatrix)
        { 
            int newSize = firstMatrix.Size > secondMatrix.Size ? firstMatrix.Size : secondMatrix.Size;

            int[] newElements = new int[newSize];

            for (int i = 0; i < newSize; i++)
            {
                newElements[i] = firstMatrix[i, i] + secondMatrix[i, i];
            }

            return new DiagonalMatrix(newElements);
        }
    }
}
