using Bank_app.ProfilePages;
using System.Windows;
using System.Windows.Controls;

namespace Bank_app
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        
        private int id_user = 0;
        private int id_account = -1;

        public int GetUserId() { return id_user; }
        public int GetAccountId() { return id_account; }

        public void SetUserId(int _id) { id_user = _id; }
        public void SetAccountId(int _id) { id_account = _id; }

        public void SetMainFrame(Page _page) { mainFrame.Content = _page; }

        public ProfileWindow(int _id_user)
        {
            InitializeComponent();
            SetUserId(_id_user);
            userTab.Content = new UserTab(this);
            optionsTab.Content = new OptionsTab(this);
            SetMainFrame(new AccountsPage(this));
        }
    }
}
