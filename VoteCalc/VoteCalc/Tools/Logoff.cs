using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VoteCalc.Tools
{
    public static class Logoff
    {
        public static void LogoffToLogin()
        {
            for (var i = 0; i < App.Current.Windows.Count; i++)
                App.Current.Windows[0].Close();
        }
    }
}
