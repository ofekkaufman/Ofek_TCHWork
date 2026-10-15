using Ofek_List.Services;

namespace Ofek_List;

public partial class RegisterPage : ContentPage
{
    private readonly UserService _userService = new();

    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void RegisterButton_Clicked(
        object sender, EventArgs e)
    {
        string name = NameEntry.Text?.Trim() ?? "";
        string email = EmailEntry.Text?.Trim() ?? "";
        string username = UsernameEntry.Text?.Trim() ?? "";
        string password = PasswordEntry.Text ?? "";
        string confirmPassword = ConfirmPasswordEntry.Text ?? "";

        MessageLabel.Text = "";

        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(confirmPassword))
        {
            MessageLabel.Text = "Please fill in all fields.";
            return;
        }

        if (!email.Contains('@') ||
            !email.Contains('.'))
        {
            MessageLabel.Text = "Please enter a valid email.";
            return;
        }

        if (password.Length < 8)
        {
            MessageLabel.Text =
                "Your password must contain at least 8 characters.";
            return;
        }

        if (password != confirmPassword)
        {
            MessageLabel.Text = "Passwords don't match.";
            return;
        }

        RegisterButton.IsEnabled = false;
        RegisterButton.Text = "Creating account...";

        try
        {
            bool success = _userService.Register(
                name,
                email,
                username,
                password,
                out string message);

            if (!success)
            {
                MessageLabel.Text = message;
                return;
            }

            await DisplayAlert(
                "Account created!",
                $"Welcome to Ligat Fantasy, {name}!",
                "Log In");

            await Navigation.PopAsync();
        }
        finally
        {
            RegisterButton.Text = "Register";
            RegisterButton.IsEnabled = true;
        }
    }

    private async void LoginButton_Clicked(
        object sender, TappedEventArgs e)
    {
        await Navigation.PopAsync();
    }
}
