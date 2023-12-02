# Nested Custom Controls in Custom Grid

Let me see if I follow.
___

##### MyCustomControl

The intent of your xaml seems to have a `Label` nested in the `Grid` that "is" the custom control, which would reduce to this:

```
<?xml version="1.0" encoding="utf-8" ?>
<!-- 
    x:Name should not be set here.
    That would be like a custom button saying that in every case its name should be "Button1"
 -->
<Grid
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:controls="clr-namespace:nested_custom_control.Controls"
    x:Class="nested_custom_control.Controls.MyCustomControl">
    <Label 
        FontSize="Medium"
        Text="{Binding Path=Text, Source={RelativeSource AncestorType={x:Type controls:MyCustomControl}}}"
        VerticalTextAlignment="Center"
        HorizontalTextAlignment="Center"
        />
</Grid>
```

And it exposes a bindable property named `Text`:

```csharp
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
```
___

Next, you explain in your comment:

> MyCustomGrid Is a form that contain múltiples nested CustomControls.

I understand that to mean that there will be a deterministic number of `MyCustomControl` in a layout determined by `MyCustomGrid` as in this minimal example.

[![nested controls][1]][1]

```xml
<?xml version="1.0" encoding="utf-8" ?>
<!-- 
    x:Name="MyCustomGrid" should 'not' be set here.
    That would be like a custom button saying that in every case its name should be "Button1"
 -->
<Grid 
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:controls="clr-namespace:nested_custom_control.Controls"
    x:Class="nested_custom_control.Controls.MyCustomGrid"
    RowDefinitions="*,60,60,60,*"
    BackgroundColor="Azure">
    <Border         
        Grid.Row="1">
        <!-- Instance of MyCustomControl. HERE is where you name your instances. -->
        <controls:MyCustomControl 
            x:Name="myCustomControl1"
            Text="{Binding Path=UserName, Source={RelativeSource AncestorType={x:Type controls:MyCustomGrid}}}"/>
    </Border>
    <Border         
        Grid.Row="2">
        <controls:MyCustomControl 
            x:Name="myCustomControl2"
            Text="{Binding Path=Phone, Source={RelativeSource AncestorType={x:Type controls:MyCustomGrid}}}"/>
    </Border>
    <Border          
        Grid.Row="3">
        <controls:MyCustomControl 
            x:Name="myCustomControl3"
            Text="{Binding Path=Email, Source={RelativeSource AncestorType={x:Type controls:MyCustomGrid}}}"/>
    </Border>
</Grid>
```

To specify "what text goes where" `MyCustomGrid` is exposing bindable properties `UserName`, `Phone`, and `Email` to "direct traffic" to the intended target custom control.

```csharp
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
```
___
**Usage**

Although I realize that `MainPage` is probably going to bind this and consume it in a much more sophisticated manner, to demonstrate that values are going where they're supposed to we can put a single instance of `MyGridControl` on the main page.

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage
    xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:controls="clr-namespace:nested_custom_control.Controls"
    x:Class="nested_custom_control.MainPage">
    
    <!-- Instance of MyCustomGrid. HERE is where you name your instance. -->
    <controls:MyCustomGrid x:Name="myCustomGrid1"/>
</ContentPage>
```

Then exercise it like this.

```csharp
namespace nested_custom_control
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            myCustomGrid1.UserName = "Tommy IV";
            myCustomGrid1.Phone = "(000)000-0000";
            myCustomGrid1.Email = "thor@azgard.com";
        }
    }
}
```


  [1]: https://i.stack.imgur.com/PSW08.png