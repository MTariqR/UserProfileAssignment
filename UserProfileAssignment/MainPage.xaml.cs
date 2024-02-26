/*using System;
using System.ComponentModel;
using System.IO;
using System.Net.Http.Json;
using System.Text;
using Newtonsoft.Json;

namespace UserProfileAssignment
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            //CurrentProfile = LoadProfile(); #will create a method that loads the last profile on launch
        }
        public class Account 
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }

        private void SaveChangesButton_Clicked(object sender, EventArgs e)
        {
            Account account = new Account
            { 
                Name = NameEntryBox.Text,
                Email = EmailEntryBox.Text,
            };

            string accountJson = JsonConvert.SerializeObject(account);
            //need to save the account jason to a json file 
        }

        private void LoadChangesButton_Clicked(object sender, EventArgs e)
        {
            string jsonFileContent = File.ReadAllText(/*filepath*//*);
            Account stringAccount = JsonConvert.DeserializeObject<Account>(jsonFileContent);
        }
    }

}*/

using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using Microsoft.Maui.Storage;
using Newtonsoft.Json;

namespace UserProfileAssignment
{
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public string fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "accounts.txt");

        public MainPage()
        {
            InitializeComponent();
            CurrentAccount = LoadAccount();
            BindingContext = this;

        }

        private Account _account;

        public Account CurrentAccount
        {
            get { return _account; }
            set { _account = value; }
        }
        public void DisableEntry() 
        {
            EmailEntry.IsEnabled = false;
            NameEntry.IsEnabled = false;
            SurnameEntry.IsEnabled = false;
            BioEntry.IsEnabled = false;
        }

        public void EnableEntry() 
        {
            EmailEntry.IsEnabled = true;
            NameEntry.IsEnabled = true;
            SurnameEntry.IsEnabled = true;
            BioEntry.IsEnabled = true;
        }
        public void SaveAccount(Account account)
        {
            string accountJson = JsonConvert.SerializeObject(account);
            File.WriteAllText(fileName, accountJson);
        }

        public Account LoadAccount() 
        {
            if (File.Exists(fileName))
            {
                string accountTxt = File.ReadAllText(fileName);

                Account savedAccount = JsonConvert.DeserializeObject<Account>(accountTxt);
                MessageLabel.Text = "Account Details Loaded";
                DisableEntry();
                return savedAccount;

            }
            else
            {
                return new Account();
            }
        }

        private async void SaveChangesButton_Clicked(object sender, EventArgs e)
        {
            SaveAccount(CurrentAccount);
            MessageLabel.Text = "Account Saved";
            DisableEntry();
        }

        private async void EditBtnClick(object sender, EventArgs e)
        {
            MessageLabel.Text = "Enter New Account Details";
            EnableEntry();
        }
    }

}
