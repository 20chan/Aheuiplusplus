using Aheui__;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aheui__Tests
{
    [TestClass]
    public class AheuiTest_Standard
    {
        [TestCategory("standard")]
        [TestMethod]
        public void Double()
        {
            Assert.AreEqual("3596", IntAheui.Execute(@"뷷우희어밍우여
아아아아아아아반받망희
먕오뱞오뱗오뵬"));
        }

        [TestCategory("standard")]
        [TestMethod]
        public void Bieup()
        {
            Assert.AreEqual("4434324453224689979975544481753", IntAheui.Execute(@"박반받발밤밥밧밪밫밬밭붚
뭉멍멍멍멍멍멍멍멍멍멍멍
밖밗밙밚밝밞밟밠밡밢밣밦붔
뭉멍멍멍멍멍멍멍멍멍멍멍멍
밯망방망희", "밯", "3"));
        }
    }
}
