using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace nested_custom_control
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
    class MainPageBindingContext : INotifyPropertyChanged
    {
        public string Text1
        {
            get => _text1;
            set
            {
                if (!Equals(_text1, value))
                {
                    _text1 = value;
                    OnPropertyChanged();
                }
            }
        }
        string _text1 = string.Empty;
        public string Text2
        {
            get => _text2;
            set
            {
                if (!Equals(_text2, value))
                {
                    _text2 = value;
                    OnPropertyChanged();
                }
            }
        }
        string _text2 = string.Empty;
        public string Text3
        {
            get => _text3;
            set
            {
                if (!Equals(_text3, value))
                {
                    _text3 = value;
                    OnPropertyChanged();
                }
            }
        }
        string _text3 = string.Empty;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
