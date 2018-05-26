using System.ComponentModel;
using PropertyChanged;

namespace StardriveModEditor.ViewModels
{
    /// <summary>
    /// Base view model to handle the property changed thingy.
    /// </summary>
    [AddINotifyPropertyChangedInterface]
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}
