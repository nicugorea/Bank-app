using System.Windows;
using System.Windows.Controls;
using Bank_app.Models;

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
                var newUser = new user
                {
                    username = inputUsername.Text,
                    password = inputPassword.Password,
                    name = inputName.Text,
                    surname = inputSurname.Text
                };
                database.users.Add(newUser);
                database.SaveChanges();
                registerMessage.Content = "Success";

            }
        }
    }
}
