using Application.DataBase;
using Application.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Application.Models;

namespace Application.ViewModels
{
    public partial class MyRentalsViewModel : ObservableObject, IRecipient<BooksChangedMessage>
    {
        private readonly LocalDBService _dbService;

        [ObservableProperty]
        ObservableCollection<object> borrowedItems;

        public MyRentalsViewModel()
        {
            _dbService = new LocalDBService();
            WeakReferenceMessenger.Default.Register<BooksChangedMessage>(this);
            _ = LoadBorrowedItemsAsync();
        }

        public async void Receive(BooksChangedMessage message)
        {
            if (message.Value)
            {
                await LoadBorrowedItemsAsync();
            }
        }

        [RelayCommand]
        public async Task ReturnItemAsync(object item)
        {
            if (item == null)
                return;

            switch (item)
            {
                case Book book:
                    book.IsBorrowed = false;
                    await _dbService.UpdateBookAsync(book);
                    break;
                case SportItem sportItem:
                    sportItem.IsBorrowed = false;
                    await _dbService.UpdateSportItemAsync(sportItem);
                    break;
                case Supply supply:
                    supply.IsBorrowed = false;
                    await _dbService.UpdateSupplyAsync(supply);
                    break;
            }

            await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Sukces", "Przedmiot został zwrócony", "OK");

            await LoadBorrowedItemsAsync();

            // Wyślij komunikat do innych VM o zmianie
            WeakReferenceMessenger.Default.Send(new BooksChangedMessage(true));
        }

        public async Task LoadBorrowedItemsAsync()
        {
            var items = await _dbService.GetAllBorrowedItemsAsync();
            Microsoft.Maui.ApplicationModel.MainThread.BeginInvokeOnMainThread(() =>
            {
                BorrowedItems = new ObservableCollection<object>(items);
            });
        }
    }
}