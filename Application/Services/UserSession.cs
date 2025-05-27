using Application.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    
        public static class UserSession
        {
            public static int CurrentUserId { get; private set; }
            public static string CurrentUsername { get; private set; }

            public static void SetUser(int userId, string username = null)
            {
                CurrentUserId = userId;
                CurrentUsername = username;
            }

            public static void Clear()
            {
                CurrentUserId = 0;
                CurrentUsername = null;
            }

            internal static void SetFromAuthService(AuthService authService)
            {
                var userId = authService.GetLoggedInStudentId();
                if (userId.HasValue)
                {
                    CurrentUserId = userId.Value;
                    // Opcjonalnie można pobrać nazwę użytkownika z bazy – później
                }
            }
        }


    }


