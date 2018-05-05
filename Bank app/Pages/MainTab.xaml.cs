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

namespace WpfApp.Pages
{
    /// <summary>
    /// Interaction logic for MainTab.xaml
    /// </summary>
    public partial class MainTab : Page
    {
        MainWindow mainWindow = null;
        public MainTab(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }
        private void btnClickRegisterTab(object sender, RoutedEventArgs e)
        {
            mainWindow.MainFrame.Content = new RegisterPage();
        }

        private void btnClickLoginTab(object sender, RoutedEventArgs e)
        {
            mainWindow.MainFrame.Content = new LoginPage(this.mainWindow);
        }
    }
}
