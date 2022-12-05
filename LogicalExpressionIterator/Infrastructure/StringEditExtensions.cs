using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalExpressionIterator.Infrastructure
{
    public static class StringEditExtensions
    {
        public static string[] CustomSplitOnlyOnce(this string inputString, char splitter)
        {
            string[] returnArr = new string[2];
            var isSplit = false;
            for (int i = 0; i < inputString.Length; i++)
            {
                if (inputString[i] != splitter && !isSplit)
                {
                    returnArr[0] += inputString[i];
                }
                else
                {
                    isSplit = true;
                    returnArr[1] += inputString[i];
                }
            }

            return returnArr;
        }
    }
}
