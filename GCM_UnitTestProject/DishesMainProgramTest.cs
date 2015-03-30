using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GCMConsoleApplication;

namespace GCM_UnitTestProject
{
    [TestClass]
    public class DishesMainProgramTest
    {
        private DishesMainProgram DMProgram;
        private MorningDishes mDishes;
        private NightDishes nDishes;
        private string[] inputArray1;
        private string[] inputArray2;
        private string[] inputArray3;
        private string[] inputArray4;
        private string[] inputArray5;
        private string[] inputArray6;
        private string[] inputArray7;
        private string[] inputArray8;
        private string[] inputArray9;

        [TestInitialize]
        public void Setup()
        {
            //Can resolve them using any IOC like Autofac.
            mDishes = new MorningDishes();
            nDishes = new NightDishes();
            //DMProgram = new DishesMainProgram();
            inputArray1 = new string[] {"morning", "1", "2", "3"};
            inputArray2 = new string[] {"morning", "2", "1", "3"};
            inputArray3 = new string[] {"morning", "1", "2", "3"};
            inputArray4 = new string[] {"morning", "1", "2", "3", "4"};
            inputArray5 = new string[] {"morning", "1", "2", "3", "3", "3"};
            inputArray6 = new string[] {"night", "1", "2", "3", "4"};
            inputArray7 = new string[] {"night", "1", "2", "2", "4"};
            inputArray8 = new string[] {"night", "1", "2", "3", "5"};
            inputArray9 = new string[] {"night", "1","1", "2", "3", "5"};
        }

        public DishesMainProgramTest()
        {

        }

        //Testing full logic here however can break into 
        //separeate test classes like one class to test MorningDishes and one for NightDishes.
        //As there is no other logic but if exists, can use any mocking framework like MOQ
        //to test that logic and can mock all other methods like rule1, rule2, and execute 
        //method of Dishes class.
        [TestMethod]
        public void DishesMainProgramExecuteTest()
        {
            DMProgram = new DishesMainProgram(inputArray1, mDishes);
            Assert.IsTrue(DMProgram.Execute() == "eggs,toast,coffee");

            DMProgram = new DishesMainProgram(inputArray2, mDishes);
            Assert.IsTrue(DMProgram.Execute() == "eggs,toast,coffee");

            DMProgram = new DishesMainProgram(inputArray3, mDishes);
            Assert.IsTrue(DMProgram.Execute() == "eggs,toast,coffee");

            DMProgram = new DishesMainProgram(inputArray4, mDishes);
            Assert.IsTrue(DMProgram.Execute() == "eggs,toast,coffee,error");

            DMProgram = new DishesMainProgram(inputArray5, mDishes);
            Assert.IsTrue(DMProgram.Execute() == "eggs,toast,coffee(x3)");

            DMProgram = new DishesMainProgram(inputArray6, nDishes);
            Assert.IsTrue(DMProgram.Execute() == "steak,potato,wine,cake");

            DMProgram = new DishesMainProgram(inputArray7, nDishes);
            Assert.IsTrue(DMProgram.Execute() == "steak,potato(x2),cake");

            DMProgram = new DishesMainProgram(inputArray8, nDishes);
            Assert.IsTrue(DMProgram.Execute() == "steak,potato,wine,error");

            DMProgram = new DishesMainProgram(inputArray9, nDishes);
            Assert.IsTrue(DMProgram.Execute() == "steak,error");
        }
    }
}
