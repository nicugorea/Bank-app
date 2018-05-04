using Bank_app;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void btnClickRegister(object sender, RoutedEventArgs e)
        {
            if(inputConfirmPassword.Password == "" || inputPassword.Password == "" || inputUsername.Text == "")
            {
                registerMessage.Content = "Complete all fields";
            }
            else if (inputPassword.Password != inputConfirmPassword.Password)
            {
                registerMessage.Content = "Passwords are not the same";
            }
            else
            {

                var database = new BankEntities();
                var newUser = new user();
                newUser.username = inputUsername.Text;
                newUser.password = inputPassword.Password;
                database.users.Add(newUser);
                database.SaveChangesAsync();
                registerMessage.Content = "Success";

            }
        }
    }
}
