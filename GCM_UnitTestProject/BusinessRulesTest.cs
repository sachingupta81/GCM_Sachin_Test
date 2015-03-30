using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCMConsoleApplication;

namespace GCM_UnitTestProject
{
    [TestClass]
    public class BusinessRulesTest
    {
        private BusinessRules BRObject;

        [TestInitialize]
        public void Setup()
        {
            //
        }

        public BusinessRulesTest()
        {
            BRObject = new BusinessRules();
        }

        [TestMethod]
        public void Rule1_MustHaveAtleastTwoValuesTest()
        {
            Assert.IsTrue(BRObject.Rule1_MustHaveAtleastTwoValues(new string[] { "Sachin", "Gupta" }));
        }
        [TestMethod]
        public void Rule1_MustHaveAtleastTwoValuesTest2()
        {
            Assert.IsTrue(BRObject.Rule1_MustHaveAtleastTwoValues(new string[] { "Sachin", "Kumar", "Gupta" }));
        }

        [TestMethod]
        public void Rule1_MustHaveAtleastTwoValuesFailTest()
        {
            Assert.IsFalse(BRObject.Rule1_MustHaveAtleastTwoValues(new string[] { "Sachin" }));
        }

        [TestMethod]
        public void Rule2_Must_Enter_Time_of_DayTest()
        {
            Assert.IsTrue(BRObject.Rule2_Must_Enter_Time_of_Day(new string[] { "Night", "Gupta" }));
        }

        [TestMethod]
        public void Rule2_Must_Enter_Time_of_DayCaseSensitiveTest()
        {
            Assert.IsTrue(BRObject.Rule2_Must_Enter_Time_of_Day(new string[] { "NIGHT", "Gupta" }));
        }

        [TestMethod]
        public void Rule2_Must_Enter_Time_of_DayTest2()
        {
            Assert.IsTrue(BRObject.Rule2_Must_Enter_Time_of_Day(new string[] { "Morning", "Kumar", "Gupta" }));
        }

        [TestMethod]
        public void Rule2_Must_Enter_Time_of_DayFailTest()
        {
            Assert.IsFalse(BRObject.Rule2_Must_Enter_Time_of_Day(new string[] { "Sachin","1" }));
        }
    }
}
