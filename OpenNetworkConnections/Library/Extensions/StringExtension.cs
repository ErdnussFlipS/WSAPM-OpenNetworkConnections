using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace de.efsdev.wsapm.OpenNetworkConnections.Library.Extensions
{
    public static class StringExtension
    {
        public static bool IsNotNullAndEquals(this string string1, string string2)
        {
            return !string.IsNullOrEmpty(string1) && string1.Equals(string2);
        }

        public static bool Matches(this string string1, string regexPattern, RegexOptions options = RegexOptions.None, bool applyOnFullString = true)
        {
            var usedRegexPattern = applyOnFullString ? $"^{regexPattern}$" : regexPattern;

            var regex = new Regex(usedRegexPattern, options);
            return regex.IsMatch(string1);
        }
    }
}
