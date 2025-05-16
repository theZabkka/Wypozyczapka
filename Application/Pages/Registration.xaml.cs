using Application.DataBase;
using Application.Models;
using SQLite;

namespace Application.Views;

public partial class Registration : ContentPage
{
    private readonly LocalDBService _DbService;
    private readonly AuthService _authService;

    public Registration()
    {
        InitializeComponent();

        _authService = new AuthService();
        _DbService = new LocalDBService();

        // Inicjalizacja bazy danych
        _ = _DbService.InitializeDatabaseAsync();

        // Dodanie przyk³adowego u¿ytkownika
        _ = AddSampleDataAsync();
    }

    // Dodajemy przyk³adowego studenta (jeœli jeszcze nie istnieje)
    public async Task AddSampleDataAsync()
    {
        try
        {
            var existingUser = await _DbService.AuthenticateUserAsync("kakaNaKlate@gmail.com", "mamusiaPiotrka");
            if (existingUser == null)
            {
                var student = new Student
                {
                    Email = "kakaNaKlate@gmail.com",
                    Password = "mamusiaPiotrka",
                    Name = "Miko³aj"
                };
                await _DbService.AddStudentAsync(student);
            }
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
            _authService.Login(user.Id); // Zapis ID u¿ytkownika
            await Shell.Current.GoToAsync("//HomePage"); // lub NavigationPage(new HomePage());
        }
        else
        {
            await DisplayAlert("B³¹d", "Niepoprawny e-mail lub has³o", "OK");
        }
    }

    // Sprawdzenie czy u¿ytkownik jest ju¿ zalogowany
    protected override async void OnAppearing()
    {
        base.OnAppearing();

        if (await _authService.IsAuthenticatedAsync())
        {
            await Shell.Current.GoToAsync("//HomePage");
        }
    }
}
