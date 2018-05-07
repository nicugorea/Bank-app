using System;
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
        int id = 0;
        ProfileWindow profileWindow = null;
        public OptionsTab(ProfileWindow _profileWindow, int _id)
        {
            InitializeComponent();
            profileWindow = _profileWindow;
            id = _id;
        }

        private void btnClickMyAccounts(object sender, RoutedEventArgs e)
        {
            profileWindow.workingFrame.Content = new AccountsPage(profileWindow, id);
        }

    }
}
