using SQLite;

namespace Application.Models
{
    public class Book
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Author { get; set; }

        public string Title { get; set; }

        public bool IsBorrowed { get; set; }

        public string ImageSource { get; set; }
    }
}
