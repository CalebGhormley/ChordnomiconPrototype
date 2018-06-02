using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    [TestFixture]
    class ChordControllerTest
    {
        private string chordName;

        [Test]
        public void ChordController_checkChordNameTest()
        {
            chordName = "A";
            Assert.IsTrue(ChordController.checkChordName(chordName));
            chordName = chordName + "#";
            Assert.IsTrue(ChordController.checkChordName(chordName));
            chordName = chordName + "m";
            Assert.IsTrue(ChordController.checkChordName(chordName));
            chordName = "B";
            Assert.IsTrue(ChordController.checkChordName(chordName));
            chordName = chordName + "b";
            Assert.IsTrue(ChordController.checkChordName(chordName));
            chordName = chordName + "7";
            Assert.IsTrue(ChordController.checkChordName(chordName));
            chordName = "C";
            Assert.IsTrue(ChordController.checkChordName(chordName));
            chordName = "D";
            Assert.IsTrue(ChordController.checkChordName(chordName));
            chordName = "E";
            Assert.IsTrue(ChordController.checkChordName(chordName));
            chordName = "F";
            Assert.IsTrue(ChordController.checkChordName(chordName));
            chordName = "G";
            Assert.IsTrue(ChordController.checkChordName(chordName));
        }
    }
}
