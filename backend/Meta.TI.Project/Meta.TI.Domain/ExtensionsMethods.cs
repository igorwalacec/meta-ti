using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Meta.TI.Domain
{
    public static class ExtensionsMethods
    {
        public static string FirstCharToUpper(this string fullName)
        {
            var getFirstName = fullName.TrimStart().ToLower().Split(" ").First();
            return char.ToUpper(getFirstName[0]) + getFirstName.Substring(1);
        }

        public static bool IsValidNumber(this string number)
        {
            Regex regex = new Regex(@"^[0-9]{2}([9]{1}[0-9]{8}$)");
            return regex.IsMatch(number);
        }
    }
}
