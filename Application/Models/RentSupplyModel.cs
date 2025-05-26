using Application.DataBase;
using Application.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

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
            LoadSuppliesAsync();
        }

        private async void LoadSuppliesAsync()
        {
            var list = await _dbService.GetAllSuppliesAsync();
            Supplies = new ObservableCollection<Supply>(list);
        }

        [RelayCommand]
        private async Task RentSupply(Supply supply)
        {
            if (supply.IsBorrowed)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Info", "Ten przybór jest już wypożyczony", "OK");
                return;
            }

            supply.IsBorrowed = true;
            await _dbService.UpdateSupplyAsync(supply);

            await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Sukces", $"Wypożyczono: {supply.Name}", "OK");
        }
    }
}