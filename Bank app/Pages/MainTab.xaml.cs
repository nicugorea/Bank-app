using System.Windows;
using System.Windows.Controls;

namespace WpfApp.Pages
{
    /// <summary>
    /// Interaction logic for MainTab.xaml
    /// </summary>
    public partial class MainTab : Page
    {
        private MainWindow mainWindow = null;

        public MainTab(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void btnClickRegisterTab(object sender, RoutedEventArgs e)
        {
            mainWindow.SetMainFrame(new RegisterPage(mainWindow));
        }

        private void btnClickLoginTab(object sender, RoutedEventArgs e)
        {
            mainWindow.SetMainFrame(new LoginPage(this.mainWindow));
        }
    }
}
