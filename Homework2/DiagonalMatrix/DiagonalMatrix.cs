using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalMatrix
{
    internal class DiagonalMatrix
    {
        internal int[] diagonalNumbers { get; }
        private int size;

        public int Size
        {
            get => size;
        }

        public DiagonalMatrix(params int[] diagonalNumbers)
        {
            this.diagonalNumbers = diagonalNumbers;
            size = diagonalNumbers == null ? 0 : diagonalNumbers.Length;
        }

        public int this[int i, int j]
        {
            get
            {
                return i == j ? diagonalNumbers[i] : 0;
            }
            set
            {
                if (i == j)
                {
                    diagonalNumbers[i] = value;
                }
            }
        }

        public int Track()
        {
            int _sum = 0;

            foreach (var _number in diagonalNumbers)
            {
                _sum += _number;
            }
            return _sum;
        }

        public override bool Equals(object obj)
        {
            var _diagonalMatrix = obj as DiagonalMatrix;

            if (this == null ||
                _diagonalMatrix == null ||
                _diagonalMatrix.size == 0 ||
                size == 0 ||
                size != _diagonalMatrix.size)
            {
                return false;
            }

            for (int i = 0; i < size; i++)
            {
                if (diagonalNumbers[i] != _diagonalMatrix.diagonalNumbers[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder _answer = new StringBuilder();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (i == j)
                    {
                        _answer.Append(diagonalNumbers[i]).Append('\t');
                    }
                    else
                    {
                        _answer.Append(0).Append('\t');
                    }
                }
                _answer.Append('\n');
            }
            return _answer.ToString();
        }
    }
}
