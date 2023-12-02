using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace nested_custom_control.Controls;

public partial class MyCustomGrid : Grid
{
	public MyCustomGrid()
    {
        base.BindingContext = new MyCustomGridBindingContext();
        InitializeComponent();
    }
    class MyCustomGridBindingContext : INotifyPropertyChanged
    {
        public string Text
        {
            get => _text;
            set
            {
                if (!Equals(_text, value))
                {
                    _text = value;
                    OnPropertyChanged();
                }
            }
        }
        string _text = string.Empty;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}