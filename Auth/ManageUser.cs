using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Project1.Auth;

public class ManageUser
{
    public List<User> users = new List<User>();

    public void AddUser(string firstName, string lastName, string password)
    {

        //validasi inputan kosong
        if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(lastName) || string.IsNullOrWhiteSpace(password))
        {
            Console.WriteLine("\nInput tidak valid. Pastikan semua kolom diisi !\n");
            return; // Jika input tidak valid, keluar dari metode.
        }

        int nextId = users.Count + 1; // Menentukan ID berikutnya
        User newUser = new User(nextId, firstName, lastName, password, users);

        users.Add(newUser); // Menambahkan pengguna ke dalam koleksi
        Console.WriteLine("Data user berhasil dibuat !!!\n");
        Console.WriteLine("--------------------");
        ShowUsers();
    }

    public void DataDummy(string firstName, string lastName, string password) //pembuatan data dummy
    {
        int nextId = users.Count + 1; // Menentukan ID berikutnya
        User newUser = new User(nextId, firstName, lastName, password, users);

        users.Add(newUser);
    }

    public void ShowUsers()
    {
        Console.WriteLine("==========================");
        Console.WriteLine("     Daftar Pengguna");
        Console.WriteLine("==========================\n");

        foreach (User user in users)
        {
            Console.WriteLine($"ID: {user.Id} \nNama: {user.FirstName} {user.LastName} \nUsername: {user.Username}\nPassword : {user.Password}\n");
        }
    }

    public bool IsValidPassword(string password)
    {
        // Memeriksa panjang minimal 8 karakter.
        if (password.Length < 8)
        {
            return false;
        }

        // Memeriksa setidaknya satu huruf kapital.
        bool hasUpperCase = false;
        // Memeriksa setidaknya satu angka.
        bool hasDigit = false;
        foreach (char c in password)
        {
            if (char.IsUpper(c))
            {
                hasUpperCase = true;
            }
            else if (char.IsDigit(c))
            {
                hasDigit = true;
            }
        }
        // Password valid jika memenuhi semua persyaratan.
        return hasUpperCase && hasDigit;
    }

    public void FindUserByName(string fullname)
    {
        // Mencari pengguna yang cocok berdasarkan nama yang mengandung kata kunci
        var searchUser = users.Where(u => Regex.IsMatch(u.FirstName, fullname, RegexOptions.IgnoreCase) ||
                                          Regex.IsMatch(u.LastName, fullname, RegexOptions.IgnoreCase) ||
                                          Regex.IsMatch(u.Username, fullname, RegexOptions.IgnoreCase)).ToList();

        if (searchUser.Count == 0)
        {
            Console.WriteLine("Tidak ada pengguna yang cocok dengan kata kunci yang diberikan !");
        }
        else
        {
            Console.WriteLine("--------------------------");
            foreach (var item in searchUser)
            {
                Console.WriteLine($"\nNama : {item.FirstName} {item.LastName}");
                Console.WriteLine($"Username : {item.Username}");
                Console.WriteLine($"Password : {item.Password}");
            }
        }
    }

    public User FindUserById(int id)
    {
        return users.FirstOrDefault(u => u.Id == id);
    }

    public void editUser(int id, string newFirstName, string newLastName, string newPassword)
    {
        User userEdit = FindUserById(id);

        //validasi inputan kosong
        if (string.IsNullOrWhiteSpace(newFirstName) || string.IsNullOrWhiteSpace(newLastName) || string.IsNullOrWhiteSpace(newPassword))
        {
            Console.WriteLine("\nInput tidak valid. Pastikan semua kolom diisi !\n");
            return; // Jika input tidak valid, keluar dari metode.
        }

        userEdit.FirstName = newFirstName;
        userEdit.LastName = newLastName;
        userEdit.Password = newPassword;

        Console.WriteLine($"\nData pengguna dengan ID {id} telah diubah !\n");
    }

    public void deleteUser(int id)
    {
        User userDelete = users.FirstOrDefault(u => u.Id == id);
        if (userDelete != null)
        {
            users.Remove(userDelete);
            Console.WriteLine($"Data dengan id {id} berhasil dihapus ! \n");
        }
        else
        {
            Console.WriteLine($"Data dengan id {id} tidak ada !");
        }
    }

    public void AuthenticateUser(string username, string password)
    {
        var cekUser = users.FirstOrDefault(u => u.Username == username && u.Password == password);
        if (cekUser != null && cekUser.Password == password)
        {
            Console.WriteLine("\nLogin berhasil!");
            GanjilGenap.GanjilOrGenap();
        }
        else
        {
            Console.WriteLine("\nLogin gagal. Periksa username dan password Anda.");

        }
    }
}