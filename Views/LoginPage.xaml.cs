using Ofek_List.Services;

namespace Ofek_List;

public partial class LoginPage : ContentPage
{
    private readonly UserService _userService = new();

    public LoginPage()
    {
        InitializeComponent();
    }

    private async void LoginButton_Clicked(
        object sender, EventArgs e)
    {
        string username = UsernameEntry.Text?.Trim() ?? "";
        string password = PasswordEntry.Text ?? "";

        MessageLabel.Text = "";

        if (string.IsNullOrWhiteSpace(username) ||
            string.IsNullOrWhiteSpace(password))
        {
            MessageLabel.Text = "Please enter your email/username and password.";
            return;
        }

        if (_userService.Login(username, password, out string message))
        {
            await DisplayAlert("Success", message, "OK");

            Application.Current!.Windows[0].Page =
                new NavigationPage(new MainPage());
        }
        else
        {
            MessageLabel.Text = message;
        }
    }

    private async void RegisterNav_Clicked(
        object sender, TappedEventArgs e)
    {
        await Navigation.PushAsync(new RegisterPage());
    }
}
