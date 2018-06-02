using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    class Mode
    {
        private string _name;
        private List<Interval> intervals = new List<Interval>();
        public Mode() { }
        
        public void setName (string name) { _name = name; }
        public string getName () { return _name; }
        public void addInterval(Interval interval) { intervals.Add(interval); }
        public int getSize() { return intervals.Count(); }
        public string getIntervalNames()
        {
            
            string names = "";
            for (int i = 0; i < intervals.Count; i++)
            {
                names = names + intervals.ElementAt(0).ToString();
                if (i < intervals.Count - 1) { names = names + ", "; }
            }
            return names;
        }
        public int getIntervalValue(int position)
        {
            return intervals.ElementAt(position).getIntervalValue();
        }
        public string getIntervalName(int position)
        {
            return intervals.ElementAt(position).getName();
        }
        public bool containsInterval(string intervalName)
        {
            for (int i = 0; i < 7; i++)
            {
                if(intervals.ElementAt(i).getName() == intervalName) { return true; }
            }
            return false;
        }
        public bool containsInterval(int intervalValue)
        {
            for (int i = 0; i < 7; i++)
            {
                if (intervals.ElementAt(i).getIntervalValue() == intervalValue) { return true; }
            }
            return false;
        }
        public bool containsNote(Note note, Note key)
        {
            int distance;
            distance = note.getValue() - key.getValue();
            if (distance < 0) { distance = distance + 12; }
            for (int i = 0; i < 7; i++)
            {
                if (intervals.ElementAt(i).getIntervalValue() == distance) { return true; }
            }
            return false;
        }
        public Note getNote(int index, Note key)
        {
            int distance;
            Note note;
            distance = intervals.ElementAt(index).getIntervalValue() + key.getValue();
            if (distance > 12) { distance = distance - 12; }
            note = NoteFactory.getNoteByValue(distance, key);
            return note;
        }
    }
}
