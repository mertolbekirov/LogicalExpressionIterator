using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicalExpressionIterator.Infrastructure
{
    public static class StringEditExtensions
    {
        public static string[] CustomSplitOnlyOnce(this string inputString, char splitter, bool removeSpaces = false)
        {
            string[] returnArr = new string[2];
            var isSplit = false;
            for (int i = 0; i < inputString.Length; i++)
            {
                if (removeSpaces)
                {
                    continue;
                }
                if (inputString[i] != splitter && !isSplit)
                {
                    returnArr[0] += inputString[i];
                }
                else
                {
                    if (isSplit == false)
                    {
                        isSplit = true;
                        continue;
                    }
                    returnArr[1] += inputString[i];
                }
            }


            return returnArr;
        }

        public static string[] CustomSplit(this string str, char separator)
        {
            var parts = new CustomList<string>();
            var currentPart = string.Empty;

            foreach (var ch in str)
            {
                if (ch == separator)
                {
                    parts.Add(currentPart);
                    currentPart = string.Empty;
                }
                else
                {
                    currentPart += ch;
                }
            }

            if (currentPart != string.Empty)
            {
                parts.Add(currentPart);
            }

            return parts.ToArray();
        }

        public static string CustomReplace(this string str, string oldValue, string newValue)
        {
            var sb = new SimpleStringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                var foundMatch = true;

                for (int j = 0; j < oldValue.Length && (i + j) < str.Length; j++)
                {
                    if (str[i + j] != oldValue[j])
                    {
                        foundMatch = false;
                        break;
                    }
                }

                if (foundMatch)
                {
                    sb.Append(newValue);
                    i += oldValue.Length - 1;
                }
                else
                {
                    sb.Append(str[i].ToString());
                }
            }

            return sb.ToString();
        }
    }

    
}
