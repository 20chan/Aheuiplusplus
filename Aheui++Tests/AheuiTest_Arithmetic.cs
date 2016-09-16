using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aheui__;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aheui__Tests
{
    [TestClass()]
    public class AheuiTests
    {
        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Sum1()
        {
            Assert.AreEqual(IntAheui.Execute("박받다망희"), "5");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Sum2()
        {
            Assert.AreEqual(IntAheui.Execute("발밥다밦다망희"), "15");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Sum3()
        {
            Assert.AreEqual(IntAheui.Execute("밦밗밣다다망희"), "18");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Minus1()
        {
            Assert.AreEqual(IntAheui.Execute("받박타망희"), "1");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Minus2()
        {
            Assert.AreEqual(IntAheui.Execute("박받타망희"), "-1");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Minus3()
        {
            Assert.AreEqual(IntAheui.Execute("박박타망희"), "0");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Multi1()
        {
            Assert.AreEqual(IntAheui.Execute("박받따망희"), "6");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Multi2()
        {
            Assert.AreEqual(IntAheui.Execute("박발박발따따따망희"), "100");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Div1()
        {
            Assert.AreEqual(IntAheui.Execute("박발따박나망희"), "5");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Div2()
        {
            Assert.AreEqual(IntAheui.Execute("받박나망희"), "1");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Div3()
        {
            Assert.AreEqual(IntAheui.Execute("반받나망희"), "0");
        }
    }
}