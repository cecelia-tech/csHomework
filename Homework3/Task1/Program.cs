using System;
using Task1.Enums;
using Task1.Structs;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Key key1 = new Key(Note.B, Accidental.NoSign, Octave.Great);
            Key key2 = new Key(Note.E, Accidental.Flat, Octave.Great);

            Key gSharp = new Key(Note.G, Accidental.Sharp, Octave.Contra);
            Key aFlat = new Key(Note.A, Accidental.Flat, Octave.Contra);

            Console.WriteLine(key2);
            Console.WriteLine(gSharp.Equals(aFlat));
            Console.WriteLine(key2.Equals(null));
            Console.WriteLine(key1.CompareTo(key2));
        }
    }
}
