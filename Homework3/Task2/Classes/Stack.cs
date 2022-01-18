using Task2.Interfaces;

namespace Task2.Classes
{
    public class Stack<T> : IStack<T>
    {
        private const int STACK_SIZE = 5;

        public int Index { get; private set; }

        public T[] stack = new T[STACK_SIZE];

        public bool IsEmpty()
        {
            return Index == 0;
        }

        public T Pop()
        {
            return Index == 0 ? default : stack[--Index];
        }

        public void Push(T number)
        {
            if (Index == stack.Length)
            {
                // does nothing
                return;
            }

            stack[Index++] = number;
        }
    }
}
