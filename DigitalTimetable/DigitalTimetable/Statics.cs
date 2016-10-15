using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DigitalTimetable
{
    static class StaticMethods
    {
        public static char[] alpha = "aAbBcCdDeEfFgGhHiIjJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ".ToCharArray();

        public static string GetSubjAbbreviation(this string s)
        {
            Regex abbrRegex = new Regex(@"([A-Z])([a-z]+$)?");
            MatchCollection matchCollection = abbrRegex.Matches(s);
            string output = string.Join("", from Match match in matchCollection select match.Value);

            
            return output.Substring(0, 3);
        }

        public static Color GetSubjColor(this string s) // Generate a colour from a string of three letters
        {
            if (s.Length > 3)
            {
                throw new FormatException($"String passed to GetSubjColour() was too long. Min: 3 characters, given string was {s.Length} characters long.");
                return new Color(0, 0, 0); // in case, for some reason, I'm handling that exception.
            }
            

            int indexR = Array.IndexOf(alpha, s[0]);
            int indexG = Array.IndexOf(alpha, s[1]);
            int indexB = Array.IndexOf(alpha, s[2]);

            int R = (indexR * 5).Clamp(0, 255); // Our array contains 52 characters. Colors can be from 0 to 255. To get the full range, it's best to multiply by 5.
                                                // However, as 52*5 is 260, we need some clamping. While we're doing that, we might as well refrain from it being negative too.
            int G = (indexG * 5).Clamp(0, 255);
            int B = (indexB * 5).Clamp(0, 255);

            Color output = new Color(R, G, B); // whew, we don't have to convert them to bytes like in WPF...
            return output;
        }

        public static int Clamp(this int i, int max, int min) // This extension method will cap a value in between two integers.
        {
            int limitTop = Math.Min(i, max); // not like the film format though
            int limitBottom = Math.Max(i, min);

            return limitBottom;
        }
    }
}
