using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    class IntervalFactory
    {
        private IntervalFactory() { }
        public static Interval getIntervalByName(string name)
        {
            Interval interval;
            if (name == "R") { interval = new Interval(0, name); }
            else if (name == "m2") { interval = new Interval(1, name); }
            else if (name == "M2") { interval = new Interval(2, name); }
            else if (name == "m3") { interval = new Interval(3, name); }
            else if (name == "M3") { interval = new Interval(4, name); }
            else if (name == "P4") { interval = new Interval(5, name); }
            else if (name == "aug4") { interval = new Interval(6, name); }
            else if (name == "dim5") { interval = new Interval(6, name); }
            else if (name == "P5") { interval = new Interval(7, name); }
            else if (name == "m6") { interval = new Interval(8, name); }
            else if (name == "M6") { interval = new Interval(9, name); }
            else if (name == "m7") { interval = new Interval(10, name); }
            else if (name == "M7") { interval = new Interval(11, name); }
            else { throw new System.ArgumentException("Argument must have a valid name", "Interval: " + name); }
            return interval;
        }
        public static Interval getIntervalByValue(int value)
        {
            //Needs work, should be able to name dim and aug intervals
            Interval interval;
            if (value == 0 || value == 12) { interval = new Interval(value, "R"); }
            else if (value == 1) { interval = new Interval(value, "m2"); }
            else if (value == 2) { interval = new Interval(value, "M2"); }
            else if (value == 3) { interval = new Interval(value, "m3"); }
            else if (value == 4) { interval = new Interval(value, "M3"); }
            else if (value == 5) { interval = new Interval(value, "P4"); }
            else if (value == 6) { interval = new Interval(value, "dim5"); }
            else if (value == 7) { interval = new Interval(value, "P5"); }
            else if (value == 8) { interval = new Interval(value, "m6"); }
            else if (value == 9) { interval = new Interval(value, "M6"); }
            else if (value == 10) { interval = new Interval(value, "m7"); }
            else if (value == 11) { interval = new Interval(value, "M7"); }
            else { throw new System.ArgumentException("Argument must have a valid value", "Interval: " + value); }
            return interval;
        }
    }
}
