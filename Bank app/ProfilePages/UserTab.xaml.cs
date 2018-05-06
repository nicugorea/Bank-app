using System.Windows.Controls;
using Bank_app.Models;
using WpfApp;
using WpfApp.Pages;

namespace Bank_app.ProfilePages
{
    /// <summary>
    /// Interaction logic for UserTab.xaml
    /// </summary>
    public partial class UserTab : Page
    {
        int id = 0;
        user currentUser = null;
        ProfileWindow profileWindow = null;
        public UserTab(int _id, ProfileWindow _profileWindow)
        {
            InitializeComponent();
            profileWindow = _profileWindow;
            var database = new BankEntities();
            currentUser = database.users.Find(_id);
            usernameLabel.Content = currentUser.username;
            idLabel.Content = currentUser.id_user;
            nameLabel.Content = currentUser.name;
            surnameLabel.Content = currentUser.surname;
        }
       
        private void logoutButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            App.Current.MainWindow = mainWindow;
            mainWindow.Show();
            profileWindow.Close();
        }
    }
}
