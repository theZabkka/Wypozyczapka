using Application.Models;
using Microsoft.Maui.Controls;

namespace Application.Pages
{
    public partial class RentBook : ContentPage
    {
        public RentBook()
        {
            InitializeComponent();
            BindingContext = new RentBookModel();
        }

        private void OnMenuClicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = true;
        }

        private async void OnBackClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }
    }
}

