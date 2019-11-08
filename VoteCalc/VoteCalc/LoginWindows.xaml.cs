﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using VoteCalc.Tools;
using VoteCalc.ViewModel;

namespace VoteCalc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private LoginViewModel _loginViewModel;
        public MainWindow()
        {
             _loginViewModel = new LoginViewModel();
             this.DataContext = _loginViewModel;
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var data = Pesel.BirthdayDateTimeFromPesel(_loginViewModel.Pesel);
        }
    }
}