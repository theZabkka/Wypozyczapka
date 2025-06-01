namespace Application.Pages;
using Application.ViewModels;

public partial class RentSportItem : ContentPage
{
	public RentSportItem()
	{
		InitializeComponent();
        BindingContext = new RentSportItemModel();

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