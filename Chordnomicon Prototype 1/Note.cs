using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    class Note
    {
        private Note() { }
        public Note (int v, string n )
        {
            value = v;
            name = n;
        }
        private string name { get; }
        private int value { get; }
        public int getValue () { return value; }
        public string getName () { return name; }
        
    }
}
