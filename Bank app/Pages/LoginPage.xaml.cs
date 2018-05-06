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
        MainWindow mainWindow = null;
        public LoginPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void btnClickLogin(object sender, RoutedEventArgs e)
        {
            var database = new BankEntities();
            var query = database.users.FirstOrDefault(u => u.username == inputUsername.Text);
            if(query!=null)
            {
                if (query.password == inputPassword.Password)
                {
                    loginMessage.Content = "Succes";
                    ProfileWindow profileWindow = new ProfileWindow(query.id_user);
                    App.Current.MainWindow = profileWindow;
                    mainWindow.Close();
                    profileWindow.Show();
                }
                else
                    loginMessage.Content = "Wrong password";
            }
            else
                loginMessage.Content = "Wrong username";





        }
    }
}
