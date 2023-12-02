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
