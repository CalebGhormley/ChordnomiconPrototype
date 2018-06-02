using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    [TestFixture]
    class TabChordFactoryTest
    {
        private TabChord tabChord = new TabChord();
        private Guitar guitar = new Guitar();

        [Test]
        public void TabChordFactory_getNoteByChord()
        {
            tabChord = TabChordFactory.getTabByChord(ChordFactory.getChordByName("E"), 1, guitar);
            Assert.AreEqual("0", tabChord.getFretNumber(6));
            Assert.AreEqual("2", tabChord.getFretNumber(5));
            Assert.AreEqual("2", tabChord.getFretNumber(4));
            Assert.AreEqual("1", tabChord.getFretNumber(3));
            Assert.AreEqual("0", tabChord.getFretNumber(2));
            Assert.AreEqual("0", tabChord.getFretNumber(1));
            tabChord = TabChordFactory.getTabByChord(ChordFactory.getChordByName("Am"), 1, guitar);
            Assert.AreEqual("X", tabChord.getFretNumber(6));
            Assert.AreEqual("0", tabChord.getFretNumber(5));
            Assert.AreEqual("2", tabChord.getFretNumber(4));
            Assert.AreEqual("2", tabChord.getFretNumber(3));
            Assert.AreEqual("1", tabChord.getFretNumber(2));
            Assert.AreEqual("0", tabChord.getFretNumber(1));
            tabChord = TabChordFactory.getTabByChord(ChordFactory.getChordByName("C"), 1, guitar);
            Assert.AreEqual("X", tabChord.getFretNumber(6));
            Assert.AreEqual("3", tabChord.getFretNumber(5));
            Assert.AreEqual("2", tabChord.getFretNumber(4));
            Assert.AreEqual("0", tabChord.getFretNumber(3));
            Assert.AreEqual("1", tabChord.getFretNumber(2));
            Assert.AreEqual("0", tabChord.getFretNumber(1));
            tabChord = TabChordFactory.getTabByChord(ChordFactory.getChordByName("G"), 1, guitar);
            Assert.AreEqual("3", tabChord.getFretNumber(6));
            Assert.AreEqual("2", tabChord.getFretNumber(5));
            Assert.AreEqual("0", tabChord.getFretNumber(4));
            Assert.AreEqual("0", tabChord.getFretNumber(3));
            Assert.AreEqual("0", tabChord.getFretNumber(2));
            Assert.AreEqual("3", tabChord.getFretNumber(1));
            tabChord = TabChordFactory.getTabByChord(ChordFactory.getChordByName("G"), 2, guitar);
            Assert.AreEqual("3", tabChord.getFretNumber(6));
            Assert.AreEqual("5", tabChord.getFretNumber(5));
            Assert.AreEqual("5", tabChord.getFretNumber(4));
            Assert.AreEqual("4", tabChord.getFretNumber(3));
            Assert.AreEqual("3", tabChord.getFretNumber(2));
            Assert.AreEqual("3", tabChord.getFretNumber(1));
            tabChord = TabChordFactory.getTabByChord(ChordFactory.getChordByName("E"), 2, guitar);
            Assert.AreEqual("X", tabChord.getFretNumber(6));
            Assert.AreEqual("X", tabChord.getFretNumber(5));
            Assert.AreEqual("2", tabChord.getFretNumber(4));
            Assert.AreEqual("4", tabChord.getFretNumber(3));
            Assert.AreEqual("5", tabChord.getFretNumber(2));
            Assert.AreEqual("4", tabChord.getFretNumber(1));
            tabChord = TabChordFactory.getTabByChord(ChordFactory.getChordByName("E"), 3, guitar);
            Assert.AreEqual("X", tabChord.getFretNumber(6));
            Assert.AreEqual("7", tabChord.getFretNumber(5));
            Assert.AreEqual("6", tabChord.getFretNumber(4));
            Assert.AreEqual("4", tabChord.getFretNumber(3));
            Assert.AreEqual("5", tabChord.getFretNumber(2));
            Assert.AreEqual("4", tabChord.getFretNumber(1));
            tabChord = TabChordFactory.getTabByChord(ChordFactory.getChordByName("C"), 1, guitar);
            Assert.AreEqual("X", tabChord.getFretNumber(6));
            Assert.AreEqual("3", tabChord.getFretNumber(5));
            Assert.AreEqual("2", tabChord.getFretNumber(4));
            Assert.AreEqual("0", tabChord.getFretNumber(3));
            Assert.AreEqual("1", tabChord.getFretNumber(2));
            Assert.AreEqual("0", tabChord.getFretNumber(1));
            tabChord = TabChordFactory.getTabByChord(ChordFactory.getChordByName("Dmaj9"), 1, guitar);
            Assert.AreEqual("X", tabChord.getFretNumber(6));
            Assert.AreEqual("X", tabChord.getFretNumber(5));
            Assert.AreEqual("0", tabChord.getFretNumber(4));
            Assert.AreEqual("2", tabChord.getFretNumber(3));
            Assert.AreEqual("2", tabChord.getFretNumber(2));
            Assert.AreEqual("0", tabChord.getFretNumber(1));
            tabChord = TabChordFactory.getTabByChord(ChordFactory.getChordByName("F7+"), 1, guitar);
            Assert.AreEqual("1", tabChord.getFretNumber(6));
            Assert.AreEqual("4", tabChord.getFretNumber(5));
            Assert.AreEqual("1", tabChord.getFretNumber(4));
            Assert.AreEqual("2", tabChord.getFretNumber(3));
            Assert.AreEqual("2", tabChord.getFretNumber(2));
            Assert.AreEqual("1", tabChord.getFretNumber(1));
            tabChord = TabChordFactory.getTabByChord(ChordFactory.getChordByName("Fm7(b5)"), 3, guitar);
            Assert.AreEqual("X", tabChord.getFretNumber(6));
            Assert.AreEqual("X", tabChord.getFretNumber(5));
            Assert.AreEqual("3", tabChord.getFretNumber(4));
            Assert.AreEqual("4", tabChord.getFretNumber(3));
            Assert.AreEqual("4", tabChord.getFretNumber(2));
            Assert.AreEqual("4", tabChord.getFretNumber(1));
        }

    }
}
