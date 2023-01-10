﻿using System;
using System.Security.Principal;

namespace Bankenn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            User[] users = new User[3];
            users[0] = new User("admin", "admin", new string[] { "testkonto1", "testkonto2", "testkonto3" }, new double[] { 25000.55, 0.55, 0 });
            users[1] = new User("user1", "123456", new string[] { "Allkonto", "Sparkonto", "Investeringskonto" }, new double[] { 300.7, 2445, 0 });
            users[2] = new User("user2", "223344", new string[] { "Allkonto", "Aktier", "arrAB" }, new double[] { 7000, 34000, 700000.67 });

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to your bank, what would you like to do?");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");

                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Clear();
                    Console.Write("Enter your username: ");
                    string? inputUser = Console.ReadLine();
                    Console.Write("Enter your pin: ");
                    string? inputPass = Console.ReadLine();

                    userValidation(users, inputUser, inputPass);

                }
                if (choice == "3")
                {
                    Console.Clear();
                    break;
                }
                /*else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input! Try again!");
                    Console.ReadLine();
                }*/
            }

            void userValidation(User[] allUsers, string inputUser, string inputPass)
            {
                foreach (User user in allUsers)
                {
                    if (user._username == inputUser && user._password == inputPass)
                    {
                        userValidated(user);
                        break;
                    }
                }
            }

            void userValidated(User currentUser)
            {
                while (true)
                {
                    Console.Clear();
                    Console.WriteLine($"Hello {currentUser._username}, here are your accounts\n");

                    for (int i = 0; i < currentUser._accNames.Length; i++)
                    {
                        Console.WriteLine(currentUser._accNames[i] + ".\nThis account has: " + currentUser._balances[i] + " SEK on it.");
                        /*Console.WriteLine("==============================================================");*/
                    }
                    /*Console.WriteLine("1. List all accounts");*/
                    Console.WriteLine("\nWhat would you like to do?\n");
                    Console.WriteLine("2. Manage your accounts");
                    Console.WriteLine("5. Logout");

                    string? option = Console.ReadLine();

                   /* if (option == "1")
                    {
                        Console.Clear();
                        for (int i = 0; i < currentUser._accNames.Length; i++)
                        {
                            Console.WriteLine(currentUser._accNames[i] + ".\nThis account has: " + currentUser._balances[i] + " SEK on it.");
                            Console.WriteLine("==============================================================");
                        }
                        Console.WriteLine("\nPress anything to continiue...");
                        Console.ReadLine();
                    }*/
                    if (option == "2")
                    {
                        Console.Clear();
                        while (true)
                        {
                            Console.WriteLine("What would you like to do?\n");
                            Console.WriteLine("1. Deposit money to one of my accoutns");
                            Console.WriteLine("2. Transfer money between my accounts");
                            Console.WriteLine("3. Withdraw money from one of my accounts");
                            Console.WriteLine("4. Exit");

                            string? subOption = Console.ReadLine();

                            if (subOption == "1")
                            {
                                
                            }
                            if (subOption == "2")
                            {
                                Console.Clear();
                                transferMoney(currentUser);
                            }
                            if (subOption == "3")
                            {
                                Console.Clear();
                                withdrawMoney(currentUser);
                                Console.Clear();
                                break;
                            }
                            if (subOption == "4")
                            {
                                Console.Clear();
                                break;
                            }
                        }

                    }
                    if (option == "5")
                    {
                        /*Console.Clear();
                        Console.WriteLine("Have a great day!\n");
                        Console.WriteLine("Press any key to continiue...");
                        Console.ReadLine();*/
                        break;
                    }
                    /*if (option != "" || option != " ")
                    {
                        Console.Clear();
                        Console.WriteLine("Wrong input! Please select one of the options listed!");
                        Console.ReadLine();
                    }*/
                }
            }
            void withdrawMoney(User user)
            {
                while (true)
                {
                    Console.WriteLine($"Hello {user._username}. Please select an account below:");
                    // skriv en for loop som går från 0 till user._acccountNames.Length
                    // Skriv ut index + 1 följt av kontonamn förljt av kontoindex
                    for (int i = 0; i < user._accNames.Length; i++)
                    {
                        Console.WriteLine($"{i + 1}. {user._accNames[i]}: {user._balances[i]}");
                    }

                    // fråga om en summa du vlil ta ut
                    // fråga om pincod
                    // readline, läs in
                    // för att veta vilket konto användaren valde från user._accountNames och -balances, ta valet, konvertera till int och dra bort 1

                    Console.WriteLine("What account do you want to withdraw money from?\n USE , not . !!! \n");
                    Console.Write("===> ");
                    int withdrawOpt = int.Parse(Console.ReadLine());
                    int withdrawChoice = withdrawOpt - 1;

                    Console.WriteLine("How much money would you like to withdraw?");
                    Console.Write("===> ");
                    double withdrawSum = double.Parse(Console.ReadLine());

                    Console.WriteLine("Now enter your pin");
                    Console.Write("===> ");
                    string inputPin = Console.ReadLine();

                    if (inputPin == user._password)
                    {
                        if (user._balances[withdrawChoice] < withdrawSum)
                        {
                            Console.WriteLine("Insufficient funds!");
                            Console.ReadLine();
                            break;
                        }
                        else
                        {
                            user._balances[withdrawChoice] -= withdrawSum;
                            Console.WriteLine("Done! Press enter to continiue");
                            Console.ReadLine();
                            break;
                        }

                    }
                }
            }
            void transferMoney(User transferUser)
            {

            }
        }

        public class User
        {
            public string _username;
            public string _password;
            public string[] _accNames;
            public double[] _balances;

            public User(string username, string password, string[] accNmes, double[] balances)
            {
                _username = username;
                _password = password;
                _accNames = accNmes;
                _balances = balances;
            }
        }
    }
}