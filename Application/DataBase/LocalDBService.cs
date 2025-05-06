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
            _connection.CreateTableAsync<Student>();

        }
        public async Task<Student> AuthenticateUserAsync(String email, String password)
        {
            return await _connection.Table<Student>()
                .Where(c => c.Email == email && c.Password == password)
                .FirstOrDefaultAsync();
        }
    }
}
