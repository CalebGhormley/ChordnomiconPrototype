using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    [TestFixture]
    class ChordFactoryTest
    {
        private Chord _chord = new Chord();
        
        [Test]
        public void ChordFactoryTest_getChrodByName()
        {
            _chord = ChordFactory.getChordByName("A");
            Assert.AreEqual("A, C#, E", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Am");
            Assert.AreEqual("A, C, E", _chord.getNotes());
            _chord = ChordFactory.getChordByName("A5");
            Assert.AreEqual("A, E", _chord.getNotes());
            _chord = ChordFactory.getChordByName("A6");
            Assert.AreEqual("A, C#, E, F#", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Ab");
            Assert.AreEqual("Ab, C, Eb", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Abm");
            Assert.AreEqual("Ab, B, Eb", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Ab5");
            Assert.AreEqual("Ab, Eb", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Ab6");
            Assert.AreEqual("Ab, C, Eb, F", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Csus");
            Assert.AreEqual("C, F, G", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Csus2");
            Assert.AreEqual("C, D, G", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C7sus");
            Assert.AreEqual("C, F, G, Bb", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Cdim");
            Assert.AreEqual("C, Eb, Gb", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Cmaj7");
            Assert.AreEqual("C, E, G, B", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Cmaj9");
            Assert.AreEqual("C, E, G, B, D", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Cmaj7(b5)");
            Assert.AreEqual("C, E, Gb, B", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Cm(maj7)");
            Assert.AreEqual("C, Eb, G, B", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Cm9(maj7)");
            Assert.AreEqual("C, Eb, G, B, D", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C7");
            Assert.AreEqual("C, E, G, Bb", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Cm7");
            Assert.AreEqual("C, Eb, G, Bb", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C7(b9)");
            Assert.AreEqual("C, E, G, Bb, Db", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C7(#9)");
            Assert.AreEqual("C, E, G, Bb, Eb", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C7+");
            Assert.AreEqual("C, E, Ab, Bb", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C7+(b9)");
            Assert.AreEqual("C, E, Ab, Bb, Db", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C9+");
            Assert.AreEqual("C, E, Ab, Bb, D", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C9(#11)");
            Assert.AreEqual("C, E, G, Bb, D, Gb", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C11");                    
            Assert.AreEqual("C, E, G, Bb, D, F", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Cm11");
            Assert.AreEqual("C, Eb, G, Bb, D, F", _chord.getNotes());
            _chord = ChordFactory.getChordByName("CM11");
            Assert.AreEqual("C, E, G, B, D, F", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C13");
            Assert.AreEqual("C, E, G, Bb, D, A", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C13(b9)");
            Assert.AreEqual("C, E, G, Bb, Db, A", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C13(#9)");
            Assert.AreEqual("C, E, G, Bb, Eb, A", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C13(b9b5)");
            Assert.AreEqual("C, E, Gb, Bb, Db, A", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C9");
            Assert.AreEqual("C, E, G, Bb, D", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C9(b5)");
            Assert.AreEqual("C, E, Gb, Bb, D", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Cm9");
            Assert.AreEqual("C, Eb, G, Bb, D", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C6");
            Assert.AreEqual("C, E, G, A", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Cm6");
            Assert.AreEqual("C, Eb, G, A", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C6/9");
            Assert.AreEqual("C, E, G, A, D", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Cm6/9");
            Assert.AreEqual("C, Eb, G, A, D", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C7");
            Assert.AreEqual("C, E, G, Bb", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Cm7");
            Assert.AreEqual("C, Eb, G, Bb", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C7(b5)");
            Assert.AreEqual("C, E, Gb, Bb", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Cm7(b5)");
            Assert.AreEqual("C, Eb, Gb, Bb", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C(b5)");
            Assert.AreEqual("C, E, Gb", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Bm7(b5)");
            Assert.AreEqual("B, D, F, A", _chord.getNotes());
            _chord = ChordFactory.getChordByName("Caug");
            Assert.AreEqual("C, E, Ab", _chord.getNotes());
            _chord = ChordFactory.getChordByName("C(add9)");
            Assert.AreEqual("C, E, G, D", _chord.getNotes());
            Assert.AreEqual("C(add9)", _chord.getName());
            //_chord = ChordFactory.getChordByName("C/G");
            //Assert.AreEqual("G, C, E, G", _chord.getNotes());
        }

        [Test]
        public void ChordFactoryTest_getChordRecomendationsTriads()
        {
            Note key = NoteFactory.getNoteByName("C");
            Mode mode = ModeFactory.getModeByName("Ionian");
            List<Chord> recomendations = ChordFactory.getChordRecomendationsTriads(key, mode);
            Assert.AreEqual("C", recomendations.ElementAt(0).getName());
            Assert.AreEqual("Dm", recomendations.ElementAt(1).getName());
            Assert.AreEqual("Em", recomendations.ElementAt(2).getName());
            Assert.AreEqual("F", recomendations.ElementAt(3).getName());
            Assert.AreEqual("G", recomendations.ElementAt(4).getName());
            Assert.AreEqual("Am", recomendations.ElementAt(5).getName());
            Assert.AreEqual("Bdim", recomendations.ElementAt(6).getName());

            key = NoteFactory.getNoteByName("F");
            mode = ModeFactory.getModeByName("Lydian");
            recomendations = ChordFactory.getChordRecomendationsTriads(key, mode);
            Assert.AreEqual("F", recomendations.ElementAt(0).getName());
            Assert.AreEqual("G", recomendations.ElementAt(1).getName());
            Assert.AreEqual("Am", recomendations.ElementAt(2).getName());
            Assert.AreEqual("Bdim", recomendations.ElementAt(3).getName());
            Assert.AreEqual("C", recomendations.ElementAt(4).getName());
            Assert.AreEqual("Dm", recomendations.ElementAt(5).getName());
            Assert.AreEqual("Em", recomendations.ElementAt(6).getName());

            key = NoteFactory.getNoteByName("G");
            mode = ModeFactory.getModeByName("Mixolydian");
            recomendations = ChordFactory.getChordRecomendationsTriads(key, mode);
            Assert.AreEqual("G", recomendations.ElementAt(0).getName());
            Assert.AreEqual("Am", recomendations.ElementAt(1).getName());
            Assert.AreEqual("Bdim", recomendations.ElementAt(2).getName());
            Assert.AreEqual("C", recomendations.ElementAt(3).getName());
            Assert.AreEqual("Dm", recomendations.ElementAt(4).getName());
            Assert.AreEqual("Em", recomendations.ElementAt(5).getName());
            Assert.AreEqual("F", recomendations.ElementAt(6).getName());

            key = NoteFactory.getNoteByName("D");
            mode = ModeFactory.getModeByName("Dorian");
            recomendations = ChordFactory.getChordRecomendationsTriads(key, mode);
            Assert.AreEqual("Dm", recomendations.ElementAt(0).getName());
            Assert.AreEqual("Em", recomendations.ElementAt(1).getName());
            Assert.AreEqual("F", recomendations.ElementAt(2).getName());
            Assert.AreEqual("G", recomendations.ElementAt(3).getName());
            Assert.AreEqual("Am", recomendations.ElementAt(4).getName());
            Assert.AreEqual("Bdim", recomendations.ElementAt(5).getName());
            Assert.AreEqual("C", recomendations.ElementAt(6).getName());

            key = NoteFactory.getNoteByName("A");
            mode = ModeFactory.getModeByName("Aeolian");
            recomendations = ChordFactory.getChordRecomendationsTriads(key, mode);
            Assert.AreEqual("Am", recomendations.ElementAt(0).getName());
            Assert.AreEqual("Bdim", recomendations.ElementAt(1).getName());
            Assert.AreEqual("C", recomendations.ElementAt(2).getName());
            Assert.AreEqual("Dm", recomendations.ElementAt(3).getName());
            Assert.AreEqual("Em", recomendations.ElementAt(4).getName());
            Assert.AreEqual("F", recomendations.ElementAt(5).getName());
            Assert.AreEqual("G", recomendations.ElementAt(6).getName());

            key = NoteFactory.getNoteByName("E");
            mode = ModeFactory.getModeByName("Phrygian");
            recomendations = ChordFactory.getChordRecomendationsTriads(key, mode);
            Assert.AreEqual("Em", recomendations.ElementAt(0).getName());
            Assert.AreEqual("F", recomendations.ElementAt(1).getName());
            Assert.AreEqual("G", recomendations.ElementAt(2).getName());
            Assert.AreEqual("Am", recomendations.ElementAt(3).getName());
            Assert.AreEqual("Bdim", recomendations.ElementAt(4).getName());
            Assert.AreEqual("C", recomendations.ElementAt(5).getName());
            Assert.AreEqual("Dm", recomendations.ElementAt(6).getName());

            key = NoteFactory.getNoteByName("B");
            mode = ModeFactory.getModeByName("Locrian");
            recomendations = ChordFactory.getChordRecomendationsTriads(key, mode);
            Assert.AreEqual("Bdim", recomendations.ElementAt(0).getName());
            Assert.AreEqual("C", recomendations.ElementAt(1).getName());
            Assert.AreEqual("Dm", recomendations.ElementAt(2).getName());
            Assert.AreEqual("Em", recomendations.ElementAt(3).getName());
            Assert.AreEqual("F", recomendations.ElementAt(4).getName());
            Assert.AreEqual("G", recomendations.ElementAt(5).getName());
            Assert.AreEqual("Am", recomendations.ElementAt(6).getName());
        }

        [Test]
        public void ChordFactoryTest_getChordRecomendationsByLast()
        {
            Note key = NoteFactory.getNoteByName("C");
            Mode mode = ModeFactory.getModeByName("Ionian");
            Chord chord = ChordFactory.getChordByName("C");
            List<Chord> recomendations = ChordFactory.getChordRecomendationsByLast(key, chord, mode);
            Assert.AreEqual("G", recomendations.ElementAt(0).getName());
        }

        [Test]
        public void ChordFactoryTest_getChordRecomendationsByDegree()
        {
            Note key = NoteFactory.getNoteByName("C");
            Note degree = NoteFactory.getNoteByName("G");
            Mode mode = ModeFactory.getModeByName("Ionian");
            List<Chord> recomendations = ChordFactory.getChordRecomendationsByTonic(key, degree, mode);
            Assert.IsTrue(recomendations.Count() > 1);
        }
    }
}
