using System;
using Task1.Enums;

namespace Task1.Structs
{
    public struct Key : IComparable<Key>
    {
        readonly Octave Octave;
        readonly Note Note;
        readonly Accidental Accidental;

        public Key(Note note, Accidental accidental, Octave octave)
        {
            Octave = octave;
            Note = note;
            Accidental = accidental;
        }

        public override string ToString()
        {
            var symbol = Accidental.Sharp == Accidental ? "Sharp" :
                         Accidental.Flat == Accidental ? "Flat" : "";

            return $"{Note} {symbol} ({Octave})";
        }

        public override bool Equals(object obj)
        {
            var key = (Key)obj;

            if (Octave != key.Octave)
            {
                return false;
            }

            if (key.Note == Note &&
                key.Accidental == Accidental
                )
            {
                return true;
            }

            //deals with regular sharp and flat
            if ((Note + 1 == key.Note &&
                Accidental == Accidental.Sharp && key.Accidental == Accidental.Flat) ||
                (Note - 1 == key.Note &&
                Accidental == Accidental.Flat && key.Accidental == Accidental.Sharp)
                )
            {
                return true;
            }
            //deals with one flat and other one no sign
            else if ((Note + 1 == key.Note &&
                Accidental == Accidental.NoSign && key.Accidental == Accidental.Flat) ||
                (Note - 1 == key.Note &&
                Accidental == Accidental.Flat && key.Accidental == Accidental.NoSign)
                )
            {
                return true;
            }
            //deals with A and G
            else if ((Note == Note.G &&
                key.Note == Note.A &&
                Accidental == Accidental.Sharp && key.Accidental == Accidental.Flat) ||
                (Note == Note.A &&
                key.Note == Note.G &&
                Accidental == Accidental.Flat && key.Accidental == Accidental.Sharp)
                )
            {
                return true;
            }

            return false;
        }

        public int CompareTo(Key other)
        {
            if (this.Equals(other))
            {
                return 0;
            }
            return Note.CompareTo(other.Note);
        }
    }
}
