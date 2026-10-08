namespace Ofek_List;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void RegisterButton_Clicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text?.Trim() ?? "";
        string email = EmailEntry.Text?.Trim() ?? "";
        string username = UsernameEntry.Text?.Trim() ?? "";
        string password = PasswordEntry.Text ?? "";
        string confirmPassword = ConfirmPasswordEntry.Text ?? "";

        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(confirmPassword))
        {
            await DisplayAlert(
                "Missing information",
                "Please fill in all fields.",
                "OK");

            return;
        }

        if (!TermsCheckBox.IsChecked)
        {
            await DisplayAlert(
                "Terms required",
                "You must agree to the Terms of Play and Privacy Policy.",
                "OK");

            return;
        }

        if (password.Length < 8)
        {
            await DisplayAlert(
                "Password too short",
                "Your password must contain at least 8 characters.",
                "OK");

            return;
        }

        if (password != confirmPassword)
        {
            await DisplayAlert(
                "Passwords don't match",
                "Please make sure both password fields are identical.",
                "OK");

            return;
        }

        RegisterButton.IsEnabled = false;
        RegisterButton.Text = "Creating account...";

        await Task.Delay(400);

        // Registration will be connected to your database later.

        RegisterButton.Text = "Create Account";
        RegisterButton.IsEnabled = true;

        bool goToLogin = await DisplayAlert(
            "Account created!",
            $"Welcome to Ligat Fantasy, {name}!",
            "Log In",
            "Stay here");

        if (goToLogin)
        {
            await Navigation.PushAsync(new LoginPage());
        }
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}