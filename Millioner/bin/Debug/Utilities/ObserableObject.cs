using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Millioner.Utilities
{
    class ObserableObject : System.ComponentModel.INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObserableObject()
        {

        }

        public void Set<T>(ref T prop, T value, [CallerMemberName] string prop_name = "")
        {
            prop = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop_name));
        }
    }
}
