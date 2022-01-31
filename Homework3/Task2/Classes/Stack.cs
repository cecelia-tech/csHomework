using System.Text;
using Task2.Interfaces;

namespace Task2.Classes
{
    public class Stack<T> : IStack<T>
    {
        private const int STACK_SIZE = 5;

        private int index = 0;

        private T[] stack = new T[STACK_SIZE];

        public bool IsEmpty()
        {
            return index == 0;
        }

        public T Pop()
        {
            //it doesn't seem to work properly otherwise, if I change to index--
            //it returns the next default value, if the stack is not full,
            //if the stack is full, it gives IndexOutOfRangeException
            return index == 0 ? default : stack[--index];
        }

        public void Push(T number)
        {
            if (index == stack.Length)
            {
                // does nothing
                return;
            }

            stack[index++] = number;
        }

        public override string ToString()
        {

            StringBuilder stackToString = new StringBuilder();

            for (int i = 0; i < index; i++)
            {
                stackToString.Append(stack[i]);
            }
            return stackToString.ToString();
        }
    }
}
