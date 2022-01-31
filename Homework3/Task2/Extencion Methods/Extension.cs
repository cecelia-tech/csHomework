using Task2.Classes;
using Task2.Interfaces;

namespace Task2.ExtencionMethods
{
    public static class Extension
    {
        public static Stack<T> Reverse<T>(this IStack<T> stack)
        {
            Stack<T> newStack = new Stack<T>();

            while (!stack.IsEmpty())
            {
                newStack.Push(stack.Pop());
            }

            return newStack;
        }
    }
}
