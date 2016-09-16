using Aheui__;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aheui__Tests
{
    [TestClass]
    public class AheuiTest_Standard
    {
        [TestCategory("standard")]
        [TestMethod]
        public void Loop()
        {
            Assert.AreEqual(IntAheui.Execute(@"밦밦따빠뚜
뿌뚜뻐뚜뻐
따ㅇㅇㅇ우
ㅇㅇ아ㅇ분
ㅇㅇ초뻐터
ㅇㅇ망희"), "0");
        }

        [TestCategory("standard")]
        [TestMethod]
        public void Bieup()
        {
            Assert.AreEqual(IntAheui.Execute(@"박반받발밤밥밧밪밫밬밭붚
뭉멍멍멍멍멍멍멍멍멍멍멍
밖밗밙밚밝밞밟밠밡밢밣밦붔
뭉멍멍멍멍멍멍멍멍멍멍멍멍
밯망방망희", "밯", "3"), "4434324453224689979975544481753");
        }
    }
}
