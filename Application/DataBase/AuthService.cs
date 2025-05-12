using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataBase
{
    internal class AuthService
    {
        private const string AuthStateKey = "AuthState";
        private const string AuthUserIdKey = "LoggedInStudentId";
        public async Task<bool> IsAuthenticatedAsync()
        {
            var authState = Preferences.Default.Get<bool>(AuthStateKey, false);

            return authState;
        }
        public int? GetLoggedInStudentId()
        {
            if (!Preferences.Default.ContainsKey(AuthUserIdKey))
                return null;
            return Preferences.Default.Get<int>(AuthUserIdKey, 0);
        }
        public void Login(int studentId)
        {
            Preferences.Default.Set(AuthStateKey, true);
            Preferences.Default.Set("LoggedInStudentId", studentId);
        }

        public void Logout()
        {
            Preferences.Default.Remove(AuthStateKey);
            Preferences.Default.Remove(AuthUserIdKey);
        }
    }
}
