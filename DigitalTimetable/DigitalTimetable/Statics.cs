using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DigitalTimetable
{
    static class StaticMethods
    {
        public static string SubjToAbbr = "([A-Z])([a-z]+$)?";

        public static string GetSubjAbbreviation(this string s)
        {
            Regex abbrRegex = new Regex(@"([A-Z])([a-z]+$)?");
            MatchCollection matchCollection = abbrRegex.Matches(s);
            string output = string.Join("", from Match match in matchCollection select match.Value);

            
            return output.Substring(0, 3);
        }
    }
}
