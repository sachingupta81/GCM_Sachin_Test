using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMConsoleApplication
{
    public class BusinessRules
    {
        public bool Rule1_MustHaveAtleastTwoValues(string[] strArray)
        {
            if (strArray.Count() > 1)
                return true;
            return false;
        }

        public bool Rule2_Must_Enter_Time_of_Day(string[] strArray)
        {
            if (strArray[0].ToString().Equals("morning", StringComparison.CurrentCultureIgnoreCase) || strArray[0].ToString().Equals("night", StringComparison.CurrentCultureIgnoreCase))
                return true;
            return false;
        }
    }
}
