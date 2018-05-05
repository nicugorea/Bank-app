using Bank_app.ProfilePages;
using System.Windows;

namespace Bank_app
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public ProfileWindow()
        {
            InitializeComponent();
            userTab.Content = new UserTab();
            optionsTab.Content = new OptionsTab();
        }
    }
}
