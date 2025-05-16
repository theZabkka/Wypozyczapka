using Application.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataBase
{
    internal class LocalDBService
    {
        private const string DB_NAME = "local_db.db3";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDBService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
        }
        public async Task InitializeDatabaseAsync()
        {
            await _connection.CreateTableAsync<Student>();
            await _connection.CreateTableAsync<Book>();
            await _connection.CreateTableAsync<Supply>();
            await _connection.CreateTableAsync<SportItem>();

        }

        public async Task<Student> AuthenticateUserAsync(String email, String password)
        {
            return await _connection.Table<Student>()
                .Where(c => c.Email == email && c.Password == password)
                .FirstOrDefaultAsync();
        }
        public async Task AddStudentAsync(Student student)
        {
            await _connection.InsertAsync(student);
        }
        public async Task AddBookAsync(Book book)
        {
            await _connection.InsertAsync(book);
        }

        public async Task<List<Book>> GetAvailableBooksAsync()
        {
            return await _connection.Table<Book>()
                .Where(b => !b.IsBorrowed)
                .ToListAsync();
        }

        public async Task BorrowBookAsync(int bookId)
        {
            var book = await _connection.FindAsync<Book>(bookId);
            if (book != null)
            {
                book.IsBorrowed = true;
                await _connection.UpdateAsync(book);
            }
        }

        public async Task ReturnBookAsync(int bookId)
        {
            var book = await _connection.FindAsync<Book>(bookId);
            if (book != null)
            {
                book.IsBorrowed = false;
                await _connection.UpdateAsync(book);
            }
        }

        // SPORT ITEMS

        public async Task AddSportItemAsync(SportItem item)
        {
            await _connection.InsertAsync(item);
        }

        public async Task<List<SportItem>> GetAvailableSportItemsAsync()
        {
            return await _connection.Table<SportItem>()
                .Where(i => !i.IsBorrowed)
                .ToListAsync();
        }

        public async Task BorrowSportItemAsync(int itemId)
        {
            var item = await _connection.FindAsync<SportItem>(itemId);
            if (item != null)
            {
                item.IsBorrowed = true;
                await _connection.UpdateAsync(item);
            }
        }

        public async Task ReturnSportItemAsync(int itemId)
        {
            var item = await _connection.FindAsync<SportItem>(itemId);
            if (item != null)
            {
                item.IsBorrowed = false;
                await _connection.UpdateAsync(item);
            }
        }

        // SUPPLIES

        public async Task AddSupplyAsync(Supply supply)
        {
            await _connection.InsertAsync(supply);
        }

        public async Task<List<Supply>> GetAvailableSuppliesAsync()
        {
            return await _connection.Table<Supply>()
                .Where(s => !s.IsBorrowed)
                .ToListAsync();
        }

        public async Task BorrowSupplyAsync(int supplyId)
        {
            var supply = await _connection.FindAsync<Supply>(supplyId);
            if (supply != null)
            {
                supply.IsBorrowed = true;
                await _connection.UpdateAsync(supply);
            }
        }

        public async Task ReturnSupplyAsync(int supplyId)
        {
            var supply = await _connection.FindAsync<Supply>(supplyId);
            if (supply != null)
            {
                supply.IsBorrowed = false;
                await _connection.UpdateAsync(supply);
            }
        }

        public async Task SeedSampleDataAsync()
        {
            // Dodaj książki, jeśli nie istnieją
            var books = await _connection.Table<Book>().ToListAsync();
            if (books.Count == 0)
            {
                var sampleBooks = new List<Book>
                {
                    new Book { Title = "Lalka", Author = "Bolesław Prus", IsBorrowed = false },
                    new Book { Title = "Zbrodnia i kara", Author = "Fiodor Dostojewski", IsBorrowed = false },
                    new Book { Title = "Pan Tadeusz", Author = "Adam Mickiewicz", IsBorrowed = false },
                    new Book { Title = "Harry Potter", Author = "J.K. Rowling", IsBorrowed = false },
                    new Book { Title = "Wiedźmin", Author = "Andrzej Sapkowski", IsBorrowed = false },
                    new Book { Title = "Mały Książę", Author = "Antoine de Saint-Exupéry", IsBorrowed = false },
                    new Book { Title = "Hobbit", Author = "J.R.R. Tolkien", IsBorrowed = false },
                    new Book { Title = "Opowieść wigilijna", Author = "Charles Dickens", IsBorrowed = false },
                    new Book { Title = "Duma i uprzedzenie", Author = "Jane Austen", IsBorrowed = false },
                    new Book { Title = "1984", Author = "George Orwell", IsBorrowed = false }
                };
                await _connection.InsertAllAsync(sampleBooks);

            }
            var sports = await _connection.Table<SportItem>().ToListAsync();
            if (sports.Count == 0)
            {
                var sampleSports = new List<SportItem>
    {
                    new SportItem { Name = "Piłka nożna", IsBorrowed = false },
                    new SportItem { Name = "Piłka koszykowa", IsBorrowed = false },
                    new SportItem { Name = "Skakanka", IsBorrowed = false },
                    new SportItem { Name = "Piłka siatkowa", IsBorrowed = false },
                    new SportItem { Name = "Rakieta tenisowa", IsBorrowed = false },
                    new SportItem { Name = "Piłeczki pingpongowe", IsBorrowed = false },
                    new SportItem { Name = "Hula-hop", IsBorrowed = false },
                    new SportItem { Name = "Kij do unihokeja", IsBorrowed = false },
                    new SportItem { Name = "Szachy", IsBorrowed = false },
                    new SportItem { Name = "Zestaw do badmintona", IsBorrowed = false }
    };
                await _connection.InsertAllAsync(sampleSports);
            }
            var supplies = await _connection.Table<Supply>().ToListAsync();
            if (supplies.Count == 0)
            {
                var sampleSupplies = new List<Supply>
    {
        new Supply { Name = "Kalkulator", IsBorrowed = false },
        new Supply { Name = "Linijka", IsBorrowed = false },
        new Supply { Name = "Cyrkiel", IsBorrowed = false },
        new Supply { Name = "Ekierka", IsBorrowed = false },
        new Supply { Name = "Blok techniczny", IsBorrowed = false },
        new Supply { Name = "Nożyczki", IsBorrowed = false },
        new Supply { Name = "Taśma klejąca", IsBorrowed = false },
        new Supply { Name = "Zszywacz", IsBorrowed = false },
        new Supply { Name = "Dziurkacz", IsBorrowed = false },
        new Supply { Name = "Marker", IsBorrowed = false }
    };
                await _connection.InsertAllAsync(sampleSupplies);
            }

        }
    
    public async Task<List<Book>> GetAllBooksAsync()
        {
            return await _connection.Table<Book>().ToListAsync();
        }

        public async Task UpdateBookAsync(Book book)
        {
            await _connection.UpdateAsync(book);
        }
    }
}
