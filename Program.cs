﻿using System;

                    Console.WriteLine("--------------------------");
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
                    }
                    else
                    {
                        Console.WriteLine("\nPassword minimal 8 Karakter, Kapital, Angka !");
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