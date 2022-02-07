using System;
namespace Task1
{
    public static class Extension
    {
        public static DiagonalMatrix<T> Add<T>(this DiagonalMatrix<T> firstMatrix, 
                                                DiagonalMatrix<T> secondMatrix, 
                                                Func<T, T, T> func)
        {
            if (firstMatrix is null || secondMatrix is null)
            {
                throw new ArgumentNullException();
            }

            int newSize = firstMatrix.Size > secondMatrix.Size ? firstMatrix.Size : secondMatrix.Size;

            T[] newElements = new T[newSize];

                for (int i = 0; i < newSize; i++)
                {
                    if (firstMatrix.Size > i)
                    {
                       newElements[i] = func(firstMatrix[i, i], newElements[i]);
                    }
                    
                    if (secondMatrix.Size > i)
                    {
                        newElements[i] = func(secondMatrix[i, i], newElements[i]);
                    }
                }

            return new DiagonalMatrix<T>(newSize, newElements);
        }
    }
}
