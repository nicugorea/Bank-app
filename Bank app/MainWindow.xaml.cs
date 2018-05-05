using System.Windows;
using WpfApp.Pages;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
            MainTab.Content = new MainTab(this);
            MainFrame.Content = new LoginPage(this);
            
        }

    }
}
