using System;
namespace Task1
{
    public class MatrixTracker<T>
    {
        public DiagonalMatrix<T> MatrixReceived { get; }
        private UndoArgs<T> ReceivedUndoArgs { get; }
        public MatrixTracker(DiagonalMatrix<T> diagonalMatrix)
        {
            if (diagonalMatrix is null)
            {
                throw new ArgumentNullException();
            }

            MatrixReceived = diagonalMatrix;
            ReceivedUndoArgs = diagonalMatrix.undoArgs;

            MatrixReceived.ElementChangedHandler += MatrixReceived.Anouncement;
        }

        public void Undo()
        {
            if (ReceivedUndoArgs != null)
            {
                MatrixReceived[ReceivedUndoArgs.I, ReceivedUndoArgs.I] = ReceivedUndoArgs.OldValue;
            }
            else
            {
                throw new ArgumentNullException();
            }
        }
    }
}
