namespace Ofek_List;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        string email = UsernameEntry.Text?.Trim() ?? "";
        string password = PasswordEntry.Text ?? "";

        if (string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(password))
        {
            await DisplayAlert(
                "Missing information",
                "Please enter your email and password.",
                "OK");

            return;
        }

        LoginButton.IsEnabled = false;
        LoginButton.Text = "Signing in...";

        await Task.Delay(300);

        // Temporary login
        // Replace this with your database authentication later.
        if (email == "admin" && password == "1234")
        {
            LoginButton.Text = "Log In";
            LoginButton.IsEnabled = true;

            await DisplayAlert(
                "Welcome back!",
                "You have successfully logged in.",
                "OK");

            return;
        }

        LoginButton.Text = "Log In";
        LoginButton.IsEnabled = true;

        await DisplayAlert(
            "Login failed",
            "The email or password is incorrect.",
            "OK");
    }

    private async void RegisterNav_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }

    private void LoginNav_Clicked(object sender, EventArgs e)
    {
        // Already on the login page.
    }
}