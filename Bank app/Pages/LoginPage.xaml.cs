using Bank_app;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                    ProfileWindow profileWindow = new ProfileWindow();
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
