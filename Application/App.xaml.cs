using Application.DataBase;
using Application.Services;

namespace Application
{
    public partial class App : IApplication
    {
        public App()
        {
            var authService = new AuthService();
            UserSession.SetFromAuthService(authService);

            MainPage = new AppShell();
        }

        
    }
}
