using SecondExample.Commands;
using SecondExample.Models;
using System.Windows.Input;

namespace SecondExample.ViewModels
{
	class BookViewModel : ViewModelBase
	{
		public Book Book;

		public BookViewModel(Book book)
		{
			Book = book;
		}

		public string Title
		{
			get { return Book.Title; }
			set
			{
				Book.Title = value;
				OnPropertyChanged("Title");
			}
		}

		public string Author
		{
			get { return Book.Author; }
			set
			{
				Book.Author = value;
				OnPropertyChanged("Author");
			}
		}

		public int Count
		{
			get { return Book.Count; }
			set
			{
				Book.Count = value;
				OnPropertyChanged("Count");
			}
		}

		#region Commands

		#region Забрать

		private DelegateCommand getItemCommand;

		public ICommand GetItemCommand
		{
			get
			{
				getItemCommand ??= new DelegateCommand(GetItem);
				return getItemCommand;
			}
		}

		private void GetItem()
		{
			Count++;
		}

		#endregion

		#region Выдать

		private DelegateCommand giveItemCommand;

		public ICommand GiveItemCommand
		{
			get
			{
				giveItemCommand ??= new DelegateCommand(GiveItem, CanGiveItem);
				return giveItemCommand;
			}
		}

		private void GiveItem()
		{
			Count--;
		}

		private bool CanGiveItem()
		{
			return Count > 0;
		}

		#endregion

		#endregion
	}
}
