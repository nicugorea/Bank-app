using Bank_app.Models;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Controls;

namespace Bank_app.ProfilePages
{
    /// <summary>
    /// Interaction logic for AccountsPage.xaml
    /// </summary>
    public partial class AccountsPage : Page
    {
        private ProfileWindow profileWindow = null;

        public AccountsPage(ProfileWindow _profileWindow)
        {
            InitializeComponent();
            profileWindow = _profileWindow;
            LinkList();
            SetTabAccountID(profileWindow.GetAccountId());
        }

        private void SetTabAccountID(int _id)
        {
            var newTab = new UserTab(profileWindow);
            if (_id == -1)
                newTab.accountIdLabel.Content = "Unknown";
            else
                newTab.accountIdLabel.Content = _id;
            profileWindow.userTab.Content = newTab;
        }


        private void LinkList()
        {
            var db = new BankEntities();
            int userId = profileWindow.GetUserId();
            var idList = db.accounts.Where(s => s.id_user == userId).ToList();

            ArrayList accList = new ArrayList();

            foreach (account acc in idList)
            {
                int tmpId = acc.id_account;
                decimal tmpMoney = acc.money;
                accList.Add(tmpId.ToString() + "\t" + tmpMoney.ToString());
            }

            accountList.ItemsSource = accList.AsParallel();

        }

        private void btnClickSelect(object sender, System.Windows.RoutedEventArgs e)
        {
            var db = new BankEntities();
            int user_id = profileWindow.GetUserId();
            var idList = db.accounts.Where(s => s.id_user == user_id).ToList();
            profileWindow.SetAccountId(idList[accountList.SelectedIndex].id_account);
            SetTabAccountID(idList[accountList.SelectedIndex].id_account);
        }

        private void btnClickNew(object sender, System.Windows.RoutedEventArgs e)
        {
            var db = new BankEntities();
            var newAcc = new account { id_user = profileWindow.GetUserId(), money = 0 };
            db.accounts.Add(newAcc);
            db.SaveChanges();
            LinkList();
        }

        private void btnClickDelete(object sender, System.Windows.RoutedEventArgs e)
        {
            if (accountList.SelectedIndex == -1)
                return;
            var db = new BankEntities();
            int user_id = profileWindow.GetUserId();
            var idList = db.accounts.Where(s => s.id_user == user_id).ToList();
            var toDeleteId = idList[accountList.SelectedIndex].id_account;
            var toDelete = db.accounts.Find(toDeleteId);
            if (toDelete != null)
            {
                db.accounts.Remove(toDelete);
                db.SaveChanges();
                LinkList();
                if (profileWindow.GetAccountId() == toDeleteId)
                    SetTabAccountID(-1);
            }
        }
    }
}
