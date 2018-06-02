using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    [TestFixture]
    class ProgressionTest
    {
        private Progression _progression;
        
        [Test]
        public void ProgressionTest_getChordNames ()
        {
            _progression = new Progression();
            _progression.addChord(ChordFactory.getChordByName("C"));
            Assert.AreEqual("C", _progression.getChordNames());
            _progression.addChord(ChordFactory.getChordByName("Am7"));
            Assert.AreEqual("C, Am7", _progression.getChordNames());
            _progression.addChord(ChordFactory.getChordByName("G#(add9)"));
            Assert.AreEqual("C, Am7, G#(add9)", _progression.getChordNames());
        }
        [Test]
        public void ProgressionTest_getChord()
        {
            _progression = new Progression();
            _progression.addChord(ChordFactory.getChordByName("C"));
            _progression.addChord(ChordFactory.getChordByName("Am7"));
            _progression.addChord(ChordFactory.getChordByName("G#(add9)"));
            Assert.AreEqual("A, C, E, G", _progression.getChord(1).getNotes());
        }
        [Test]
        public void ProgressionTest_replaceChord()
        {
            _progression = new Progression();
            _progression.addChord(ChordFactory.getChordByName("C"));
            _progression.addChord(ChordFactory.getChordByName("Am7"));
            _progression.addChord(ChordFactory.getChordByName("G#(add9)"));
            _progression.replaceChord(0, ChordFactory.getChordByName("Db9"));
            Assert.AreEqual("Db9, Am7, G#(add9)", _progression.getChordNames());
        }
        [Test]
        public void ProgressionTest_swapChords()
        {
            _progression = new Progression();
            _progression.addChord(ChordFactory.getChordByName("C"));
            _progression.addChord(ChordFactory.getChordByName("Am7"));
            _progression.addChord(ChordFactory.getChordByName("G#(add9)"));
            _progression.swapChords(0, 1);
            Assert.AreEqual("Am7, C, G#(add9)", _progression.getChordNames());
        }
        [Test]
        public void ProgressionTest_removeChord()
        {
            _progression = new Progression();
            _progression.addChord(ChordFactory.getChordByName("C"));
            _progression.addChord(ChordFactory.getChordByName("Am7"));
            _progression.addChord(ChordFactory.getChordByName("G#(add9)"));
            _progression.removeChord(2);
            Assert.AreEqual("C, Am7", _progression.getChordNames());
        }
        [Test]
        public void ProgressionTest_changeTuning()
        {
            _progression = new Progression();
            _progression.addChord(ChordFactory.getChordByName("E"));
            Assert.AreEqual("0", _progression.getTabNumber(1, 6));
            Assert.AreEqual("2", _progression.getTabNumber(1, 5));
            Assert.AreEqual("2", _progression.getTabNumber(1, 4));
            Assert.AreEqual("1", _progression.getTabNumber(1, 3));
            Assert.AreEqual("0", _progression.getTabNumber(1, 2));
            Assert.AreEqual("0", _progression.getTabNumber(1, 1));
            _progression.changeTuning(NoteFactory.getNoteByName("E"), NoteFactory.getNoteByName("A"), NoteFactory.getNoteByName("D"),
                NoteFactory.getNoteByName("G#"), NoteFactory.getNoteByName("B"), NoteFactory.getNoteByName("E"));
            Assert.AreEqual("E, A, D, Ab, B, E", _progression.getTuning());
            Assert.AreEqual("0", _progression.getTabNumber(1, 6));
            Assert.AreEqual("2", _progression.getTabNumber(1, 5));
            Assert.AreEqual("2", _progression.getTabNumber(1, 4));
            Assert.AreEqual("0", _progression.getTabNumber(1, 3));
            Assert.AreEqual("0", _progression.getTabNumber(1, 2));
            Assert.AreEqual("0", _progression.getTabNumber(1, 1));
        }
        [Test]
        public void ProgressionTest_getTabNumber()
        {
            _progression = new Progression();
            _progression.addChord(ChordFactory.getChordByName("C"));
            Assert.AreEqual("X", _progression.getTabNumber(1, 6));
            Assert.AreEqual("3", _progression.getTabNumber(1, 5));
            Assert.AreEqual("2", _progression.getTabNumber(1, 4));
            Assert.AreEqual("0", _progression.getTabNumber(1, 3));
            Assert.AreEqual("1", _progression.getTabNumber(1, 2));
            Assert.AreEqual("0", _progression.getTabNumber(1, 1));
        }
        [Test]
        public void ProgressionTest_changeTabPitch()
        {
            _progression = new Progression();
            _progression.addChord(ChordFactory.getChordByName("C"));
            Assert.AreEqual("X", _progression.getTabNumber(1, 6));
            Assert.AreEqual("3", _progression.getTabNumber(1, 5));
            Assert.AreEqual("2", _progression.getTabNumber(1, 4));
            Assert.AreEqual("0", _progression.getTabNumber(1, 3));
            Assert.AreEqual("1", _progression.getTabNumber(1, 2));
            Assert.AreEqual("0", _progression.getTabNumber(1, 1));
            _progression.changeTabPitch(1, 2);
            Assert.AreEqual("X", _progression.getTabNumber(1, 6));
            Assert.AreEqual("3", _progression.getTabNumber(1, 5));
            Assert.AreEqual("5", _progression.getTabNumber(1, 4));
            Assert.AreEqual("5", _progression.getTabNumber(1, 3));
            Assert.AreEqual("5", _progression.getTabNumber(1, 2));
            Assert.AreEqual("3", _progression.getTabNumber(1, 1));
        }
    }
}
