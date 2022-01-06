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
            //this one decides the size of new "padded array" if matrixes are not equal size, it also works if both arrays are equal,
            //because anyway it will return the size of the second array
            int newSize = firstMatrix.Size > secondMatrix.Size ? firstMatrix.Size : secondMatrix.Size;

            //here we creat a new array if one of the matrixes is smaller or equal
            int[] newElements = new int[newSize];

            for (int i = 0; i < newSize; i++)
            {
                //we can use firstMatrix[i, i], because we have indexer, with which we can iterate the object without needing to specify,
                //that we need only diagonal numbers.... wahh amazing
                newElements[i] = firstMatrix[i, i] + secondMatrix[i, i];
            }

            return new DiagonalMatrix(newElements);
        }
    }
}
