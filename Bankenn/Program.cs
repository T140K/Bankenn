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
                Console.WriteLine("Welcome, what would you like to do?");
                Console.WriteLine("1. Login");
                Console.WriteLine("2. Register");
                Console.WriteLine("3. Exit");

                string? choice = Console.ReadLine();

                if (choice == "1")
                {
                    Console.Clear();
                    Console.Write("Enter your username: ");
                    string? inputAcc = Console.ReadLine();
                    Console.Write("Enter your password: ");
                    string? inputPin = Console.ReadLine();

                    userValidation(users, inputUser, inputPass);

                }
                if (choice == "3")
                {
                    Console.Clear();
                    break;
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
                    Console.WriteLine("2. Enter a account");
                    Console.WriteLine("3. Make a new account");
                    Console.WriteLine("4. ");
                    Console.WriteLine("5. Logout");

                    string? option = Console.ReadLine();

                    if (option == "1")
                    {
                        Console.Clear();
                        for (int i = 0; i < currentUser._accNames.Length; i++)
                        {
                            Console.WriteLine("===============================");
                            Console.WriteLine(currentUser._accNames[i] + ". This account has: " + currentUser._balances[i] + " dollars on it.");
                            Console.WriteLine("===============================");
                        }
                    }
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

            public void GetInfo()
            {
                for (int i = 0; i > 3; i++)
                {
                    Console.WriteLine($"here is a user with the username {}");
                }
;

            }
        }
    }
}