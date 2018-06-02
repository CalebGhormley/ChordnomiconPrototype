using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    class Guitar
    {
        private List<Note> tuning = new List<Note>();

        public Guitar ()
        {
            tuning.Add(NoteFactory.getNoteByName("E"));
            tuning.Add(NoteFactory.getNoteByName("B"));
            tuning.Add(NoteFactory.getNoteByName("G"));
            tuning.Add(NoteFactory.getNoteByName("D"));
            tuning.Add(NoteFactory.getNoteByName("A"));
            tuning.Add(NoteFactory.getNoteByName("E"));
        }
        public Guitar(Note six, Note five, Note four, Note three, Note two, Note one)
        {
            tuning.Add(one);
            tuning.Add(two);
            tuning.Add(three);
            tuning.Add(four);
            tuning.Add(five);
            tuning.Add(six);
        }
        
        public void changeTunning(Note six, Note five, Note four, Note three, Note two, Note one)
        {
            tuning.Clear();
            tuning.Add(one);
            tuning.Add(two);
            tuning.Add(three);
            tuning.Add(four);
            tuning.Add(five);
            tuning.Add(six);
        }

        public Note getNote(int guitarString, int fret, Note key)
        {
            int value = fret + tuning.ElementAt(guitarString - 1).getValue();
            while (value > 12) { value = value - 12; }
            return NoteFactory.getNoteByValue(value, key);
        }
    }
}
