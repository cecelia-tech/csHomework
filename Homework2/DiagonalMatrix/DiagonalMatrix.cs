using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalMatrix
{
    internal class DiagonalMatrix
    {
        internal int[] DiagonalNumbers { get; }
        public int Size { get; }

        public DiagonalMatrix(params int[] diagonalNumbers)
        {
            this.DiagonalNumbers = diagonalNumbers;
            Size = diagonalNumbers == null ? 0 : diagonalNumbers.Length;
        }

        public int this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < Size && i == j)
                {
                    return DiagonalNumbers[i];
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (i >= 0 && i < Size && i == j)
                {
                    DiagonalNumbers[i] = value;
                }
            }
        }

        public int Track()
        {
            int sum = 0;

            foreach (var number in DiagonalNumbers)
            {
                sum += number;
            }
            return sum;
        }

        public override bool Equals(object obj)
        {
            var matrixToBeCompared = obj as DiagonalMatrix;

            if (this == null ||
                matrixToBeCompared == null ||
                Size != matrixToBeCompared.Size)
            {
                return false;
            }

            for (int i = 0; i < Size; i++)
            {
                if (DiagonalNumbers[i] != matrixToBeCompared.DiagonalNumbers[i])
                {
                    return false;
                }
            }
            return true;
        }

        public override string ToString()
        {
            StringBuilder answer = new StringBuilder();

            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    if (i == j)
                    {
                        answer.Append(DiagonalNumbers[i]).Append('\t');
                    }
                    else
                    {
                        answer.Append(0).Append('\t');
                    }
                }
                answer.Append('\n');
            }
            return answer.ToString();
        }
    }
}
