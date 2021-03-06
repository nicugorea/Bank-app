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

namespace Bank_app.ProfilePages
{
    /// <summary>
    /// Interaction logic for OptionsTab.xaml
    /// </summary>
    public partial class OptionsTab : Page
    {
        ProfileWindow profileWindow = null;
        public OptionsTab(ProfileWindow _profileWindow)
        {
            InitializeComponent();
            profileWindow = _profileWindow;
        }

        private void btnClickMyAccounts(object sender, RoutedEventArgs e)
        {
            profileWindow.SetMainFrame(new AccountsPage(profileWindow));
        }

        private void btnClickPay(object sender, RoutedEventArgs e)
        {
            profileWindow.SetMainFrame(new PayPage(profileWindow));
        }

        private void btnClickMyPayments(object sender, RoutedEventArgs e)
        {
            profileWindow.SetMainFrame(new PaymentsPage(profileWindow));
        }
    }
}
