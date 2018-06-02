using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    class NoteFactory
    {
        private static Note _note;
        
        public static Note getNoteByName (string name)
        {
            if (name == "A") { _note = new Note(1, name); }
            else if (name == "A#") { _note = new Note(2, name); }
            else if (name == "Bb") { _note = new Note(2, name); }
            else if (name == "B") { _note = new Note(3, name); }
            else if (name == "C") { _note = new Note(4, name); }
            else if (name == "C#") { _note = new Note(5, name); }
            else if (name == "Db") { _note = new Note(5, name); }
            else if (name == "D") { _note = new Note(6, name); }
            else if (name == "D#") { _note = new Note(7, name); }
            else if (name == "Eb") { _note = new Note(7, name); }
            else if (name == "E") { _note = new Note(8, name); }
            else if (name == "F") { _note = new Note(9, name); }
            else if (name == "F#") { _note = new Note(10, name); }
            else if (name == "Gb") { _note = new Note(10, name); }
            else if (name == "G") { _note = new Note(11, name); }
            else if (name == "G#") { _note = new Note(12, name); }
            else if (name == "Ab") { _note = new Note(12, name); }
            else { throw new System.ArgumentException("Parameter must have a valid name", "Note name: " + name); }
            return _note;
        }

        public static Note getNoteByValue (int value, Note key)
        {
            int distance = value - key.getValue();
            if (distance < 0) { distance = distance + 12; }

            if (value == 1) { _note = new Note(value, "A"); }
            else if (value == 2)
            {
                if (distance == 0) { _note = new Note(value, key.getName()); }
                else if (key.getName().ToCharArray().Count() == 2)
                {
                    if (key.getName().ToCharArray()[1] == '#') { _note = new Note(value, "A#"); }
                    else if (key.getName().ToCharArray()[1] == 'b') { _note = new Note(value, "Bb"); }
                    else { throw new System.ArgumentException("Parameter did not have a valid key", "Key name: " + key.getName()); }
                }
                else if (distance == 2 || distance == 4 || distance == 7 || distance == 9 || distance == 11)
                { _note = new Note(value, "A#"); }
                else { _note = new Note(value, "Bb"); }

            }
            else if (value == 3) { _note = new Note(value, "B"); }
            else if (value == 4) { _note = new Note(value, "C"); }
            else if (value == 5)
            {
                if (distance == 0) { _note = new Note(value, key.getName()); }
                else if (key.getName().ToCharArray().Count() == 2)
                {
                    if (key.getName().ToCharArray()[1] == '#') { _note = new Note(value, "C#"); }
                    else if (key.getName().ToCharArray()[1] == 'b') { _note = new Note(value, "Db"); }
                    else { throw new System.ArgumentException("Parameter did not have a valid key", "Key name: " + key.getName()); }
                }
                else if (distance == 2 || distance == 4 || distance == 7 || distance == 9 || distance == 11)
                { _note = new Note(value, "C#"); }
                else { _note = new Note(value, "Db"); }
            }
            else if (value == 6) { _note = new Note(value, "D"); }
            else if (value == 7)
            {
                if (distance == 0) { _note = new Note(value, key.getName()); }
                else if (key.getName().ToCharArray().Count() == 2)
                {
                    if (key.getName().ToCharArray()[1] == '#') { _note = new Note(value, "D#"); }
                    else if (key.getName().ToCharArray()[1] == 'b') { _note = new Note(value, "Eb"); }
                    else { throw new System.ArgumentException("Parameter did not have a valid key", "Key name: " + key.getName()); }
                }
                else if (distance == 2 || distance == 4 || distance == 7 || distance == 9 || distance == 11)
                { _note = new Note(value, "D#"); }
                else { _note = new Note(value, "Eb"); }
            }
            else if (value == 8) { _note = new Note(value, "E"); }
            else if (value == 9) { _note = new Note(value, "F"); }
            else if (value == 10)
            {
                if (distance == 0) { _note = new Note(value, key.getName()); }
                else if (key.getName().ToCharArray().Count() == 2)
                {
                    if (key.getName().ToCharArray()[1] == '#') { _note = new Note(value, "F#"); }
                    else if (key.getName().ToCharArray()[1] == 'b') { _note = new Note(value, "Gb"); }
                    else { throw new System.ArgumentException("Parameter did not have a valid key", "Key name: " + key.getName()); }
                }
                else if (distance == 2 || distance == 4 || distance == 7 || distance == 9 || distance == 11)
                { _note = new Note(value, "F#"); }
                else { _note = new Note(value, "Gb"); }
            }
            else if (value == 11) { _note = new Note(value, "G"); }
            else if (value == 12)
            {
                if (distance == 0) { _note = new Note(value, key.getName()); }
                else if (key.getName().ToCharArray().Count() == 2)
                {
                    if (key.getName().ToCharArray()[1] == '#') { _note = new Note(value, "G#"); }
                    else if (key.getName().ToCharArray()[1] == 'b') { _note = new Note(value, "Ab"); }
                    else { throw new System.ArgumentException("Parameter did not have a valid key", "Key name: " + key.getName()); }
                }
                else if (distance == 2 || distance == 4 || distance == 7 || distance == 9 || distance == 11)
                { _note = new Note(value, "G#"); }
                else { _note = new Note(value, "Ab"); }
            }
            else { throw new System.ArgumentException("Parameter cannot be less than 1 or greater than 12", "Note value:" + value); }

            return _note;
        }
    }
}
