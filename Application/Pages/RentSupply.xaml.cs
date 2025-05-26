namespace Application.Pages;
using Application.ViewModels;


public partial class RentSupply : ContentPage
{
	public RentSupply()
	{
		InitializeComponent();
		BindingContext = new RentSupplyModel();
	}
}