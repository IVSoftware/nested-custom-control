using System.ComponentModel;
namespace nested_custom_control.Controls
{
    public partial class MyCustomGrid : Grid
    {
        public MyCustomGrid() => InitializeComponent();
        public static readonly BindableProperty UserNameProperty = BindableProperty.Create(
        propertyName: "UserName",
        returnType: typeof(string),
        declaringType: typeof(MyCustomGrid),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay);
        public string UserName
        {
            get => (string)GetValue(UserNameProperty);
            set => SetValue(UserNameProperty, value);
        }

        public static readonly BindableProperty PhoneProperty = BindableProperty.Create(
        propertyName: "Phone",
        returnType: typeof(string),
        declaringType: typeof(MyCustomGrid),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay);

        public string Phone
        {
            get => (string)GetValue(PhoneProperty);
            set => SetValue(PhoneProperty, value);
        }

        public static readonly BindableProperty EmailProperty = BindableProperty.Create(
        propertyName: "Email",
        returnType: typeof(string),
        declaringType: typeof(MyCustomGrid),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay);

        public string Email
        {
            get => (string)GetValue(EmailProperty);
            set => SetValue(EmailProperty, value);
        }
    }
}