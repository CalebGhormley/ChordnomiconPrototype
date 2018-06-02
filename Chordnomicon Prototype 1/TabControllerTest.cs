using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chordnomicon_Prototype_1
{
    [TestFixture]
    class TabControllerTest
    {
        private Guitar guitar = new Guitar();
        [Test]
        public void TabController_checkPitchRangeTest()
        {
            Assert.IsTrue(TabController.checkPitchRange(1, NoteFactory.getNoteByName("C"), guitar));
            Assert.IsFalse(TabController.checkPitchRange(0, NoteFactory.getNoteByName("C"), guitar));
            Assert.IsTrue(TabController.checkPitchRange(9, NoteFactory.getNoteByName("C"), guitar));
            Assert.IsFalse(TabController.checkPitchRange(10, NoteFactory.getNoteByName("C"), guitar));
        }
    }
}
