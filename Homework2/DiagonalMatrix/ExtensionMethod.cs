using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagonalMatrix
{

    internal static class ExtensionMethod
    {
        public static DiagonalMatrix AddsTwoDiagonalMatrices(this DiagonalMatrix firstMatrix, DiagonalMatrix secondMatrix)
        {
            int[] _firstDiagonal = firstMatrix.diagonalNumbers;
            int[] _secondDiagonal = secondMatrix.diagonalNumbers;

            //can i pad the original array or create a new

            int[] _sumedArray;

            //summing if first array is shorter
            if (_firstDiagonal.Length < _secondDiagonal.Length)
            {
                int[] _paddedArray = new int[_secondDiagonal.Length];

                for (int i = 0; i < _paddedArray.Length; i++)
                {
                    if (i < _firstDiagonal.Length)
                    {
                        _paddedArray[i] = _firstDiagonal[i];
                    }
                    else
                    {
                        _paddedArray[i] = 0;
                    }

                }

                _sumedArray = new int[_paddedArray.Length];

                for (int i = 0; i < _paddedArray.Length; i++)
                {
                    _sumedArray[i] = _paddedArray[i] + _secondDiagonal[i];
                }

                //Array.Resize(ref firstMatrix, secondMatrix.Length);

            } //summing if second array is shorter
            else if (_firstDiagonal.Length > _secondDiagonal.Length)
            {
                int[] _paddedArray = new int[_firstDiagonal.Length];

                for (int i = 0; i < _paddedArray.Length; i++)
                {
                    if (i < _secondDiagonal.Length)
                    {
                        _paddedArray[i] = _secondDiagonal[i];
                    }
                    else
                    {
                        _paddedArray[i] = 0;
                    }

                }

                _sumedArray = new int[_paddedArray.Length];

                for (int i = 0; i < _paddedArray.Length; i++)
                {
                    _sumedArray[i] = _paddedArray[i] + _firstDiagonal[i];
                }
            } //summing if both arrays are equal
            else
            {
                _sumedArray = new int[_firstDiagonal.Length];

                for (int i = 0; i < _firstDiagonal.Length; i++)
                {
                    _sumedArray[i] = _firstDiagonal[i] + _secondDiagonal[i];
                }
            }
            return new DiagonalMatrix(_sumedArray);
        }
    }
}
