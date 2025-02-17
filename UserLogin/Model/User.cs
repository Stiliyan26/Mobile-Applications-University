using System;
using System.Data;
using Welcome.Others;

namespace Welcome.Model
{
    public class User
    {
        public string Names { get; set; }
        public string Password { get; set; }
        public UserRolesEnum Role { get; set; }

        public User() { }

        public User(string names, string password, UserRolesEnum role)
        {
            Names = names;
            Password = password;
            Role = role;
        }

        public override string ToString()
        {
            return $"User: {Names}, Role: {Role}";
        }
    }
}
