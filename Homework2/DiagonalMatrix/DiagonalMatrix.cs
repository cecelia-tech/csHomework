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
        private readonly int size;


        public DiagonalMatrix(params int[] diagonalNumbers)
        {
            this.diagonalNumbers = diagonalNumbers;

            //is it okay to write trenary in a constructor?
            size = diagonalNumbers == null ? 0 : diagonalNumbers.Length;
        }

        //track method returns how many numbers or the sum of elements values??
        public int Track(int[] diagonalNumbers)
        {
            int _sum = 0;

            foreach (var _number in diagonalNumbers)
            {
                _sum += _number;
            }

            return _sum;
        }

        //part 4 from task
        public void PrintDiagonalMatrix()
        {
            //how do we implement outOfBounds and overall is it a good approach???

            for (int i = 0; i < diagonalNumbers.Length; i++)
            {
                for (int j = 0; j < diagonalNumbers.Length; j++)
                {
                    if (i == j)
                    {
                        Console.Write(diagonalNumbers[i]);
                        Console.Write("\t");
                    }
                    else if (i != j)
                    {
                        Console.Write(0);
                        Console.Write("\t");
                    }
                }
                Console.WriteLine();
            }
        }
        /*
        public override bool Equals(object obj)
        {
            var _diagonalMatrix = obj as DiagonalMatrix;
            bool isEqual = true;
            if (_diagonalMatrix == null ||
                diagonalNumbers.Length != _diagonalMatrix.diagonalNumbers.Length)
            {
                isEqual = false;
            }
            for (int i = 0; i < diagonalNumbers.Length; i++)
            {
                if (diagonalNumbers[i] != _diagonalMatrix.diagonalNumbers[i])
                {
                    isEqual = false;
                }
            }
            return isEqual;
        }
        */

        public override string ToString()
        {
            string _answer = string.Empty;

            foreach (var _number in diagonalNumbers)
            {
                _answer += _number.ToString();
            }
            //what do we want to return with this method?
            return base.ToString() + " " + _answer;
        }
    }
}
