using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataBase
{
    [SQLite.Table("Student")]
    internal class Student
    {
        [PrimaryKey]
        [AutoIncrement]
        [NotNull]
        [SQLite.Column("id")]
        public int Id { get; set; }

        [Required]
        [SQLite.Column("StudentEmail")]
        public string Email { get; set; }
        [Required]
        [SQLite.Column("StudentPassword")]
        public string Password { get; set; }

        [Required]
        [SQLite.Column("userName")]
        public string Name { get; set; }

        [SQLite.Column("isLoggedIn")]
        public bool IsLoggedIn { get; set; } = false;

    }
}
