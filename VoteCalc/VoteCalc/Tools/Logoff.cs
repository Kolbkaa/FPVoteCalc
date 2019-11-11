using System.Windows;

namespace VoteCalc.Tools
{
    internal static class Logoff
    {
        public static void LogoffToLogin()
        {
            new MainWindow().Show();

            for (var i = 0; i < Application.Current.Windows.Count; i++)
                Application.Current.Windows[0]?.Close();
        }
    }
}
