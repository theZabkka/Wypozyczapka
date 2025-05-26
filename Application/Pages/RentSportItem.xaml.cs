namespace Application.Pages;
using Application.ViewModels;

public partial class RentSportItem : ContentPage
{
	public RentSportItem()
	{
		InitializeComponent();
        BindingContext = new RentSportItemModel();

    }
}