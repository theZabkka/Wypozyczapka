using Application.DataBase;
using Application.Models;
using Application.Messages; // 👈 dodano
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging; // 👈 dodano
using Microsoft.Maui.ApplicationModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public partial class RentSupplyModel : ObservableObject
    {
        private readonly LocalDBService _dbService;

        [ObservableProperty]
        ObservableCollection<Supply> supplies;

        public RentSupplyModel()
        {
            _dbService = new LocalDBService();
            _ = LoadSuppliesAsync();
        }

        private async Task LoadSuppliesAsync()
        {
            var list = await _dbService.GetAllSuppliesAsync();
            MainThread.BeginInvokeOnMainThread(() =>
            {
                Supplies = new ObservableCollection<Supply>(list);
            });
        }

        [RelayCommand]
        private async Task RentSupply(Supply supply)
        {
            if (supply == null)
                return;

            if (supply.IsBorrowed)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert(
                    "Info", "Ten przybór jest już wypożyczony", "OK");
                return;
            }

            supply.IsBorrowed = true;
            await _dbService.UpdateSupplyAsync(supply);

            await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert(
                "Sukces", $"Wypożyczono: {supply.Name}", "OK");

            await LoadSuppliesAsync();

            // 📨 Wysyłanie wiadomości do MyRentalsViewModel
            WeakReferenceMessenger.Default.Send(new BooksChangedMessage(true));
        }
    }
}