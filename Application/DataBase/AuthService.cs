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
        public async Task<bool> IsAuthenticatedAsync()
        {
            var authState = Preferences.Default.Get<bool>(AuthStateKey, false);

            return authState;
        }
        public void login()
        {
            Preferences.Default.Set<bool>(AuthStateKey, true);
        }
        public void logout()
        {
            Preferences.Default.Remove(AuthStateKey);
        }
    }
}
