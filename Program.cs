// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Transactions;
namespace ConsoleApp1
{
    class Account
    {

        private string ID;
        public double Balance { set; get; }

        public Account(string id) => this.ID = id;
        public void addBalance(double balance)
        {
            this.Balance += balance;
        }
        public void currentBalance() { Console.WriteLine($"your current blance is : {this.Balance}"); }
        public void withdrawAmount(double balance)
        {
            this.Balance -= balance;
        }
    }
    class User : Account
    {
        public string Name { set; get; }
        public string Password { set; get; }
        public string Id { set; get; }

        public User(string id,string name,string password) : base(id)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
        }

    }
    internal class Program

    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> accounts = new Dictionary<string, string>();
            List<User> users = new List<User>();
            User currentUser = new User("","","");

            Console.WriteLine($"Welcome to the Bank of Intrest :)");
            Console.WriteLine();
            string name = "Vijay";
            string userId;
            string password;
            users.Add(new User("Vijay","Goat","Trailer"));
            users.Add(new User("Ajith", "VM", "Teaser"));
            User use;
            foreach(User user in users)
            {
                if(user.Id.Equals(name))
                {
                    Console.WriteLine("Found");
                    use = user;
                    testing(use);
                    
                }
                Console.WriteLine(user.Name +" "+user.Id+" "+user.Balance);
            }
            
            bool chk = false;
            bool check = false;
            while (chk)
            {
                Console.WriteLine("----------------Enter -----------------\n 1 -> to open bank account \n 2 -> to Login to your Existing account \n 3 -> to Close Application");
                int options = Convert.ToInt32(Console.ReadLine());
                switch (options)
                {
                    case 1:
                        Console.WriteLine("Enter your Name ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter UserId i.e Unique for every customer..");
                        userId = Console.ReadLine();
                        if (accounts.ContainsKey(userId))
                        {
                            Console.WriteLine("Sorry User already Exist!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Enter password");
                            password = Console.ReadLine();
                            Console.WriteLine("Account Created successfully");
                            accounts.Add(userId, password);
                            users.Add(new User(userId,name,password));
                            check = true;
                            chk = false;
                        }

                        break;
                    case 2:
                        Console.WriteLine("Enter your userId");
                        userId = Console.ReadLine();
                        Console.WriteLine("Enter your password");
                        password = Console.ReadLine();
                        if (!accounts.ContainsKey(userId))
                        {
                            Console.WriteLine("User Not Exist \n check your User_Id and Password again!");
                            chk = false;
                            break;

                        }

                        else if (accounts[userId] != password)
                        {
                            Console.WriteLine("Check your password and try again!");
                            chk = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Password Matched Logged in successfully :)");
                            Console.WriteLine("=========================X=====================");
                            foreach (User user in users)
                            {
                                if (userId == user.Id)
                                {
                                    currentUser = user;
                                    currentUser.Balance = user.Balance;
                                }
                            }
                            chk = false;
                            check = true;
                        }
                        break;
                    case 3:
                        chk = false;
                        break;
                    default:
                        Console.WriteLine("Enter Valid entries!");
                        break;
                }
                while (check)
                {
                    Console.WriteLine($"Hey {currentUser.Name}, Welcome to the Bank of Interest!\n Enter\n 1 -> For Deposit \n 2 -> to view balance\n 3 -> For Withdrawl \n 4 -> to Exit");
                    Console.WriteLine("----------------Enter your option Here--------------");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter the amount to deposit ");
                            double amount = Convert.ToDouble(Console.ReadLine());
                            currentUser.addBalance(amount);
                            Console.WriteLine($"Cash deposited! current Balance : ${currentUser.Balance}");
                            currentUser.currentBalance();
                            Console.WriteLine("===========================X============================");
                            break;
                        case 2:
                            currentUser.currentBalance();
                            break;
                        case 3:
                            Console.WriteLine("Enter the amount to withdraw...");
                            double wamount = Convert.ToDouble(Console.ReadLine());
                            if (wamount > currentUser.Balance)
                            {
                                Console.WriteLine($"The entered sum is greater than your current balance your balance is ${currentUser.Balance}");
                                break;
                            }
                            else
                            {
                                currentUser.withdrawAmount(wamount);
                                Console.WriteLine($"Cash withdrawl is successfull and your current balance is {currentUser.Balance}");
                                Console.WriteLine("=========================X================================");
                            }
                            break;
                        case 4:
                            check = false;
                            chk = true;
                            break;
                        default:
                            Console.WriteLine("Enter the appropriate Values");
                            break;

                    }
                }

            }


        }
        public static void testing(User user)
        {
            Console.WriteLine(user.Password);
        }

    }
}


