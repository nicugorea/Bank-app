using Bank_app.ProfilePages;
using System.Windows;

namespace Bank_app
{
    /// <summary>
    /// Interaction logic for ProfileWindow.xaml
    /// </summary>
    public partial class ProfileWindow : Window
    {
        public ProfileWindow(int _id)
        {
            InitializeComponent();
            userTab.Content = new UserTab(_id,this);
            optionsTab.Content = new OptionsTab();
        }
    }
}
