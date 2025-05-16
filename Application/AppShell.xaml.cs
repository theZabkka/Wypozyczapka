using Application.Pages;

namespace Application;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Rejestracja stron, które mają być nawigowane z kodu, ale nie widać ich w flyoucie
        Routing.RegisterRoute(nameof(RentBook), typeof(RentBook));
        Routing.RegisterRoute(nameof(RentSportItem), typeof(RentSportItem));
        Routing.RegisterRoute(nameof(RentSupply), typeof(RentSupply));
    }
}
