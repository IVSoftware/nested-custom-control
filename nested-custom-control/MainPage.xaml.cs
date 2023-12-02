using nested_custom_control.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace nested_custom_control
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext.UserName = "Tommy IV";
            BindingContext.Phone = "(000)000-0000";
            BindingContext.Email = "thor@azgard.com";
        }
        new MainPageBindingContext BindingContext => (MainPageBindingContext)base.BindingContext;
    }
    class MainPageBindingContext : INotifyPropertyChanged
    {
        public string UserName
        {
            get => _userName;
            set
            {
                if (!Equals(_userName, value))
                {
                    _userName = value;
                    OnPropertyChanged();
                }
            }
        }
        string _userName = string.Empty;
        public string Phone
        {
            get => _phone;
            set
            {
                if (!Equals(_phone, value))
                {
                    _phone = value;
                    OnPropertyChanged();
                }
            }
        }
        string _phone = string.Empty;
        public string Email
        {
            get => _email;
            set
            {
                if (!Equals(_email, value))
                {
                    _email = value;
                    OnPropertyChanged();
                }
            }
        }
        string _email = string.Empty;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
