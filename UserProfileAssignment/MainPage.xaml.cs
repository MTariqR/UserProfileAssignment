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
        public string fileFullName;
        public MainPage()
        {
            InitializeComponent();

            // Initialize fileFullName with a default value
            var filePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            fileFullName = Path.Combine(filePath, "user_profile.txt");
            OnPropertyChanged();
            BindingContext = this;
        }

        public class Account
        {
            public string Name { get; set; }
            public string Email { get; set; }
        }

        private async void SaveChangesButton_Clicked(object sender, EventArgs e)
        {
            Account account = new Account
            {
                Name = NameEntryBox.Text,
                Email = EmailEntryBox.Text,
            };

            string jsonAccount = JsonConvert.SerializeObject(account);

            // Save the user profile to a text file
            await File.WriteAllTextAsync(fileFullName, jsonAccount);
            TextBox.Text = File.ReadAllText(fileFullName);
            NameEntryBox.IsEnabled = false;
            EmailEntryBox.IsEnabled = false;

        }

    }

}
