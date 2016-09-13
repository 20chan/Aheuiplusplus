using Microsoft.VisualStudio.TestTools.UnitTesting;
using Aheui__;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aheui__.Tests
{
    [TestClass()]
    public class AheuiTests
    {
        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Sum1()
        {
            string result = "";
            Aheui aheui = new Aheui("박받다망희");
            aheui.OutputReleased += (output) => result = output;
            aheui.RunAll();
            Assert.AreEqual(result, "5");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Sum2()
        {
            string result = "";
            Aheui aheui = new Aheui("발밥다밦다망희");
            aheui.OutputReleased += (output) => result = output;
            aheui.RunAll();
            Assert.AreEqual(result, "15");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Sum3()
        {
            string result = "";
            Aheui aheui = new Aheui("밦밗밣다다망희");
            aheui.OutputReleased += (output) => result = output;
            aheui.RunAll();
            Assert.AreEqual(result, "18");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Minus1()
        {
            string result = "";
            Aheui aheui = new Aheui("받박타망희");
            aheui.OutputReleased += (output) => result = output;
            aheui.RunAll();
            Assert.AreEqual(result, "1");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Minus2()
        {
            string result = "";
            Aheui aheui = new Aheui("박받타망희");
            aheui.OutputReleased += (output) => result = output;
            aheui.RunAll();
            Assert.AreEqual(result, "-1");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Minus3()
        {
            string result = "";
            Aheui aheui = new Aheui("박박타망희");
            aheui.OutputReleased += (output) => result = output;
            aheui.RunAll();
            Assert.AreEqual(result, "0");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Multi1()
        {
            string result = "";
            Aheui aheui = new Aheui("박받따망희");
            aheui.OutputReleased += (output) => result = output;
            aheui.RunAll();
            Assert.AreEqual(result, "6");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Multi2()
        {
            string result = "";
            Aheui aheui = new Aheui("박발박발따따따망희");
            aheui.OutputReleased += (output) => result = output;
            aheui.RunAll();
            Assert.AreEqual(result, "100");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Div1()
        {
            string result = "";
            Aheui aheui = new Aheui("박발따박나망희");
            aheui.OutputReleased += (output) => result = output;
            aheui.RunAll();
            Assert.AreEqual(result, "5");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Div2()
        {
            string result = "";
            Aheui aheui = new Aheui("받박나망희");
            aheui.OutputReleased += (output) => result = output;
            aheui.RunAll();
            Assert.AreEqual(result, "1");
        }

        [TestCategory("arith")]
        [TestMethod()]
        public void AheuiTest_Div3()
        {
            string result = "";
            Aheui aheui = new Aheui("반받나망희");
            aheui.OutputReleased += (output) => result = output;
            aheui.RunAll();
            Assert.AreEqual(result, "0");
        }
    }
}