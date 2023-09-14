using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1
{
    class GanjilGenap
    {
        //method menampilkan menu
        static void menu()
        {
            int pilihan; //deklarasi variabel digunakan menampung inputan pilihan
            int angka; //deklarasi variabel angka digunakan menampung inputan angka

            do
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("\tMENU GANJIL GENAP\t");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("1. Cek Ganjil Genap");
                Console.WriteLine("2. Print ganjil/genap (dengan limit)");
                Console.WriteLine("3. Exit");
                Console.WriteLine("-------------------------------------");
                Console.Write("Masukkan pilihan (1/2/3): ");

                // kondisi dimana Console menerima inputan dalam bentuk string dan mencoba dikonversi menjadi int
                if (int.TryParse(Console.ReadLine(), out pilihan))
                {
                    //kondisi untuk menentukan input pilihan yang akan dijalankan
                    switch (pilihan)
                    {
                        case 1: //case 1 akan dijalankan ketika inputan = 1
                            Console.Write("Masukkan angka yang ingin di cek : ");
                            if (int.TryParse(Console.ReadLine(), out angka)) //mengecek inputan yang diterima Console dan mencoba dikonfersi ke int
                            {
                                string result = EvenOddCheck(angka); //menyimpan hasil method EvenOddCheck ke variabel result
                                Console.WriteLine($"Angka {angka} = {result}\n");//menampilkan hasil
                            }
                            else
                            {
                                Console.WriteLine("Input tidak valid. Harap masukkan angka yang benar. \n");
                            }
                            break;

                        case 2:
                            Console.Write("Masukkan Ganjil / Genap : ");
                            string evenodd = Console.ReadLine().ToLower();
                            Console.Write("Masukkan Angka limit : ");
                            if (int.TryParse(Console.ReadLine(), out angka))
                            {
                                PrintEventOdd(angka, evenodd);
                            }
                            else
                            {
                                Console.WriteLine("limit tidak valid. Harap masukkan angka yang benar.\n");
                            }
                            break;

                        case 3:
                            Console.WriteLine("Program Selesai");
                            pilihan = 3;
                            break;
                        default:
                            Console.WriteLine("Pilihan tidak valid !\n"); //default akan dijalankan ketika inputan tidak sesuai dengan case 1 - 3
                            break;
                    }

                }
                else
                {
                    Console.WriteLine("Harap masukkan pilihan yang benar.");
                }
            } while (pilihan != 3); //perulangan akan berhenti ketika nilai pilihan tidak sama dengan 3
        }

        //untuk cek apakah inputan angka ganjil atau genap
        static string EvenOddCheck(int input)
        {
            /*kondisi untuk mengecek apakah inputan lebih dari 0*/
            if (input > 0)
            {
                if (input % 2 == 0) //untuk mengecek apakah inputan modulus 2 = 0 
                {
                    return "genap";
                }
                return "ganjil";
            }
            return "invalid, minimal input = 1 !!!\n";
        }

        static void PrintEventOdd(int limit, string choice)
        {
            // Menentukan langkah berdasarkan pilihan (genap/ganjil)
            int start;

            if (choice == "genap")
            {
                start = 2;
            }
            else if (choice == "ganjil")
            {
                start = 1;
            }
            else
            {
                Console.WriteLine("Input Pilihan tidak valid !\n");
                return; // Keluar dari metode jika limit tidak valid
            }

            if (limit < 1) //mengecek jika inputan limit < 1
            {
                Console.WriteLine($"Angka {choice} 1 - {limit}:");
                Console.WriteLine("Input Limit tidak valid !\n");
                return; // Keluar dari metode jika limit tidak valid
            }

            Console.WriteLine($"Angka {choice} 1 - {limit}:");
            for (int i = start; i <= limit; i += 2) //perulangan untuk menampilkan list angka sesuai inputan limit
            {
                Console.Write(i + ", ");
            }
            Console.WriteLine("\n");
        }


        public static void GanjilOrGenap()
        {
            menu();
        }

        /*        static void PrintEvenOdd3(int limit, string choice)
                {
                    if (limit < 0) // Limit tidak valid
                    {
                        Console.WriteLine($"Angka {choice} 1 - {limit}:");
                        Console.WriteLine("Input Limit tidak valid !");
                        return;
                    }

                    if (choice == "genap" || choice == "ganjil") //mengecek kondisi apakah choice = genap, fungsi ToLower agar inputan terbaca huruf kecil
                    {
                        Console.WriteLine("Angka ganjil 1 - " + limit + ":");
                        for (int i = 2; i <= limit; i += 2) //perulangan untuk menghasilkan angka genap dari 2 - (inputan limit)
                        {
                            Console.Write(i + ", ");
                        }
                        Console.WriteLine("\n");

                    }
                    else if (choice == "ganjil") //kondisi untuk mengecek  inputan choice = ganjil
                    {
                        Console.WriteLine("Angka ganjil 1 - " + limit + ":");
                        for (int i = 1; i <= limit; i += 2 || ) //perulangan untuk menghasilkan angka ganjil dari 1 - (inputan limit)
                        {
                            Console.Write(i + ", ");
                        }
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        Console.WriteLine("Input Pilihan tidak valid !");
                    }
                }
        */

        /*        static void PrintEventOdd(int limit, string choice)
                {
                    if (limit < 1) //cek jika inputan limit kurang dari 1
                    {
                        Console.WriteLine("Input Limit tidak valid !");
                        return;
                    }

                    //cek jika inputan tidak sama dengan genap dan tidak sama dengan ganjil
                    if (choice != "genap" && choice != "ganjil") 
                    {
                        Console.WriteLine("Input Pilihan tidak valid !");
                        return;
                    }

                    Console.WriteLine($"Angka {choice} 1 - {limit}:");

                    //melakukan perulangan dari 1 sampai <= inputan limit setiap perulangan akan bertambah i++
                    for (int i = 1; i <= limit; i++)
                    {
                        if ((choice == "genap" && i % 2 == 0) || (choice == "ganjil" && i % 2 != 0))
                        {
                            Console.Write(i + ", ");
                        }
                    }

                    Console.WriteLine("\n");

                }
        */
    }
}
