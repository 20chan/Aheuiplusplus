using System;
using System.Text;
using Aheui__;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aheui__Tests
{
    [TestClass]
    public class AheuiTest_Advanced
    {
        [TestCategory("advanced")]
        [TestMethod]
        public void HelloWorld1()
        {
            Assert.AreEqual("Hello, world!\n", IntAheui.Execute( @"밤밣따빠밣밟따뿌
빠맣파빨받밤뚜뭏
돋밬탕빠맣붏두붇
볻뫃박발뚷투뭏붖
뫃도뫃희멓뭏뭏붘
뫃봌토범더벌뿌뚜
뽑뽀멓멓더벓뻐뚠
뽀덩벐멓뻐덕더벅"));
        }

        [TestCategory("advanced")]
        [TestMethod]
        public void HelloWorld2()
        {
            Assert.AreEqual("안녕하세요?\n", IntAheui.Execute(@"어듀벊벖버범벅벖떠벋벍떠벑번뻐버떠뻐벚벌버더벊벖떠벛벜버버
　ㅇ　　ㅏㄴㄴㅕㅇ　　ㅎ　　ㅏ　ㅅ　　ㅔ　ㅇ　　ㅛ　　　\0
　뿌멓더떠떠떠떠더벋떠벌뻐뻐뻐
붉차밠밪따따다밠밨따따다　박봃
받빠따따맣반발따맣아희～"));
        }

        [TestCategory("advanced")]
        [TestMethod]
        public void Fibonacci()
        {
            Assert.AreEqual("23581321345589144233", IntAheui.Execute(@"반반나빠빠쌈다빠망빠쌈삼파싸사빠발발밖따따쟈하처우
ㅇㅇㅇㅇㅇㅇ오어어어어어어어어어어어어어어어어어어"));
        }

        [TestCategory("advanced")]
        [TestMethod]
        public void Int32()
        {
            Assert.AreEqual("8589934592", BigIntAheui.Execute(@"삭반사밣밣따뿌
분ㅇㅇ희멍석차
타삭반ㅇ따사뽀"));
        }

        [TestCategory("advanced")]
        [TestMethod]
        public void Int64()
        {
            Assert.AreEqual("36893488147419103232", BigIntAheui.Execute(@"삭반사밣밣따빠다뿌
분ㅇㅇㅇㅇ희멍석차
타삭반ㅇㅇㅇ따사뽀"));
        }

        [TestCategory("advanced")]
        [TestMethod]
        public void Ha_ut()
        {
            Assert.AreEqual("하읏... ", 
                IntAheui.Execute(@"삶은밥과야근밥샤주세양♡밥사밥사밥사밥사밥사땅땅땅빵☆따밦내발따밦다빵맣밥밥밥내놔밥줘밥밥밥밗땅땅땅박밝땅땅딻타밟타맣밦밣따박타맣밦밣따박타맣밦밣따박타맣박빵빵빵빵따따따따맣희"));
        }

        [TestCategory("advanced")]
        [TestMethod]
        public void Pokryong()
        {
            Assert.AreEqual("10", IntAheui.Execute(@"육체는　단명하고
근성은　영원한것
방산반밧나뿌서어뎐근성
대류…분선창사반나산분
폭룡이탄뭉폭룡의뇨시볏
최고다아하＃김끼룩제작", "1024"));
        }

        [TestCategory("advanced")]
        [TestMethod]
        public void Ddeok()
        {
            Assert.AreEqual("1", IntAheui.Execute(@"발냄새엔 망개떡 밤삶으면 홍두깨떡"));
        }

        [TestCategory("advanced")]
        [TestMethod]
        public void Hammer()
        {
            Assert.AreEqual("0", IntAheui.Execute(@"바쁜 망치에 흘린 못 없다"));
        }

        [TestCategory("advanced")]
        [TestMethod]
        public void Sijo_div()
        {
            Assert.AreEqual("20", IntAheui.Execute(@"첩첩산 방방곡곡 굽굽이 찾아들어
겹겹골 심심봉봉 둘둘러 돌아들어
아희야 하늘나리가 멍멍하게 피누나", "249", "12"));
        }

        [TestCategory("advanced")]
        [TestMethod]
        public void BBIBBBBYABB()
        {
            Assert.AreEqual("15", IntAheui.Execute(@"발받악에 땀 망희 났어"));
        }
    }
}
