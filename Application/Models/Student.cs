using SQLite;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Models
{
    [Table("Student")]
    internal class Student
    {
        [PrimaryKey]
        [AutoIncrement]
        [NotNull]
        [Column("id")]
        public int Id { get; set; }

        [Required]
        [Column("StudentEmail")]
        public string Email { get; set; }
        [Required]
        [Column("StudentPassword")]
        public string Password { get; set; }

        [Required]
        [Column("userName")]
        public string Name { get; set; }

        [Column("isLoggedIn")]
        public bool IsLoggedIn { get; set; } = false;

    }
}
