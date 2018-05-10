using Bank_app.Models;
using System;
using System.Collections;
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

namespace Bank_app.ProfilePages
{
    /// <summary>
    /// Interaction logic for PaymentsPage.xaml
    /// </summary>
    public partial class PaymentsPage : Page
    {
        ProfileWindow profileWindow = null;
        public PaymentsPage(ProfileWindow _profileWindow)
        {
            InitializeComponent();
            profileWindow = _profileWindow;
            SetList("sender", "time");
            SetList("reciever", "time");
        }

        List<payment> GetList(string _type)
        {
            var db = new BankEntities();
            if (_type == "reciever")
                return db.payments.Where(s => s.id_reciever == profileWindow.accountId).ToList();
            else if (_type == "sender")
                return db.payments.Where(s => s.id_sender == profileWindow.accountId).ToList();
            else return null;
        }

        void SetList(string _listType, string _sortType)
        {
            List<payment> paymentList = GetList(_listType);
            List<payment> orderedList = null;
            if (_sortType == "reciever")
                orderedList = paymentList.OrderBy(order => order.id_reciever).ToList();
            else if (_sortType == "sender")
                orderedList = paymentList.OrderBy(order => order.id_reciever).ToList();
            else if (_sortType == "money")
                orderedList = paymentList.OrderBy(order => order.money).ToList();
            else if (_sortType == "time")
                orderedList = paymentList.OrderBy(order => order.time).ToList();

            ArrayList payList = new ArrayList();

            foreach (payment paym in orderedList)
            {
                int recId = paym.id_reciever;
                int sendId = paym.id_sender;
                decimal tmpMoney = paym.money;
                DateTime time = paym.time;
                payList.Add(sendId.ToString() + " " + recId.ToString() + " " + tmpMoney.ToString() + " " + time.ToString());
            }

            if (_listType == "sender")
                sentPaymentList.ItemsSource = payList.AsParallel();
            else
                recievedPaymentList.ItemsSource = payList.AsParallel();
        }

        private void btnClickSentSortId(object sender, RoutedEventArgs e)
        {
            SetList("sender", "reciever");
        }

        private void btnClickSentSortMoney(object sender, RoutedEventArgs e)
        {
            SetList("sender", "money");
        }
        private void btnClickSentSortTime(object sender, RoutedEventArgs e)
        {
            SetList("sender", "time");
        }
        private void btnClickRecievedSortId(object sender, RoutedEventArgs e)
        {
            SetList("reciever", "sender");
        }
        private void btnClickRecievedSortMoney(object sender, RoutedEventArgs e)
        {
            SetList("reciever", "money");
        }
        private void btnClickRecievedSortTime(object sender, RoutedEventArgs e)
        {
            SetList("reciever", "time");
        }
    }
}
