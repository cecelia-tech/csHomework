using Task2.Classes;
using Task2.Interfaces;

namespace Task2.ExtencionMethods
{
    public static class Extension
    {
        public static Stack<T> Reverse<T>(this IStack<T> stack)
        {
            Stack<T> newStack = new Stack<T>();

            if (stack is Stack<T> stack2)
            {
                int stackLength = stack2.Index;

                for (int i = 0; i < stack2.Index; i++)
                {
                    newStack.Push(stack2.stack[--stackLength]);
                }
            }

            return newStack;
        }
    }
}
