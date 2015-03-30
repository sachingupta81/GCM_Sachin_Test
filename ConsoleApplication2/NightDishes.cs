using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCMConsoleApplication
{
    public class NightDishes : IDish
    {
        /// <summary>
        /// Method is used to convert user choice (inputs) into actual orders after verifying the eligibility.
        /// </summary>
        /// <param name="strArray">Input string array</param>
        /// <returns>String output (comma separated)</returns>
        public string GetOutput(string[] strArray)
        {
            string[] dishArray = new string[strArray.Length - 1];
            Array.Copy(strArray, 1, dishArray, 0, strArray.Length - 1);

            List<DishDO> objDishList = new List<DishDO>();

            foreach (string str in dishArray)
            {
                string result = GetDishesName(strArray[0], str.Trim(), objDishList);
                if (result != "")
                {
                    objDishList.Add(new DishDO { id = result == "error" ? 1000 : Convert.ToInt32(str), count = 1, DishName = result });
                    if (result == "error")
                        break;
                }
            }
            List<DishDO> objDishListSorted = objDishList.OrderBy(i => i.id).ToList();
            string finalString = string.Join(",", objDishListSorted.ConvertAll(d => d.DishName).ToArray());
            if (objDishList.Where(d => d.id == 2).FirstOrDefault() != null && objDishList.Where(d => d.id == 2).FirstOrDefault().count > 1)
            {
                finalString = finalString.Replace("potato", string.Format("potato(x{0})", objDishList.Where(d => d.id == 2).FirstOrDefault().count.ToString()));
            }

            return finalString;
        }

        /// <summary>
        /// Method is used to get the Dish Name and if Dish Type is 2 (side), then allow multiple orders.
        /// </summary>
        /// <param name="timeOfDay">Morning or night or any other like Lunch</param>
        /// <param name="dishType">like drink, side, dessert</param>
        /// <param name="objDishDOList">List of Dishes passed to update count</param>
        /// <returns>returns Dish Name if eligible, otherwise error or increase the count.</returns>
        private string GetDishesName(string timeOfDay, string dishType, List<DishDO> objDishDOList)
        {
            int res;
            if (!int.TryParse(dishType, out res))
                return "error";
            //Can implement a separate business rule as it may change over the time.
            if (dishType == "2" && (objDishDOList.Where(i => i.id == 2).FirstOrDefault() != null && objDishDOList.Where(i => i.id == 2).FirstOrDefault().count > 0))
            {
                objDishDOList.Where(i => i.id == 2).FirstOrDefault().count = objDishDOList.Where(i => i.id == 2).FirstOrDefault().count + 1;
                return "";
            }
            else if (objDishDOList.Count(i => i.id == Convert.ToInt32(dishType)) > 0)
            {
                return "error";
            }
            else
            {
                switch (dishType)
                {
                    case "1": return "steak";
                    case "2": return "potato";
                    case "3": return "wine";
                    case "4": return "cake";
                    default: return "error";
                }
            }
        }

    }
}
