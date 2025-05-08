using Application.DataBase;
using SQLite;

namespace Application.Views;

public partial class Registration : ContentPage 
{
    private readonly SQLiteAsyncConnection _connection;
    private readonly LocalDBService _DbService;
    private readonly AuthService _authService;
    public Registration()
	{
		InitializeComponent();
        _authService = new AuthService();
        _DbService = new LocalDBService();
        _ = AddSampleDataAsync();
        _DbService.InitializeDatabaseAsync();

    }
    public async Task AddSampleDataAsync()
    {
        try
        {
            var student = new Student
            {
                Email = "kakaNaKlate@gmail.com",
                Password = "mamusiaPiotrka",
                Name = "Miko³aj"
            };
            await _DbService.AddStudentAsync(student);
        }
        catch (Exception ex)
        {
            await DisplayAlert("SQLite ERROR", ex.ToString(), "OK");
        }
    }

    private async void LoginButton_Clicked(object sender, EventArgs e)
    {
        string email = EmailEntryField.Text?.Trim();
        string password = PasswordEntryField.Text?.Trim();

        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
        {
            await DisplayAlert("B³¹d", "Proszê podaæ e-mail i has³o", "OK");
            return;
        }

        var user = await _DbService.AuthenticateUserAsync(email, password);
        if (user != null)
        {
            _authService.login();
            await Shell.Current.GoToAsync("//HomePage");
        }
        else
        {
            await DisplayAlert("B³¹d", "Niepoprawny e-mail lub has³o", "OK");
        }
    }
}