using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace FirstExample
{
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public MainWindowViewModel()
        {
            CurrentName = "Name";
            CurrentSurname = "Surname";
            IsButtonEnabled = true;
        }

        private string _currentSurname;

        public string CurrentSurname
        {
            get { return _currentSurname; }
            set
            {
                _currentSurname = value;
                RaisePropertyChanged();
            }
        }
        private string _currentName;

        public string CurrentName
        {
            get { return _currentName; }
            set
            {
                _currentName = value;
                RaisePropertyChanged();
            }
        }

        private ObservableCollection<Person> _persons = [];

        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set
            {
                _persons = value;
                RaisePropertyChanged();
            }
        }

        private bool _isButtonEnabled;

        public bool IsButtonEnabled
        {
            get { return _isButtonEnabled; }
            set { _isButtonEnabled = value; RaisePropertyChanged(); }
        }

        private AsyncDelegateCommand _longAddCommand;
        public ICommand ButtonClick
        {
            get
            {
                _longAddCommand ??= new AsyncDelegateCommand(LongAdd);
                return _longAddCommand;
            }
        }

        private async Task LongAdd(object o)
        {
            IsButtonEnabled = false;
            await Task.Delay(2000);
            Persons.Add(new Person() { Name = CurrentName, Surname = CurrentSurname });
            CurrentName = string.Empty;
            CurrentSurname = string.Empty;
            IsButtonEnabled = true;
        }

        #region MVVM related
        private void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
    }
}
