using Application.DataBase;
using Application.Messages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Application.Models
{
    public partial class RentBookModel : ObservableObject, IRecipient<BooksChangedMessage>
    {
        private readonly LocalDBService _dbService;

        [ObservableProperty]
        ObservableCollection<Book> books;

        public RentBookModel()
        {
            _dbService = new LocalDBService();
            WeakReferenceMessenger.Default.Register<BooksChangedMessage>(this);
            _ = LoadBooksAsync();
        }

        public async void Receive(BooksChangedMessage message)
        {
            if (message.Value)
            {
                await LoadBooksAsync();
            }
        }

        private async Task LoadBooksAsync()
        {
            var allBooks = await _dbService.GetAllBooksAsync();
            Microsoft.Maui.ApplicationModel.MainThread.BeginInvokeOnMainThread(() =>
            {
                Books = new ObservableCollection<Book>(allBooks);
            });
        }

        [RelayCommand]
        private async Task RentBook(Book book)
        {
            if (book == null)
                return;

            if (book.IsBorrowed)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Info", "Ta książka jest już wypożyczona", "OK");
                return;
            }

            book.IsBorrowed = true;
            await _dbService.UpdateBookAsync(book);

            await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Sukces", $"Wypożyczono: {book.Title}", "OK");

            await LoadBooksAsync();

            // Wyślij komunikat do innych VM o zmianie książek
            WeakReferenceMessenger.Default.Send(new BooksChangedMessage(true));
        }
    }
}