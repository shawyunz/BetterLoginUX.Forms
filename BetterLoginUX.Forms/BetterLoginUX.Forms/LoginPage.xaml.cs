using Xamarin.Forms;

namespace BetterLoginUX.Forms
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();
            BindingContext = this;
        }

        public bool HidePassword { get; set; } = true;

        private void ViewPassword_Tapped(object sender, System.EventArgs e)
        {
            HidePassword = !HidePassword;
            OnPropertyChanged(nameof(HidePassword));
        }
    }
}