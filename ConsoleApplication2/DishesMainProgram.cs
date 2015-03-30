using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMConsoleApplication
{
    /// <summary>
    /// Main class to get output from passed object.
    /// Dependency is injected using constructor.
    /// </summary>
    public class DishesMainProgram
    {
        IDish _dishType;
        string[] _inputArray;

        public DishesMainProgram(string[] InputArray, IDish DishType)
        {
            _dishType = DishType;
            _inputArray = InputArray;
        }

        /// <summary>
        /// Method is used to call GetOutput method of IDish type object.
        /// </summary>
        /// <returns>returns output as string.</returns>
        public string Execute()
        {
            BusinessRules br = new BusinessRules();
            if (br.Rule1_MustHaveAtleastTwoValues(_inputArray) && br.Rule2_Must_Enter_Time_of_Day(_inputArray))
            {
                return _dishType.GetOutput(_inputArray);
            }
            else
            {
                return "Error";
            }
        }
    }
}