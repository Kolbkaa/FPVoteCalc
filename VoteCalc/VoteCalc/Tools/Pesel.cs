using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VoteCalc.Tools
{
    public static class Pesel
    {
        public static bool VerifyPesel(string pesel)
        {
            if (pesel == null) return false;
            if (!Regex.IsMatch(pesel, @"\d+")) return false;
            if (pesel.Length != 11) return false;
            return (int)char.GetNumericValue(pesel[10]) == (int)(10 - ((char.GetNumericValue(pesel[0]) * 1 +
                                                              char.GetNumericValue(pesel[1]) * 3 +
                                                              char.GetNumericValue(pesel[2]) * 7 +
                                                              char.GetNumericValue(pesel[3]) * 9 +
                                                              char.GetNumericValue(pesel[4]) * 1 +
                                                              char.GetNumericValue(pesel[5]) * 3 +
                                                              char.GetNumericValue(pesel[6]) * 7 +
                                                              char.GetNumericValue(pesel[7]) * 9 +
                                                              char.GetNumericValue(pesel[8]) * 1 +
                                                              char.GetNumericValue(pesel[9]) * 3)) % 10);

        }
        //dla lat 1800–1899 – 80
        //dla lat 2000–2099 – 20
        //dla lat 2100–2199 – 40
        //dla lat 2200–2299 – 60.
        public static DateTime BirthdayDateTimeFromPesel(string pesel)
        {
            var year = Convert.ToInt32(new string(pesel.Take(2).ToArray()));
            var month = Convert.ToInt32(new string(pesel.Skip(2).Take(2).ToArray()));
            var day = Convert.ToInt32(new string(pesel.Skip(4).Take(2).ToArray()));
            if (month > 80 && month < 93)
            {
                month -= 80;
                year += 1800;
            }
            else if (month > 20 && month < 33)
            {
                month -= 20;
                year += 2000;

            }
            else if (month > 40 && month < 53)
            {
                month -= 40;
                year += 2100;
            }
            else if (month > 60 && month < 73)
            {
                month -= 60;
                year += 2200;
            }
            else
            {
                year += 1900;
            }
            return new DateTime(year,month,day);
        }
    }
}
