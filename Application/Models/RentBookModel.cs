using Application.DataBase;
using System;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Application.Models
{
    public partial class RentBookModel : ObservableObject
    {
        private readonly LocalDBService _dbService;

        [ObservableProperty]
        ObservableCollection<Book> books;

        public RentBookModel()
        {
            _dbService = new LocalDBService();
            LoadBooksAsync();
        }

        private async void LoadBooksAsync()
        {
            var allBooks = await _dbService.GetAllBooksAsync();
            Books = new ObservableCollection<Book>(allBooks);
        }

        [RelayCommand]
        private async Task RentBook(Book book)
        {
            if (book.IsBorrowed)
            {
                await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Info", "Ta książka jest już wypożyczona", "OK");
                return;
            }

            book.IsBorrowed = true;
            await _dbService.UpdateBookAsync(book);

            await Microsoft.Maui.Controls.Application.Current.MainPage.DisplayAlert("Sukces", $"Wypożyczono: {book.Title}", "OK");
        }
    }
}
