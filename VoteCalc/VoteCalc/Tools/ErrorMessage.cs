using System;
using System.Windows;

namespace VoteCalc.Tools
{
    internal static class ErrorMessage
    {
        public static void ShowError(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        public static void ShowError(string message,Exception e)
        {
            MessageBox.Show($"{message}\n{e.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
