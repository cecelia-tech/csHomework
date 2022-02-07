using System;
using System.Text;

namespace Task1
{
    public class DiagonalMatrix<T>
    {
        public event EventHandler<UndoArgs<T>> ElementChangedHandler;
        public UndoArgs<T> undoArgs { get; } = new UndoArgs<T>();
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
                        undoArgs.I = i;
                        undoArgs.OldValue = DiagonalNumbers[i];
                        undoArgs.NewValue = value;

                        DiagonalNumbers[i] = value;

                        ElementChangedHandler?.Invoke(this, undoArgs);
                    }
                }
            }
        }

        public void Anouncement(object sender, UndoArgs<T> e)
        {
            Console.WriteLine($"Element at [{e.I}, {e.I}] has been changed from {e.OldValue} to {e.NewValue}");
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
