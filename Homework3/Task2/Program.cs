using System;
using Task2.Classes;
using Task2.ExtencionMethods;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> st = new Stack<int>();

            Console.WriteLine("Popping from an empty array");
            Console.WriteLine(st.Pop());

            Console.WriteLine("IsEmpty() method on an empty stack");
            Console.WriteLine(st.IsEmpty());

            st.Push(1);
            st.Push(2);
            st.Push(3);

            Console.WriteLine("IsEmpty() method on not an empty stack");
            Console.WriteLine(st.IsEmpty());

            Stack<int> st2 = st.Reverse();

            Console.WriteLine("Printing reversed stack");

            Console.WriteLine(st2.ToString()); 

            //checking different generic type
            Stack<string> st3 = new Stack<string>();

            st3.Push("1");
            st3.Push("2");
            st3.Push("3");
            st3.Push("4");
            st3.Push("5");
            //trying to push into a full stack
            st3.Push("6");

            st3.Pop();

            Console.WriteLine(st3.ToString());
        }
    }
}
