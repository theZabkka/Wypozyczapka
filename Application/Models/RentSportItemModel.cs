using Application.DataBase;
using Application.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace Application.ViewModels
{
    public partial class RentSportItemModel : ObservableObject
    {
        private readonly LocalDBService _dbService;

        [ObservableProperty]
        ObservableCollection<SportItem> sportItems;

        public RentSportItemModel()
        {
            _dbService = new LocalDBService();
            LoadSportItemsAsync();
        }

        private async void LoadSportItemsAsync()
        {
            var items = await _dbService.GetAllSportItemsAsync();
            SportItems = new ObservableCollection<SportItem>(items);
        }

        [RelayCommand]
        private async Task RentSportItem(SportItem item)
        {
            if (item.IsBorrowed)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Info", "Ten przedmiot sportowy jest już wypożyczony", "OK");
                return;
            }

            item.IsBorrowed = true;
            await _dbService.UpdateSportItemAsync(item);

            await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Sukces", $"Wypożyczono: {item.Name}", "OK");
        }
    }
}