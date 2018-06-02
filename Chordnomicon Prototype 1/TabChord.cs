using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    class TabChord
    {
        public TabChord() { }
        private string[] fretNumbers = new string[6];
        public void setFretNumber (int _string, string value) { fretNumbers[_string - 1] = value; }
        public string getFretNumber (int _string) { return fretNumbers[_string - 1]; }
        private int pitch;
        public int getPitch() { return pitch; }
        public void setPitch(int _pitch) { pitch = _pitch; }
    }
}
