using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    class ModeFactory
    {
        public static Mode getModeByName(string name)
        {
            Mode mode = new Mode();
            mode.setName(name);
            if (name == "Lydian")
            {
                mode.addInterval(IntervalFactory.getIntervalByName("R"));
                mode.addInterval(IntervalFactory.getIntervalByName("M2"));
                mode.addInterval(IntervalFactory.getIntervalByName("M3"));
                mode.addInterval(IntervalFactory.getIntervalByName("aug4"));
                mode.addInterval(IntervalFactory.getIntervalByName("P5"));
                mode.addInterval(IntervalFactory.getIntervalByName("M6"));
                mode.addInterval(IntervalFactory.getIntervalByName("M7"));
            }
            else if (name == "Ionian")
            {
                mode.addInterval(IntervalFactory.getIntervalByName("R"));
                mode.addInterval(IntervalFactory.getIntervalByName("M2"));
                mode.addInterval(IntervalFactory.getIntervalByName("M3"));
                mode.addInterval(IntervalFactory.getIntervalByName("P4"));
                mode.addInterval(IntervalFactory.getIntervalByName("P5"));
                mode.addInterval(IntervalFactory.getIntervalByName("M6"));
                mode.addInterval(IntervalFactory.getIntervalByName("M7"));
            }
            else if (name == "Mixolydian")
            {
                mode.addInterval(IntervalFactory.getIntervalByName("R"));
                mode.addInterval(IntervalFactory.getIntervalByName("M2"));
                mode.addInterval(IntervalFactory.getIntervalByName("M3"));
                mode.addInterval(IntervalFactory.getIntervalByName("P4"));
                mode.addInterval(IntervalFactory.getIntervalByName("P5"));
                mode.addInterval(IntervalFactory.getIntervalByName("M6"));
                mode.addInterval(IntervalFactory.getIntervalByName("m7"));
            }
            else if (name == "Dorian")
            {
                mode.addInterval(IntervalFactory.getIntervalByName("R"));
                mode.addInterval(IntervalFactory.getIntervalByName("M2"));
                mode.addInterval(IntervalFactory.getIntervalByName("m3"));
                mode.addInterval(IntervalFactory.getIntervalByName("P4"));
                mode.addInterval(IntervalFactory.getIntervalByName("P5"));
                mode.addInterval(IntervalFactory.getIntervalByName("M6"));
                mode.addInterval(IntervalFactory.getIntervalByName("m7"));
            }
            else if (name == "Aeolian")
            {
                mode.addInterval(IntervalFactory.getIntervalByName("R"));
                mode.addInterval(IntervalFactory.getIntervalByName("M2"));
                mode.addInterval(IntervalFactory.getIntervalByName("m3"));
                mode.addInterval(IntervalFactory.getIntervalByName("P4"));
                mode.addInterval(IntervalFactory.getIntervalByName("P5"));
                mode.addInterval(IntervalFactory.getIntervalByName("m6"));
                mode.addInterval(IntervalFactory.getIntervalByName("m7"));
            }
            else if (name == "Phrygian")
            {
                mode.addInterval(IntervalFactory.getIntervalByName("R"));
                mode.addInterval(IntervalFactory.getIntervalByName("m2"));
                mode.addInterval(IntervalFactory.getIntervalByName("m3"));
                mode.addInterval(IntervalFactory.getIntervalByName("P4"));
                mode.addInterval(IntervalFactory.getIntervalByName("P5"));
                mode.addInterval(IntervalFactory.getIntervalByName("m6"));
                mode.addInterval(IntervalFactory.getIntervalByName("m7"));
            }
            else if (name == "Locrian")
            {
                mode.addInterval(IntervalFactory.getIntervalByName("R"));
                mode.addInterval(IntervalFactory.getIntervalByName("m2"));
                mode.addInterval(IntervalFactory.getIntervalByName("m3"));
                mode.addInterval(IntervalFactory.getIntervalByName("P4"));
                mode.addInterval(IntervalFactory.getIntervalByName("dim5"));
                mode.addInterval(IntervalFactory.getIntervalByName("m6"));
                mode.addInterval(IntervalFactory.getIntervalByName("m7"));
            }
            else { throw new System.ArgumentException("Parameter must have a valid name", "Mode: " + name); }
            return mode;
        }
    }
}
