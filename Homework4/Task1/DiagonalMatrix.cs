using System;
using System.Text;

namespace Task1
{
    public class DiagonalMatrix<T>
    {
        public event EventHandler<UndoArgs<T>> ElementChangedHandler;
        public T[] DiagonalNumbers { get; }
        public int Size { get; }

        public DiagonalMatrix(int size, params T[] diagonalNumbers)
        {
            if (size < 0 || size > diagonalNumbers.Length)
            {
                throw new ArgumentException();
            }
            else
            {
                Size = size;
            }

            DiagonalNumbers = diagonalNumbers;
        }

        public T this[int i, int j]
        {
            get
            {
                if (i < 0 ||
                    j < 0 ||
                    i >= Size ||
                    j >= Size)
                {
                    throw new IndexOutOfRangeException();
                }
                else if (i == j)
                {
                    return DiagonalNumbers[i];
                }
                else
                {
                    return default;
                }
            }
            set
            {
                if (i < 0 ||
                    j < 0 ||
                    i >= Size ||
                    j >= Size)
                {
                    throw new IndexOutOfRangeException();
                }
                else if (i == j)
                {
                    if (!DiagonalNumbers[i].Equals(value))
                    {
                        T oldvalue = DiagonalNumbers[i];
                        DiagonalNumbers[i] = value;

                        ElementChangedHandler?.Invoke(this, new UndoArgs<T>(i, oldvalue, value));
                    }
                }
            }
        }

        

        public override string ToString()
        {
            StringBuilder diagonalMatrixString = new StringBuilder();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    diagonalMatrixString.Append(this[i, j]).Append('\t');
                }

                diagonalMatrixString.Append('\n');
            }

            return diagonalMatrixString.ToString();
        }
    }
}
