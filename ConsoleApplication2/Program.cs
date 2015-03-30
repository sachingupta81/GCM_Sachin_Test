using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMConsoleApplication
{
    class Program
    {
        //Main starting point.
        static void Main(string[] args)
        {
            //Accept input multiple times
            do
            {
                Console.Write("Input:");
                string input = Console.ReadLine();
                string[] strArray = GetInputArray(input);

                DishesMainProgram dMP;
                //Can add one more class easily in future like lunch
                //Just need to add a new class implementing the same interface 
                //and need to add a condition here which can be moved to configuration
                //to resolve the dependency.
                if (strArray[0].ToString().Equals("morning", StringComparison.CurrentCultureIgnoreCase))
                {
                    //Can use IOC/DI to resolve the DishType
                    MorningDishes mdish = new MorningDishes();
                    dMP = new DishesMainProgram(strArray, mdish);
                    Console.WriteLine("Output: {0}", dMP.Execute());
                }
                if (strArray[0].ToString().Equals("night", StringComparison.CurrentCultureIgnoreCase))
                {
                    //Can use IOC/DI to resolve the DishType
                    NightDishes mdish = new NightDishes();
                    dMP = new DishesMainProgram(strArray, mdish);
                    Console.WriteLine("Output: {0}", dMP.Execute());
                }

                Console.WriteLine("Do you want to continue (Y/N)? ");
            } while (Console.ReadLine().Equals("Y", StringComparison.CurrentCultureIgnoreCase));
        }

        //Convert comma separated string into String Array.
        //Didn't add test case for it.
        private static string[] GetInputArray(string str)
        {
            string[] result;
            if (str.Length > 0)
            {
                result = str.Split(',');
                return result;
            }
            result = new string[] { "Error" };
            return result;
        }

        
    }
}
