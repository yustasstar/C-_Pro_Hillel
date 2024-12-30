using SecondExample.Models;
using System.Collections.ObjectModel;

namespace SecondExample.ViewModels
{
	class MainViewModel : ViewModelBase
	{
		public ObservableCollection<BookViewModel> BooksList { get; set; }

		#region Constructor

		public MainViewModel(List<Book> books)
		{
			BooksList = new ObservableCollection<BookViewModel>(books.Select(b => new BookViewModel(b)));
		}

		#endregion
	}
}
