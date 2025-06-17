using Application.ViewModels;

namespace Application.Pages
{
    public partial class MyRentals : ContentPage
    {
        public MyRentals()
        {
            InitializeComponent();
            BindingContext = new MyRentalsViewModel(); // ← kluczowe
        }
        private void OnMenuClicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = true;
        }
    }
}