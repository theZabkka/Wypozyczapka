using Application.Models;
namespace Application.Pages;

public partial class RentBook : ContentPage
{
    public RentBook()
    {
        InitializeComponent();
        BindingContext = new RentBookModel();
    }

}
