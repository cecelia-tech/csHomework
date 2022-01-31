﻿using System;
using System.Text;

namespace Task1
{
    public class UndoArgs : EventArgs
    {
        public int I { get; set; }
        public dynamic OldValue { get; set; }
        public dynamic NewValue { get; set; }
    }

        public class DiagonalMatrix<T>
    {
        public event EventHandler<UndoArgs> ElementChangedHandler; // this one will save subscribed elements
        public UndoArgs undoArgs;
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
                        UndoArgs undoArgs1 = new UndoArgs();

                        undoArgs1.I = i;
                        undoArgs1.OldValue = DiagonalNumbers[i];
                        undoArgs1.NewValue = value;

                        undoArgs = undoArgs1;

                        ElementChangedHandler?.Invoke(this, undoArgs);
                        DiagonalNumbers[i] = value;
                    }
                }
            }
        }

        public void Anouncement(object sender, UndoArgs e)
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
                    if (i == j)
                    {
                        diagonalMatrixString.Append(DiagonalNumbers[i]).Append('\t');
                    }
                    else
                    {
                        diagonalMatrixString.Append(this[i, j]).Append('\t');
                    }
                }
                diagonalMatrixString.Append('\n');
            }
            return diagonalMatrixString.ToString();
        }
    }
}
