using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    class TabChordFactory
    {
        private TabChordFactory() { }
        public static TabChord getTabByChord(Chord chord, int pitchPosition, Guitar guitar)
        {
            int index = 0;
            int bassString = 0;
            string buildDirection = "";
            int currentPitchPosition = 0;
            TabChord tabChord = new TabChord();
            tabChord.setPitch(pitchPosition);
            while (currentPitchPosition < pitchPosition)
            {
                if(guitar.getNote(6, index, chord.getNoteAt(0)).getValue() == chord.getNoteAt(0).getValue())
                {
                    bassString = 6;
                    tabChord.setFretNumber(6, index.ToString());
                    currentPitchPosition = currentPitchPosition + 1;
                    buildDirection = "right";
                    if (index >=3)
                    {
                        buildDirection = "left";
                        if(currentPitchPosition < pitchPosition)
                        {
                            currentPitchPosition = currentPitchPosition + 1;
                            buildDirection = "right";
                        }
                    }
                    if (currentPitchPosition < pitchPosition) { index = index + 1; }
                }
                else if (guitar.getNote(5, index, chord.getNoteAt(0)).getValue() == chord.getNoteAt(0).getValue())
                {
                    bassString = 5;
                    tabChord.setFretNumber(6, "X");
                    tabChord.setFretNumber(5, index.ToString());
                    currentPitchPosition = currentPitchPosition + 1;
                    buildDirection = "right";
                    if (index >= 3)
                    {
                        buildDirection = "left";
                        if (currentPitchPosition < pitchPosition)
                        {
                            currentPitchPosition = currentPitchPosition + 1;
                            buildDirection = "right";
                        }
                    }
                    if (currentPitchPosition < pitchPosition) { index = index + 1; }
                }
                else if (guitar.getNote(4, index, chord.getNoteAt(0)).getValue() == chord.getNoteAt(0).getValue())
                {
                    bassString = 4;
                    tabChord.setFretNumber(6, "X");
                    tabChord.setFretNumber(5, "X");
                    tabChord.setFretNumber(4, index.ToString());
                    currentPitchPosition = currentPitchPosition + 1;
                    buildDirection = "right";
                    if (index >= 3)
                    {
                        buildDirection = "left";
                        if (currentPitchPosition < pitchPosition)
                        {
                            currentPitchPosition = currentPitchPosition + 1;
                            buildDirection = "right";
                        }
                    }
                    if (currentPitchPosition < pitchPosition) { index = index + 1; }
                }
                else { index = index + 1; }
            }

            int nextString = bassString - 1;
            bool found;
            if(buildDirection == "right")
            {
                while (nextString > 0)
                {
                    found = false;
                    for (int i = index + 3; i >= index; i--)
                    {
                        for(int j = 0; j < chord.getSize(); j++)
                        {
                            if (chord.getNoteAt(j).getValue() == guitar.getNote(nextString, i, chord.getNoteAt(0)).getValue())
                            {
                                found = true;
                                tabChord.setFretNumber(nextString, i.ToString());
                            }
                        }
                    }
                    if (found == false) { tabChord.setFretNumber(nextString, "X"); }
                    nextString = nextString - 1;
                }
            }
            else if (buildDirection == "left")
            {
                while (nextString > 0)
                {
                    found = false;
                    for (int i = index; i >= index - 3; i--)
                    {
                        for (int j = 0; j < chord.getSize(); j++)
                        {
                            if (chord.getNoteAt(j).getValue() == guitar.getNote(nextString, i, chord.getNoteAt(0)).getValue())
                            {
                                found = true;
                                tabChord.setFretNumber(nextString, i.ToString());
                            }
                        }
                    }
                    if (found == false) { tabChord.setFretNumber(nextString, "X"); }
                    nextString = nextString - 1;
                }
            }
            else { throw new System.ArgumentException("Tablature building for chord " + chord.getName() + " failed", "tabChordFactory"); }
            return tabChord;
        }
    }
}
