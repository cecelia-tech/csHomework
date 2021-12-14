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
            int[] _firstDiagonal = firstMatrix.diagonalNumbers;
            int[] _secondDiagonal = secondMatrix.diagonalNumbers;
            int[] _paddedArray;
            int[] _sumedArray;

            if (_firstDiagonal.Length < _secondDiagonal.Length)
            {
                _paddedArray = new int[_secondDiagonal.Length];

                Array.Copy(_firstDiagonal, _paddedArray, _firstDiagonal.Length);

                _sumedArray = new int[_paddedArray.Length];

                _sumedArray = _secondDiagonal.Zip(_paddedArray, (number1, number2) => number1 + number2).ToArray();
            }
            else if (_firstDiagonal.Length > _secondDiagonal.Length)
            {
                _paddedArray = new int[_firstDiagonal.Length];

                Array.Copy(_secondDiagonal, _paddedArray, _secondDiagonal.Length);

                _sumedArray = new int[_paddedArray.Length];

                _sumedArray = _firstDiagonal.Zip(_paddedArray, (number1, number2) => number1 + number2).ToArray();
            }
            else
            {
                _sumedArray = new int[_firstDiagonal.Length];

                _sumedArray = _firstDiagonal.Zip(_secondDiagonal, (number1, number2) => number1 + number2).ToArray();
            }
            return new DiagonalMatrix(_sumedArray);
        }
    }
}
