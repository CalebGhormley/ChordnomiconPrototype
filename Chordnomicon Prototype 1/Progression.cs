using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    class Progression
    {
        public Progression()
        {
            _key = new Note(4, "C");
            _mode = new Mode();
            _mode = ModeFactory.getModeByName("Ionian");
        }
        public Progression(string key, string mode)
        {
            _key = NoteFactory.getNoteByName(key);
            _mode = new Mode();
            _mode = ModeFactory.getModeByName(mode);
        }

        private Note _key;
        public void changeKey(Note key) { _key = key; }
        public Note getKey() { return _key; }

        private Mode _mode;
        public void changeMode(string mode) { _mode = ModeFactory.getModeByName(mode); }
        public Mode getMode() { return _mode; }

        private Guitar _guitar = new Guitar();
        public Guitar getGuitar() { return _guitar; }
        public void changeTuning(Note six, Note five, Note four, Note three, Note two, Note one) 
        {
            _guitar.changeTunning(six, five, four, three, two, one);
            TabChord tempTab;
            for (int i = 0; i < getSize(); i++)
            {
                tempTab = TabChordFactory.getTabByChord(chords.ElementAt(i), tablature.ElementAt(i).getPitch(), _guitar);
                tablature.RemoveAt(i);
                tablature.Insert(i, tempTab);
            }
        }
        public string getTuning()
        {
            string tuning = "";
            for (int i = 6; i > 0; i--)
            {
                tuning = tuning + _guitar.getNote(i, 0, _key).getName();
                if(i > 1) { tuning = tuning + ", "; }
            }
            return tuning;
        }

        private List<Chord> chords = new List<Chord>();
        private List<TabChord> tablature = new List<TabChord>();

        public void addChord(Chord chord)
        {
            chords.Add(chord);
            tablature.Add(TabChordFactory.getTabByChord(chord, 1, _guitar));
        }
        public void replaceChord(int location, Chord chord)
        {
            chords.RemoveAt(location);
            chords.Insert(location, chord);
            tablature.Insert(location, TabChordFactory.getTabByChord(chord, 1, _guitar));
        }
        public void swapChords(int locationOne, int locationTwo)
        {
            Chord tempOne = chords.ElementAt(locationOne);
            Chord tempTwo = chords.ElementAt(locationTwo);
            chords.RemoveAt(locationOne);
            chords.Insert(locationOne, tempTwo);
            chords.RemoveAt(locationTwo);
            chords.Insert(locationTwo, tempOne);

            TabChord tempTabOne = tablature.ElementAt(locationOne);
            TabChord tempTabTwo = tablature.ElementAt(locationTwo);
            tablature.RemoveAt(locationOne);
            tablature.Insert(locationOne, tempTabTwo);
            tablature.RemoveAt(locationTwo);
            tablature.Insert(locationTwo, tempTabOne);
        }
        public void removeChord(int location)
        {
            chords.RemoveAt(location);
            tablature.RemoveAt(location);
        }
        public void clearProgression()
        {
            chords.Clear();
            tablature.Clear();
        }
        public string getChordNames ()
        {
            string names = "";
            Chord _chord;
            for (int i = 0; i < chords.Count; i++ )
            {
                _chord = chords.ElementAt(i);
                names = names + _chord.getName();
                if (i < chords.Count - 1) { names = names + ", "; }
            }
            return names;
        }
        public Chord getChord(int position)
        {
            return(chords.ElementAt(position));
        }
        public int getSize() { return chords.Count; }
        public string getTabNumber(int _chord, int _string)
        { return tablature.ElementAt(_chord - 1).getFretNumber(_string); }
        public int getTabPitch(int _chord)
        { return tablature.ElementAt(_chord - 1).getPitch(); }
        public void changeTabPitch (int chordPosition, int newPitchPosition)
        {
            Chord tempChord = chords.ElementAt(chordPosition - 1);
            tablature.RemoveAt(chordPosition - 1);
            tablature.Insert(chordPosition - 1, TabChordFactory.getTabByChord(tempChord, newPitchPosition, _guitar));
        }
    }
}
