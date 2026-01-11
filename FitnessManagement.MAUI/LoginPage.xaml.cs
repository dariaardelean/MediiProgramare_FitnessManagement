using FitnessManagement.MAUI.Services;
namespace FitnessManagement.MAUI;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
	}

    private async void OnLoginClicked(object sender, EventArgs e)
    {
        var username = UsernameEntry.Text;
        var password = PasswordEntry.Text;

        if (AuthService.Login(username, password))
        {
            await DisplayAlert("Succes", "Login reușit", "OK");
            await Shell.Current.GoToAsync("//MainPage");
        }
        else
        {
            await DisplayAlert("Eroare", "Username sau parolă greșită", "OK");
        }
    }
}