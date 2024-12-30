using System.ComponentModel;

namespace BindingToObject
{
	public class User : INotifyPropertyChanged
	{
		private string name;
		public event PropertyChangedEventHandler PropertyChanged;

		public User() { }
		public User(string name) { this.name = name; }

		public string UserName
		{
			get
			{
				return name;
			}
			set
			{
				name = value;
				OnPropertyChanged("UserName");
			}
		}

		protected void OnPropertyChanged(string name)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(name));
			}
		}
	}
}
