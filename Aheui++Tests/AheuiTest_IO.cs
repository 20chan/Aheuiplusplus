using Aheui__;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aheui__Tests
{
    [TestClass]
    public class AheuiTest_IO
    {
        [TestCategory("io")]
        [TestMethod()]
        public void BasicInputTest()
        {
            Assert.AreEqual(IntAheui.Execute("밯망희", "밯"), "48175");
        }
    }
}
