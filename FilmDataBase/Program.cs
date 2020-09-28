using FilmDataBase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FilmDataBase
{
    class Program
    {

        static void Main(string[] args)
        {
          
            Start:
            Console.WriteLine("        ███████████████████████████████████████████████████████████████████████████   ");
            Console.WriteLine("        █▄─▄▄─█▄─▄█▄─▄███▄─▀█▀─▄███▄─▄▄▀██▀▄─██─▄─▄─██▀▄─██▄─▄─▀██▀▄─██─▄▄▄▄█▄─▄▄─█   ");
            Console.WriteLine("        ██─▄████─███─██▀██─█▄█─█████─██─██─▀─████─████─▀─███─▄─▀██─▀─██▄▄▄▄─██─▄█▀█   ");
            Console.WriteLine("        ▀▄▄▄▀▀▀▄▄▄▀▄▄▄▄▄▀▄▄▄▀▄▄▄▀▀▀▄▄▄▄▀▀▄▄▀▄▄▀▀▄▄▄▀▀▄▄▀▄▄▀▄▄▄▄▀▀▄▄▀▄▄▀▄▄▄▄▄▀▄▄▄▄▄▀   ");
            Console.WriteLine("\n");

            Console.WriteLine("      ------------------------------------------------------------------------------  ");
            Console.WriteLine("      | 1: Show All Titles |  2: Add New Movie |  3: Search By: |  4: Delete title |  ");
            Console.WriteLine("      ------------------------------------------------------------------------------  ");

            Back:
            string select = Console.ReadLine();

            switch (select)
            {
                case "1":
                    Console.Clear();
                    ManageDb.GetFullList();
                    Console.WriteLine("\nPress enter to get back");
                    Console.ReadLine();
                    Console.Clear();
                    goto Start;
 
                case "2":
                    Console.Clear();
                    Console.WriteLine("Write movie title, director and year:\n");
                    ManageDb.AddMovie(Console.ReadLine(), Console.ReadLine(), Convert.ToInt32(Console.ReadLine()));
                    Console.WriteLine("\nPress enter to get back");
                    Console.ReadLine();
                    Console.Clear();
                    goto Start;

                case "3":
                    Console.Clear();
                    Console.WriteLine("Search by: \n");
                    Console.WriteLine("1 - year, 2 - director\n");

                    bool selection = true;

                    while (selection)
                    {
                        string choice = Console.ReadLine();

                        if (choice == "1")
                        {
                            Console.Clear();
                            ManageDb.SearchByYear();
                            Console.WriteLine("\nPress enter to get back");
                            Console.ReadLine();
                            Console.Clear();
                            goto Start;
                        }
                        else if (choice == "2")
                        {
                            Console.Clear();
                            ManageDb.SearchByDirector();
                            Console.WriteLine("\nPress enter to get back");
                            Console.ReadLine();
                            Console.Clear();
                            goto Start;
                        }
                        else
                        {
                            selection = true;
                            Console.WriteLine("\nWrong input, please try again\n");
                        }
                    }
                    break;

                case "4":
                    {
                        Console.Clear();
                        ManageDb.DeleteEntry();
                        Console.WriteLine("\nPress enter to get back");
                        Console.ReadLine();
                        Console.Clear();
                        goto Start;
                    }

                default:
                    Console.Write("Wrong input. Please try again: ");
                    goto Back;
            }  
        } 
    }
}
