using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Bank_app.Models;

namespace WpfApp.Pages
{
    public partial class RegisterPage : Page
    {
        private MainWindow mainWindow = null;

        public RegisterPage(MainWindow _mainWindow)
        {
            InitializeComponent();
            mainWindow = _mainWindow;
        }

        private void SetMessage(string _message)
        {
            registerMessage.Content = _message;
        }

        private void RegisterEntity()
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
        }

        private bool IsOkInput()
        {
            if (inputUsername.Text.Length < 6)
            {
                SetMessage("Min. username length is 6 characters");
                return false;
            }
            if (inputPassword.Password.Length < 6)
            {
                SetMessage("Min. password length is 6 characters");
                return false;
            }
            if (inputPassword.Password != inputConfirmPassword.Password)
            {
                SetMessage("Passwords do not match");
                return false;
            }
            if (inputName.Text.Length == 0)
            {
                SetMessage("Fill name field");
                return false;
            }
            if (inputSurname.Text.Length == 0)
            {
                SetMessage("Fill name field");
                return false;
            }
            var database =  new BankEntities();
            var query = database.users.FirstOrDefault(u => u.username == inputUsername.Text);
            if(query!=null)
            {
                SetMessage("Username allready exist");
                return false;
            }
            return true;
        }

        private void btnClickRegister(object sender, RoutedEventArgs e)
        {
            if (IsOkInput())
            {
                RegisterEntity();
                mainWindow.SetMainFrame(new LoginPage(mainWindow));
            }
        }
    }
}
