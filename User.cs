using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    public class User
    {
        public int Id { get; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public User(int id, string firstName, string lastName, string password)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Username = GenerateUsername(firstName, lastName);
        }

        private string GenerateUsername(string firstName, string lastName)
        {
            // Mengambil dua huruf pertama dari nama depan dan nama belakang
            string firstTwoChars = firstName.Substring(0, Math.Min(2, firstName.Length));
            string lastTwoChars = lastName.Substring(0, Math.Min(2, lastName.Length));

            // Menggabungkan dua huruf dari nama depan dan nama belakang menjadi username
            string username = firstTwoChars + lastTwoChars;

            return username;
        }

    }
}
