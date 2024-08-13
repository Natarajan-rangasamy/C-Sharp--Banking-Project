// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
namespace ConsoleApp1
{
    class Account
    {
        public int Id { set; get; }
        public string Name { set; get; }
    }
    class User
    {
        
        public double Balance { set; get; }
        
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
        User user = new User("kannan G");
        
        Console.WriteLine("Welcome to the Bank of Intrest :)");
        Console.WriteLine();
        //   Console.WriteLine("Enter -----------------\n 1 -> to open bank account \n 2 -> to Login to your account \n 3 -> to Deposit \n 4 -> to withdraw \n 5 -> to check Balance ");
        Console.WriteLine("Enter\n 1 -> For Deposit \n 2 -> to view balance\n 3 -> For Withdrawl \n 4 -> to Exit");
            bool check = true;
        while (check) {
            Console.WriteLine("----------------Enter your option Here--------------");
            int option = Convert.ToInt32(Console.ReadLine());
            switch (option) {
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
                    if (wamount > user.Balance) {
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
                    break;
                default:
                    Console.WriteLine("Enter the appropriate Values");
                    break;

            }
        }
    }

}
}

