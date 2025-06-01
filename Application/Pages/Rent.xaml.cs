using Application.DataBase;
using Application.Models;
using Microsoft.Maui.Controls;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Application.Pages
{
    public partial class Rent : ContentPage
    {
        private readonly LocalDBService _dbService;
        public ICommand GoToBooksCommand { get; }
        public ICommand GoToSportCommand { get; }
        public ICommand GoToSupplyCommand { get; }

        public Rent()
        {
            InitializeComponent();
            _dbService = new LocalDBService();
            LoadData();

            GoToBooksCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(RentBook)));
            GoToSportCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(RentSportItem)));
            GoToSupplyCommand = new Command(async () => await Shell.Current.GoToAsync(nameof(RentSupply)));


            BindingContext = this;
        }

        private async void LoadData()
        {
            await _dbService.InitializeDatabaseAsync();
            await _dbService.SeedSampleDataAsync();
            var books = await _dbService.GetAvailableBooksAsync();
            var sports = await _dbService.GetAvailableSportItemsAsync();
            var supplies = await _dbService.GetAvailableSuppliesAsync();

            //BooksCollection.ItemsSource = books;
            //SportCollection.ItemsSource = sports;
            //SupplyCollection.ItemsSource = supplies;
        }
        private void OnMenuClicked(object sender, EventArgs e)
        {
            Shell.Current.FlyoutIsPresented = true;
        }

        //private async void OnBorrowBookClicked(object sender, EventArgs e)
        //{
        //    if (sender is Button button && button.CommandParameter is int id)
        //    {
        //        await _dbService.BorrowBookAsync(id);
        //        LoadData();
        //    }
        //}

        //private async void OnBorrowSportClicked(object sender, EventArgs e)
        //{
        //    if (sender is Button button && button.CommandParameter is int id)
        //    {
        //        await _dbService.BorrowSportItemAsync(id);
        //        LoadData();
        //    }
        //}

        //private async void OnBorrowSupplyClicked(object sender, EventArgs e)
        //{
        //    if (sender is Button button && button.CommandParameter is int id)
        //    {
        //        await _dbService.BorrowSupplyAsync(id);
        //        LoadData();
        //    }
        //}
    }
}
