namespace Ofek_List;

public partial class LoginPage : ContentPage
{
    public LoginPage()
    {
        InitializeComponent();
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        string username = UsernameEntry.Text;
        string password = PasswordEntry.Text;

        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password))
        {
            MessageLabel.Text = "Please enter username and password.";
            return;
        }

        // Temporary login
        // We will connect this to your database later.
        if (username == "admin" && password == "1234")
        {
            MessageLabel.TextColor = Colors.Green;
            MessageLabel.Text = "Login successful!";

            await DisplayAlert(
                "Welcome",
                "You have successfully logged in!",
                "OK");
        }
        else
        {
            MessageLabel.TextColor = Colors.Red;
            MessageLabel.Text = "Wrong username or password.";
        }
    }
}