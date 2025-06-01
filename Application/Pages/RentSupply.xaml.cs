namespace Application.Pages;
using Application.ViewModels;


public partial class RentSupply : ContentPage
{
	public RentSupply()
	{
		InitializeComponent();
		BindingContext = new RentSupplyModel();
	}
    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(".."); // wraca do poprzedniej strony
    }
    private void OnMenuClicked(object sender, EventArgs e)
    {
        Shell.Current.FlyoutIsPresented = true;
    }
}