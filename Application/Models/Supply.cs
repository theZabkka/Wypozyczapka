using SQLite;

namespace Application.Models
{
    public class Supply
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool IsBorrowed { get; set; }

        public string ImageSource { get; set; }
    }
}
