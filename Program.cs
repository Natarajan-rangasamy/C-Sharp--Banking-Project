// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
using System.Transactions;
namespace ConsoleApp1
{
    class Account 
    {
        public string Name { set; get; }
        public string Password { set; get; }
        private int ID;

        public Account(int id) => this.ID = id;



    }
    class User
    {
        public int Id { set; get; }
        public double Balance { set; get; }
        public User (int ID)
        {
            this.Id = ID;
        }
        public void addBalance(double balance)
        {
            this.Balance +=  balance;
        }
        public void currentBalance() { Console.WriteLine($"your current blance is : {this.Balance}");  }
        public void withdrawAmount(double balance)
        {
            this.Balance -=  balance;
        }
    }
    internal class Program

{
    public static void Main(string[] args)
    {
        User user = new User(0);
        Dictionary<string,string> accounts = new Dictionary<string,string>();
        
        Console.WriteLine("Welcome to the Bank of Intrest :)");
        Console.WriteLine();
            string name;
            string userId;
            string password;
            Console.WriteLine("----------------Enter -----------------\n 1 -> to open bank account \n 2 -> to Login to your Existing account \n 3 -> to Close Application");
            int options = Convert.ToInt32(Console.ReadLine());
            bool chk = true;
            bool check = false;
            while (chk) {

                switch (options) {
                    case 1:
                        Console.WriteLine("Enter your Name ");
                        name = Console.ReadLine();
                        Console.WriteLine("Enter UserId i.e Unique for every customer..");
                        userId = Console.ReadLine();
                        Console.WriteLine("Enter password");
                        password = Console.ReadLine();
                        Console.WriteLine("Account Created successfully");
                        accounts.Add(userId, password);
                        check = true;
                        chk = false;
                        break;
                    case 2:
                        Console.WriteLine("Enter your userId");
                        userId= Console.ReadLine();
                        Console.WriteLine("Enter your password");
                        password= Console.ReadLine();
                        if (!accounts.ContainsKey(userId))
                        {
                            Console.WriteLine("User Not Exist \n check your User_Id and Password again!");
                            chk = false;
                            break;
                            
                        }
                        
                        else if (accounts[userId] != password) { 
                            Console.WriteLine("Check your password and try again!");
                            chk = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Password Matched Logged in successfully :)");
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
                    Console.WriteLine("Enter\n 1 -> For Deposit \n 2 -> to view balance\n 3 -> For Withdrawl \n 4 -> to Exit");
                    Console.WriteLine("----------------Enter your option Here--------------");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter the amount to deposit ");
                            double amount = Convert.ToDouble(Console.ReadLine());
                            user.addBalance(amount);
                            Console.WriteLine($"Cash deposited! current Balance : ${user.Balance}");
                            user.currentBalance();
                            break;
                        case 2:
                            user.currentBalance();
                            break;
                        case 3:
                            Console.WriteLine("Enter the amount to withdraw...");
                            double wamount = Convert.ToDouble(Console.ReadLine());
                            if (wamount > user.Balance)
                            {
                                Console.WriteLine($"The entered sum is greater than your current balance your balance is ${user.Balance}");
                                break;
                            }
                            else
                            {
                                user.withdrawAmount(wamount);
                                Console.WriteLine($"Cash withdrawl is successfull and your current balance is {user.Balance}");
                            }
                            break;
                        case 4:
                            check = false;
                            chk = true;
                            Console.WriteLine("----------------Enter -----------------\n 1 -> to open bank account \n 2 -> to Login to your Existing account \n 3 -> to Close Application");
                            options = Convert.ToInt32(Console.ReadLine());
                            break;
                        default:
                            Console.WriteLine("Enter the appropriate Values");
                            break;

                    }
                }

            }
            

        }

}
}

