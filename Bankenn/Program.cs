using System;
using System.Security.Principal;

namespace Bankenn
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            User[] users = new User[3];
            users[0] = new User("admin", "admin", new string[] { "testkonto1", "testkonto2", "testkonto3" }, new int[] { 1234, 12345, 123456 }, new double[] { 25000.55, 0.55, 0 });
            users[1] = new User("user1", "password1", new string[] { "Allkonto", "Sparkonto", "Investeringskonto" }, new int[] { 2244, 3312, 4242 }, new double[] { 300.7, 2445, 0 });
            users[2] = new User("user2", "password2", new string[] { "Allkonto", "Aktier", "arrAB" }, new int[] { 1231, 1231, 1231 }, new double[] { 7000, 34000, 700000.67 });

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
                    Console.Write("Enter your password: ");
                    string? inputPass = Console.ReadLine();

                    userValidation(users, inputUser, inputPass);

                }
                if (choice == "3")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Wrong input! Try again!");
                    Console.ReadLine();
                }
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
                    Console.WriteLine($"Hello {currentUser._username}, what would you like to do?\n");
                    Console.WriteLine("1. List all accounts");
                    Console.WriteLine("2. Manage your accounts");
                    Console.WriteLine("5. Logout");

                    string? option = Console.ReadLine();

                    if (option == "1")
                    {
                        Console.Clear();
                        for (int i = 0; i < currentUser._accNames.Length; i++)
                        {
                            Console.WriteLine(currentUser._accNames[i] + ".\nThis account has: " + currentUser._balances[i] + " SEK on it.");
                            Console.WriteLine("==============================================================");
                        }
                        Console.WriteLine("\nPress anything to continiue...");
                        Console.ReadLine();
                    }
                    if (option == "2")
                    {
                        Console.Clear();
                        while (true)
                        {
                            Console.WriteLine("What would you like to do?\n");
                            Console.WriteLine("1. Deposit money to one of my accoutns");
                            Console.WriteLine("2. Transfer money between my accounts");
                            Console.WriteLine("3. Withdraw money from one of my account");
                            Console.WriteLine("4. Exit");

                            string? subOption = Console.ReadLine();

                            if (subOption == "1")
                            {
                                //det blir enklare om jag har en metod som validate inputs för accs istället för att ha samma kod om och om igen
                                Console.Clear();
                                Console.WriteLine("Log in to the account you want to deposit from");

                                Console.Write("Account name: ");
                                string inputAcc = Console.ReadLine();

                                Console.Write("Account pin: ");
                                int inputPin = int.Parse(Console.ReadLine());

                                accInfoValidation(users, inputAcc, inputPin);
                            }
                            if (subOption == "2")
                            {
                                Console.Clear();

                            }
                            if (subOption == "3")
                            {
                                Console.Clear();

                            }
                            if (subOption == "4")
                            {
                                Console.Clear();
                                break;
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Wrong input!");
                                Console.ReadLine();
                            }
                        }

                    }
                    if (option == "5")
                    {
                        Console.Clear();
                        Console.WriteLine("Have a great day!\n");
                        Console.WriteLine("Press any key to continiue...");
                        Console.ReadLine();
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
            void accInfoValidation(User[] allAcc, string inputAcc, int inputPin)
            {
                foreach (User user in allAcc)
                {
                    
                }
            }
        }

        public class User
        {
            public string _username;
            public string _password;
            public string[] _accNames;
            public int[] _pins;
            public double[] _balances;

            public User(string username, string password, string[] accNmes, int[] pins, double[] balances)
            {
                _username = username;
                _password = password;
                _accNames = accNmes;
                _pins = pins;
                _balances = balances;
            }
        }
    }
}