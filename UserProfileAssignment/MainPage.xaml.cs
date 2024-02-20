using System;
using System.IO;
using System.Text;
using Newtonsoft.Json;

namespace UserProfileAssignment
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            //LoadProfile(); #will create a method that loads the last profile on launch
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

            string json = JsonConvert.SerializeObject(account, Formatting.Indented);
            TextBox.Text = json;
        }
    }

}
