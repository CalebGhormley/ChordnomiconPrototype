using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    [TestFixture]
    class ModeTest
    {
        [Test]
        public void Mode_containsIntervalTest()
        {
            Mode mode = ModeFactory.getModeByName("Ionian");
            Assert.IsTrue(mode.containsInterval("R"));
            Assert.IsTrue(mode.containsInterval("M2"));
            Assert.IsTrue(mode.containsInterval("M3"));
            Assert.IsTrue(mode.containsInterval("P4"));
            Assert.IsTrue(mode.containsInterval("P5"));
            Assert.IsTrue(mode.containsInterval("M6"));
            Assert.IsTrue(mode.containsInterval("M7"));
            Assert.IsFalse(mode.containsInterval("m7"));
        }
        [Test]
        public void Mode_containsNoteTest()
        {
            Mode mode = ModeFactory.getModeByName("Ionian");
            Note key = NoteFactory.getNoteByName("C");
            Assert.IsTrue(mode.containsNote(NoteFactory.getNoteByName("C"), key));
            Assert.IsTrue(mode.containsNote(NoteFactory.getNoteByName("D"), key));
            Assert.IsTrue(mode.containsNote(NoteFactory.getNoteByName("E"), key));
            Assert.IsTrue(mode.containsNote(NoteFactory.getNoteByName("F"), key));
            Assert.IsTrue(mode.containsNote(NoteFactory.getNoteByName("G"), key));
            Assert.IsTrue(mode.containsNote(NoteFactory.getNoteByName("A"), key));
            Assert.IsTrue(mode.containsNote(NoteFactory.getNoteByName("B"), key));
            Assert.IsFalse(mode.containsNote(NoteFactory.getNoteByName("F#"), key));
        }
    }
}
