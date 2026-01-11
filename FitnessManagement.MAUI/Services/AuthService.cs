using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FitnessManagement.MAUI.Models;


namespace FitnessManagement.MAUI.Services
{
    public static class AuthService
    {
        // utilizator demo
        private static User _demoUser = new User
        {
            Username = "user",
            Password = "1234"
        };

        public static bool IsLoggedIn { get; private set; } = false;

        public static bool Login(string username, string password)
        {
            if (username == _demoUser.Username && password == _demoUser.Password)
            {
                IsLoggedIn = true;
                return true;
            }

            return false;
        }

        public static void Logout()
        {
            IsLoggedIn = false;
        }
    }
}
