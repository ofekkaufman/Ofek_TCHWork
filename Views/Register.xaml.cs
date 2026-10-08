namespace Ofek_List;

public partial class RegisterPage : ContentPage
{
    public RegisterPage()
    {
        InitializeComponent();
    }

    private async void RegisterButton_Clicked(object sender, EventArgs e)
    {
        string name = NameEntry.Text;
        string email = EmailEntry.Text;
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;
        string confirmPassword = ConfirmPasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(name) ||
            string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password) ||
            string.IsNullOrWhiteSpace(confirmPassword))
        {
            MessageLabel.TextColor = Colors.Red;
            MessageLabel.Text = "Please fill in all fields.";
            return;
        }

        if (password != confirmPassword)
        {
            MessageLabel.TextColor = Colors.Red;
            MessageLabel.Text = "Passwords do not match.";
            return;
        }

        if (password.Length < 4)
        {
            MessageLabel.TextColor = Colors.Red;
            MessageLabel.Text = "Password must be at least 4 characters.";
            return;
        }

        // Registration successful for now.
        // Later we will save the user to your database.

        MessageLabel.TextColor = Colors.Green;
        MessageLabel.Text = "Registration successful!";

        await DisplayAlert(
            "Success",
            "Your account has been created!",
            "OK");

        await Navigation.PushAsync(new LoginPage());
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new LoginPage());
    }
}