using System;
using System.Runtime.CompilerServices;

namespace Project1.Auth;
class Program
{
    public static void Main(string[] args)
    {
        MenuUser();
    }

    public static void MenuUser()
    {
        ManageUser manageUser = new ManageUser();

        manageUser.DataDummy("Rizki", "Atoi", "Rizki12345");
        manageUser.DataDummy("Atoi", "Rizki", "Rizki12345");
        manageUser.DataDummy("Golden", "Desert", "Golden12345");

        while (true)
        {
            Console.WriteLine("==========================");
            Console.WriteLine("\t Menu: \t");
            Console.WriteLine("==========================");
            Console.WriteLine("1. Create User");
            Console.WriteLine("2. Show Users");
            Console.WriteLine("3. Search User");
            Console.WriteLine("4. Login");
            Console.WriteLine("5. Exit");
            Console.Write("\nMasukkan Pilihan : ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();

                    while (true)
                    {
                        Console.WriteLine("--------------------------");
                        Console.WriteLine("      Create User");
                        Console.WriteLine("--------------------------");
                        Console.Write("Enter first name: ");
                        string firstName = Console.ReadLine();
                        Console.Write("Enter last name: ");
                        string lastName = Console.ReadLine();

                        Console.Write("Enter password: ");
                        string password = Console.ReadLine();
                        if (manageUser.IsValidPassword(password))
                        {
                            manageUser.AddUser(firstName, lastName, password);
                            break;
                        }
                        else
                        {
                            Console.WriteLine("\nPassword minimal 8 Karakter, Kapital, Angka !");
                        }
                    }
                    break;

                case "2":
                    Console.Clear();
                    manageUser.ShowUsers();

                    Console.WriteLine("--------------------------");
                    Console.WriteLine("1. Edit User");
                    Console.WriteLine("2. Delete User");
                    Console.WriteLine("3. Back");
                    Console.Write("Masukkan Pilihan : ");
                    string pilih = Console.ReadLine();

                    switch (pilih)
                    {
                        case "1":
                            while (true)
                            {
                                Console.WriteLine("--------------------------");
                                Console.Write("Masukkan Id yang ingin di edit : ");
                                if (int.TryParse(Console.ReadLine(), out int editId))
                                {
                                    User userToEdit = manageUser.FindUserById(editId);
                                    if (userToEdit != null)
                                    {
                                        Console.Write("Masukkan FirstName : ");
                                        string newFirstName = Console.ReadLine();
                                        Console.Write("Masukkan LastName : ");
                                        string newLastName = Console.ReadLine();
                                        Console.Write("Masukkan Password Baru : ");
                                        string newPassword = Console.ReadLine();

                                        if (manageUser.IsValidPassword(newPassword))
                                        {
                                            manageUser.editUser(editId, newFirstName, newLastName, newPassword);
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\nPassword minimal 8 Karakter, Kapital, Angka !");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nID tidak ditemukan. Silakan coba lagi.");
                                    }
                                }
                            }
                            break;

                        case "2":
                            Console.WriteLine("--------------------------");
                            Console.Write("Masukkan Id yang ingin di hapus : ");
                            if (int.TryParse(Console.ReadLine(), out int deleteId))
                            {
                                manageUser.deleteUser(deleteId);
                            }
                            break;
                        case "3":
                            continue;
                    }
                    break;

                case "3":
                    Console.Clear();
                    Console.Write("Masukkan Nama yang ingin dicari : ");
                    string searchName = Console.ReadLine();
                    manageUser.FindUserByName(searchName);
                    break;

                case "4":
                    Console.Clear();
                    Console.Write("Masukkan Username : ");
                    string username = Console.ReadLine();
                    Console.Write("Masukkan Password : ");
                    string pass = Console.ReadLine();
                    manageUser.AuthenticateUser(username, pass);
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
}
