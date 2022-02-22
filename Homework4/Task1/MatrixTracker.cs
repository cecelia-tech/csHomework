using System;
namespace Task1
{
    public class MatrixTracker<T>
    {
        public DiagonalMatrix<T> MatrixReceived { get; }
        private UndoArgs<T> ReceivedUndoArgs { get; set; }
        public MatrixTracker(DiagonalMatrix<T> diagonalMatrix)
        {
            if (diagonalMatrix is null)
            {
                throw new ArgumentNullException();
            }

            MatrixReceived = diagonalMatrix;

            MatrixReceived.ElementChangedHandler += Anouncement;
        }

        public void Anouncement(object sender, UndoArgs<T> e)
        {
            ReceivedUndoArgs = e;
            Console.WriteLine($"Element at [{e.I}, {e.I}] has been changed from {e.OldValue} to {e.NewValue}");
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
