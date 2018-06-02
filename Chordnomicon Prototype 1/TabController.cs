using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    class TabController
    {
        private TabController() { }
        public static bool checkPitchRange(int newPitch, Note bassNote, Guitar guitar)
        {
            int maxBassNotes = 0;
            int i, j;
            // i = fret, j = string
            for (i = 0; i < 22; i++)
            {
                for (j = 6; j > 3; j--)
                {
                    if (guitar.getNote(j, i, bassNote).getValue() == bassNote.getValue())
                    {
                        if (i >= 3 && i < 18) { maxBassNotes = maxBassNotes + 2; }
                        else { maxBassNotes = maxBassNotes + 1; }
                    }
                }
            }
            if (newPitch <= maxBassNotes && newPitch > 0) { return true; }
            else { return false; }
        }
    }
}
