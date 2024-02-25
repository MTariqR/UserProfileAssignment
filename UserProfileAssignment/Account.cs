using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserProfileAssignment
{
    public class Account : INotifyPropertyChanged
    {
		private string _name;

		public string Name
		{
			get { return _name; }
			set { _name = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Name))); }
		}

		private string _surname;

        public string Surname
		{
			get { return _surname; }
			set { _surname = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Surname))); }
		}

		private string _email;

		public string Email 
		{
			get { return _email; }
			set { _email = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Email))); }
		}

		private string _bio;

		public string Bio
		{
			get { return _bio; }
			set { _bio = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Bio))); }
		}

		public event PropertyChangedEventHandler? PropertyChanged;

    }
}
