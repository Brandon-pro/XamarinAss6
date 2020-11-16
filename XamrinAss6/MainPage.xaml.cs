using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Banking;

namespace XamrinAss6
{
    public partial class MainPage : ContentPage
    {
        BankAccount _account;
        public MainPage()
        {
            InitializeComponent();
            
            Bank fnb = new Bank("First National Bank", 4324, "Kenilworth");
            Customer myNewCustomer = new Customer("7766445424", "10 me at home", "Bob", "The Builder");
            fnb.AddCustomer(myNewCustomer);

            _account = myNewCustomer.ApplyForBankAccount();
            
        }

        private void TranferButton_Clicked(object sender, EventArgs e)

        {
            decimal transferAmount = 0;
            var valid = decimal.TryParse(TransferAmountEntry.Text, out transferAmount);
            var reason =  TransferReasonEntry.Text ;
            if(valid)
            {
                _account.DepositMoney(transferAmount, DateTime.Now, "Stipend");
            }
            else
            {
                DisplayAlert("Validaion Error", "Please Enter Amount", "Cancel");
            }

        }

        private void DisplayTransactionButton_Clicked(object sender, EventArgs e)
        {
            _account.GetTransactionHistory();
        }
    }
}
