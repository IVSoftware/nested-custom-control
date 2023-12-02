namespace nested_custom_control.Controls;

public partial class MyCustomControl : Grid
{
	public MyCustomControl() => InitializeComponent();

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        propertyName: "Text",
        returnType: typeof(string),
        declaringType: typeof(MyCustomControl),
        defaultValue: string.Empty,
        defaultBindingMode: BindingMode.TwoWay);

    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
}