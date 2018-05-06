using System.Windows.Controls;
using Bank_app.Models;

namespace Bank_app.ProfilePages
{
    /// <summary>
    /// Interaction logic for UserTab.xaml
    /// </summary>
    public partial class UserTab : Page
    {
        int id = 0;
        user currentUser = null;
        public UserTab(int _id)
        {
            InitializeComponent();
            var database = new BankEntities();
            currentUser = database.users.Find(_id);
            usernameLabel.Content = currentUser.username;
            idLabel.Content = currentUser.id_user;
        }
    }
}
