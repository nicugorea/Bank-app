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
        ProfileWindow profileWindow = null;
        int id = 0;
        int accId = -1;

        public AccountsPage(ProfileWindow _profileWindow, int _id)
        {
            InitializeComponent();
            id = _id;
            profileWindow = _profileWindow;
            LinkList();
            SetTabAccountID(-1);
        }

        void SetTabAccountID(int _id)
        {
            var newTab = new UserTab(profileWindow, id);
            if (_id == -1)
                newTab.accountIdLabel.Content = "Unknown";
            else
                newTab.accountIdLabel.Content = _id;
            profileWindow.userTab.Content = newTab;
        }


        private void LinkList()
        {
            var db = new BankEntities();
            var idList = db.accounts.Where(s => s.id_user == id).ToList();

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
            var idList = db.accounts.Where(s => s.id_user == id).ToList();
            accId = idList[accountList.SelectedIndex].id_account;
            SetTabAccountID(accId);
        }

        private void btnClickNew(object sender, System.Windows.RoutedEventArgs e)
        {
            var db = new BankEntities();
            var newAcc = new account { id_user = id, money = 0 };
            db.accounts.Add(newAcc);
            db.SaveChanges();
            LinkList();
        }

        private void btnClickDelete(object sender, System.Windows.RoutedEventArgs e)
        {
            if (accId != 0)
            {
                var db = new BankEntities();
                var idList = db.accounts.Where(s => s.id_user == id).ToList();
                var toDeleteId = idList[accountList.SelectedIndex].id_account;
                var toDelete = db.accounts.Find(toDeleteId);
                if (toDelete != null)
                {
                    db.accounts.Remove(toDelete);
                    db.SaveChanges();
                    LinkList();
                    if (accId == toDeleteId)
                        SetTabAccountID(-1);
                }
            }
        }
    }
}
