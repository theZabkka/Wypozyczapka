using Application.DataBase;
using Application.Messages; // 👈 dodaj to
using Application.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging; // 👈 dodaj to
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
            _ = LoadSportItemsAsync();
        }

        private async Task LoadSportItemsAsync()
        {
            var items = await _dbService.GetAllSportItemsAsync();
            SportItems = new ObservableCollection<SportItem>(items);
        }

        [RelayCommand]
        private async Task RentSportItem(SportItem item)
        {
            if (item == null)
                return;

            if (item.IsBorrowed)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert(
                    "Info", "Ten przedmiot sportowy jest już wypożyczony", "OK");
                return;
            }

            item.IsBorrowed = true;
            await _dbService.UpdateSportItemAsync(item);

            await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert(
                "Sukces", $"Wypożyczono: {item.Name}", "OK");

            await LoadSportItemsAsync();

            // 📨 Wyślij komunikat do MyRentalsViewModel (tak jak RentBookModel to robi)
            WeakReferenceMessenger.Default.Send(new BooksChangedMessage(true));
        }
    }
}