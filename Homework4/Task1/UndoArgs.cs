using System;

namespace Task1
{
    public class UndoArgs<T> : EventArgs
    {
        public int I { get; set; }
        public T OldValue { get; set; }
        public T NewValue { get; set; }

        public UndoArgs(int i, T oldValue, T newValue)
        {
            I = i;
            OldValue = oldValue;
            NewValue = newValue;
        }
    }
}
