using Bank_app;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Bank_app.Models;

namespace WpfApp.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private MainWindow mainWindow = null;

        public LoginPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void SetMessage(string _message)
        {
            loginMessage.Content = _message;
        }

        private void ChangeWindow(user _user)
        {
            ProfileWindow profileWindow = new ProfileWindow(_user.id_user);
            App.Current.MainWindow = profileWindow;
            mainWindow.Close();
            profileWindow.Show();
        }

        private bool IsOkInput(user _user)
        {
            if (_user == null)
            {
                SetMessage("Wrong Username");
                return false;
            }
            if (_user.password != inputPassword.Password)
            {
                SetMessage("Wrong Password");
                return false;
            }
            return true;
        }

        private void btnClickLogin(object sender, RoutedEventArgs e)
        {
            var database = new BankEntities();
            var query = database.users.FirstOrDefault(u => u.username == inputUsername.Text);
            if (IsOkInput(query))
                ChangeWindow(query);
        }
    }
}
