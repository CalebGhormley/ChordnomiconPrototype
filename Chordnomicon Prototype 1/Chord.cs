using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    class Chord
    {

        public Chord() { }

        private string _name;
        public string getName() { return _name; }
        public void setName(string name) { _name = name; }

        List<Note> notes = new List<Note>();
        public void addNote(Note note) { notes.Add(note); }
        public void insertNote(Note note, int index) { notes.Insert(index, note); }
        public String getNotes()
        {
            string notesInChord = notes.ElementAt(0).getName();
            for (int i = 1; i < notes.Count(); i++)
            {
                notesInChord = notesInChord + ", " + notes.ElementAt(i).getName();
            }
            return notesInChord;
        }
        public int getSize() { return notes.Count; }
        public int getTonicValue() { return notes.ElementAt(0).getValue(); }
        public Note getNoteAt(int position) { return notes.ElementAt(position); }

    }
}
