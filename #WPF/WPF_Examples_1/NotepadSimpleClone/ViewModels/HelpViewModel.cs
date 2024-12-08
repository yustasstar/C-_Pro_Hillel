using System.Windows.Input;

namespace NotepadSimpleClone.ViewModels
{
	public class HelpViewModel : ObservableObject
	{
		public ICommand HelpCommand { get; }

		public HelpViewModel()
		{
			HelpCommand = new RelayCommand(DisplayAbout);
		}

		private void DisplayAbout()
		{
			var helpDialog = new HelpDialog();
			helpDialog.ShowDialog();
		}
	}
}
