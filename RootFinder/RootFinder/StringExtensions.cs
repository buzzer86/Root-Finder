using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RootFinder
{
    public static class StringExtensions
    {
        public static double GetNumberAtIndex(this string s, int index)
        {
            string number = "";
            
            foreach (var digit in s.Skip(index))
            {
                if (char.IsNumber(digit) || digit == '.')
                {
                    number += digit;
                }
                else
                {
                    break;
                }
            }

            return double.Parse(number);
        }
    }
}
