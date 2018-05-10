using Bank_app.Models;
using System;
using System.Collections;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Bank_app.ProfilePages
{
    /// <summary>
    /// Interaction logic for PayPage.xaml
    /// </summary>
    public partial class PayPage : Page
    {
        ProfileWindow profileWindow = null;
        public PayPage(ProfileWindow _profileWindow)
        {
            InitializeComponent();
            profileWindow = _profileWindow;
            SetList();

        }

        private void SetMessage(string _message)
        {
            sendMessage.Content = _message;
        }

        private void SetList()
        {
            var db = new BankEntities();
            int account_id = profileWindow.GetAccountId();
            var favList = db.favourite_payment.Where(s => s.id_account == account_id).ToList();
            ArrayList payList = new ArrayList();

            foreach (favourite_payment paym in favList)
            {
                int recId = paym.id_reciever;
                decimal tmpMoney = paym.money;
                payList.Add(recId.ToString() + " " + tmpMoney.ToString());
            }
            favouritePayments.ItemsSource = payList.AsParallel();
        }


        private void btnClickSelect(object sender, RoutedEventArgs e)
        {

            var db = new BankEntities();
            int account_id = profileWindow.GetAccountId();
            var favList = db.favourite_payment.Where(s => s.id_account == account_id).ToList();
            var favpay = favList[favouritePayments.SelectedIndex];
            inputAccountId.Text = favpay.id_reciever.ToString();
            inputSum.Text = favpay.money.ToString();
        }

        private void btnClickSave(object sender, RoutedEventArgs e)
        {
            if (!IsOkInput())
                return;
            var db = new BankEntities();
            int accId = 0;
            decimal sum = 0;
            Int32.TryParse(inputAccountId.Text, out accId);
            Decimal.TryParse(inputSum.Text, out sum);
            var newSave = new favourite_payment
            {
                id_account = profileWindow.GetAccountId(),
                id_reciever = accId,
                money = sum
            };
            db.favourite_payment.Add(newSave);
            db.SaveChanges();
            SetList();
        }

        private bool IsOkInput()
        {
            int accId = -1;
            decimal sum = -1;


            if (!Int32.TryParse(inputAccountId.Text, out accId))
            {
                SetMessage("Invalid id");
                return false;
            }
            if (!Decimal.TryParse(inputSum.Text, out sum))
            {
                SetMessage("Invalid ammount");
                return false;
            }

            var db = new BankEntities();
            var sender = db.accounts.Find(profileWindow.GetAccountId());
            var reciever = db.accounts.Find(accId);
            if(sender.money<sum)
            {
                SetMessage("Not enought money");
                return false;
            }
            if (reciever == null)
            {
                SetMessage("Reciever id unknown");
                return false;
            }
            return true;
        }

        private void btnClickSend(object sender, RoutedEventArgs e)
        {
            if (!IsOkInput())
                return;
            decimal tmpSum = 0;
            int recieverId = 0;
            Int32.TryParse(inputAccountId.Text, out recieverId);
            Decimal.TryParse(inputSum.Text, out tmpSum);
            var db = new BankEntities();
            var currentAccount = db.accounts.Find(profileWindow.GetAccountId());
            var reciever = db.accounts.Find(recieverId);


            var newPayment = new payment
            {
                id_sender = profileWindow.GetAccountId(),
                id_reciever = recieverId,
                money = tmpSum,
                time = DateTime.Now
            };
            currentAccount.money -= tmpSum;
            reciever.money += tmpSum;
            db.payments.Add(newPayment);
            db.SaveChanges();
            sendMessage.Content = "Sent";


        }
    }
}
