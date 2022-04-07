using FabricMethodInICommand.FabricMethod;

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace FabricMethodInICommand
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        private Phone selectedPhone;

        public static ObservableCollection<Phone> Phones { get; set; }

        private CommandCreator _commandCreator;

        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                _commandCreator = new AddNewCommandCreator();
                return _commandCreator.FactoryMethod();
            }
        }

        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel()
        {
            Phones = new ObservableCollection<Phone>
            {
                new Phone {Title="iPhone 7", Company="Apple", Price=56000 },
                new Phone {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 },
                new Phone {Title="Elite x3", Company="HP", Price=56000 },
                new Phone {Title="Mi5S", Company="Xiaomi", Price=35000 }
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }

}
