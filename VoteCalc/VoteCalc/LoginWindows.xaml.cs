using System;
using System.Windows;
using System.Windows.Input;
using VoteCalc.Model;
using VoteCalc.Tools;
using VoteCalc.ViewModel;

namespace VoteCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        private readonly LoginViewModel _loginViewModel;
        public MainWindow()
        {
            _loginViewModel = new LoginViewModel();
            this.DataContext = _loginViewModel;
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_loginViewModel.FirstName))
            {
                MessageBox.Show("Wrong first name.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (string.IsNullOrWhiteSpace(_loginViewModel.LastName))
            {
                MessageBox.Show("Wrong last name.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }
            if (!Pesel.VerifyPesel(_loginViewModel.Pesel))
            {
                MessageBox.Show("Wrong pesel number.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (DateTime.Compare(Pesel.BirthdayDateTimeFromPesel(_loginViewModel.Pesel).AddYears(18), new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day)) > 0)
            {
                MessageBox.Show("You are to young.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var voter = new Voter
            {
                FirstName = _loginViewModel.FirstName,
                LastName = _loginViewModel.LastName,
                Pesel = _loginViewModel.Pesel
            };

            new VoteWindow(voter).Show();
            Close();
        }
    }
}
