using CommunityToolkit.Mvvm.ComponentModel;
using SQLite;

namespace Application.Models
{
    public partial class Book : ObservableObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [ObservableProperty]
        private string author;

        [ObservableProperty]
        private string title;
        public string Name => Title;


        [ObservableProperty]
        private bool isBorrowed;

        [ObservableProperty]
        private string imageSource;

        [ObservableProperty]
        private int borrowedBy;
    }
}