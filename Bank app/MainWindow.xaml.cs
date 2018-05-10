using System.Windows;
using System.Windows.Controls;
using WpfApp.Pages;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public void SetMainFrame(Page _page)
        {
            MainFrame.Content = _page;
        }

        public MainWindow()
        {
            InitializeComponent();
            
            MainTab.Content = new MainTab(this);
            SetMainFrame(new LoginPage(this));
            
        }

    }
}
