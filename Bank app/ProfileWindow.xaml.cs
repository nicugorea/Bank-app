using Bank_app.ProfilePages;
using System.Windows;

namespace Bank_app
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        
        public int id = 0;
        public int accountId = -1;
        public ProfileWindow(int _id)
        {
            InitializeComponent();
            id = _id;
            userTab.Content = new UserTab(this);
            optionsTab.Content = new OptionsTab(this);
            workingFrame.Content = new AccountsPage(this);
        }
    }
}
