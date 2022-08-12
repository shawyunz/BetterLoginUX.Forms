using System.ComponentModel.DataAnnotations;
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
        public bool IsErrorEmail { get; set; } = true;
        public string Password { get; set; }
        public bool IsErrorPassword{ get; set; } = false;
        public bool IsNotErrorPassword => !IsErrorPassword;

        private void EntryEmail_Focused(object sender, FocusEventArgs e)
        {
            IsErrorEmail = false;
            OnPropertyChanged(nameof(IsErrorEmail));
        }

        private void EntryEmail_Unfocused(object sender, FocusEventArgs e)
        {
            if (!new EmailAddressAttribute().IsValid(((Entry)sender).Text))
            {
                IsErrorEmail = true;
                OnPropertyChanged(nameof(IsErrorEmail));
            }
        }

        private void LabelPassword_Tapped(object sender, System.EventArgs e)
        {
            if (!EntryPassword.IsFocused)
            {
                EntryPassword.Focus();
            }
        }

        private void ViewPassword_Tapped(object sender, System.EventArgs e)
        {
            HidePassword = !HidePassword;
            OnPropertyChanged(nameof(HidePassword));
        }

        private void Button_Clicked(object sender, System.EventArgs e)
        {
            if (Password?.Length < 6)
            {
                IsErrorPassword = true;
            }
            else
            {
                IsErrorPassword = false;
            }
            OnPropertyChanged(nameof(IsErrorPassword));
            OnPropertyChanged(nameof(IsNotErrorPassword));
        }
    }
}