// See https://aka.ms/new-console-template for more information
using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Transactions;
namespace ConsoleApp1
{
    class Account
    {

        private string ID;
        public double Balance { set; get; }
        List<string> transactions = new List<string>();

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
        public void setTransaction(string transaction)
        {
            this.transactions.Add(transaction);
        }
        public void displayTransactions()
        {
            int i = 1;
            Console.WriteLine("S.no --Date---------Time-------------Transaction Mode--------Amount------------Transaction status--------Balance------");
            foreach (string transaction in transactions)
            {
                Console.WriteLine(i++ +". "+transaction);
            }
        }
        
    }
    class User : Account
    {
        public string Name { set; get; }
        public string Password { set; get; }
        public string Id { set; get; }
        public string mobileNumber {  set; get; }
        public string Address { set; get; }
        public string Email { set; get; }
        public char Gender { set; get; }

        public int  AccountNumber = new Random().Next(600000000,900000000);

        public User(string id,string name,string password) : base(id)
        {
            this.Id = id;
            this.Name = name;
            this.Password = password;
            this.mobileNumber = "**********";
            this.Email = "Please Update";
            this.Address = "Please Update";
        }
        
    }
    internal class Program

    {
        public static void Main(string[] args)
        {
            Dictionary<string, string> accounts = new Dictionary<string, string>();
            List<User> users = new List<User>();
            User currentUser = new User("","","");
            string welcomeNote = "Hey Buddy,Welcome to the Bank of Intrest :)";
            for(int i = 0; i < welcomeNote.Length; i++)
            {
                Console.Write(welcomeNote[i]);
                Thread.Sleep(100);
            }
            
            Console.WriteLine();
            DateTime now = DateTime.Now;

            string name ;
            string userId="";
            string password;
            /*users.Add(new User("Vijay","Goat","Trailer"));
            users.Add(new User("Ajith", "VM", "Teaser"));
            User use;
            foreach(User user in users)
            {
                if(user.Id.Equals(name))
                {
                    Console.WriteLine("Found");
                    use = user;
         
                    
                }
                Console.WriteLine(user.Name +" "+user.Id+" "+user.Balance);
            }*/
            bool chk = true;
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
                            Console.WriteLine("============================X===========================");
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
                                    Console.WriteLine("Account Found");
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
                    Console.WriteLine($"Hey {currentUser.Name}, Welcome to the Bank of Interest!\n Enter\n 1 -> For Deposit \n 2 -> to view balance\n 3 -> For Withdrawl \n 4 -> to View Last Transactions \n 5 -> to update your Account details\n 6 -> to Close the Account\n 7 -> Exit");
                    Console.WriteLine("----------------Enter your option Here--------------");
                    int option = Convert.ToInt32(Console.ReadLine());
                    switch (option)
                    {
                        case 1:
                            Console.WriteLine("Enter the amount to deposit ");
                            double amount = Convert.ToDouble(Console.ReadLine());
                            currentUser.addBalance(amount);
                            Console.WriteLine($"Cash deposited! current Balance : ${currentUser.Balance}");
                            currentUser.setTransaction($" {now.ToString("dd-MM-yyyy")}  |  {now.ToString("h/mm/ss t")}M         Cash Deposit               +{amount}             Success               {currentUser.Balance}");
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
                                Console.WriteLine($"The entered sum is Exceeds your current balance, Your balance is ${currentUser.Balance}");
                                currentUser.setTransaction($" {now.ToString("dd-MM-yyyy")}  |  {now.ToString("h/mm/ss t")}M       Cash Withdrawl              -{wamount}              Failed              {currentUser.Balance}");
                                Console.WriteLine("=========================X================================");
                                break;
                            }
                            else
                            {
                                currentUser.withdrawAmount(wamount);
                                Console.WriteLine($"Cash withdrawl is successfull and your current balance is {currentUser.Balance}");
                                currentUser.setTransaction($" {now.ToString("dd-MM-yyyy")}  |  {now.ToString("h/mm/ss t")}M       Cash Withdrawl               -{wamount}             Success           {currentUser.Balance}");
                                Console.WriteLine("=========================X================================");
                            }

                            break;
                        case 4:
                            currentUser.displayTransactions(); 
                            break;
                        case 5:
                            Console.WriteLine($"Hey {currentUser.Name}, Please choose the below options to update your account \nTo Update your Name ,User Id and Password Please visit the nearest Branch");
                            Console.WriteLine();
                            Console.WriteLine("------------Enter------------ \n 1 -> To Update Mobile Number \n 2 -> to Update Address \n 3 -> For Gender \n 4 -> to Update Email Address \n 5 -> to Exit");
                            int opt = Convert.ToInt32(Console.ReadLine());
                            switch (opt)
                            {
                                case 1:
                                    currentUser.mobileNumber = Console.ReadLine();
                                    Console.WriteLine("Mobile Number updated!");
                                    break;
                                case 2:
                                    currentUser.Address = Console.ReadLine();
                                    Console.WriteLine("Address Updated!");
                                    break;
                                case 3:
                                    Console.WriteLine("Please Enter 'M' for Male 'F' for Female and 'T' for TransGender");
                                    currentUser.Gender = Convert.ToChar(Console.ReadLine());
                                    break;
                                case 4:
                                    currentUser.Email = Console.ReadLine();
                                    break;
                                case 5:
                                    break;
                                default:
                                    Console.WriteLine("Inappropriate option");
                                    break;
                            }
                            break; 
                        case 6:
                            Console.WriteLine($"Dear {currentUser.Name}, You have ${currentUser.Balance} in your account\n Still would you like to close the account?");
                            Console.WriteLine("Press 'Y' for Yes and 'N' for No");
                            string choice = Console.ReadLine();
                            choice = choice.ToUpper();
                            if(choice == "Y")
                            {
                                users.Remove(currentUser);
                                accounts.Remove(userId);
                                Console.WriteLine("Account closed permanently!");
                                // foreach (User us in users)
                                /* {
                                     Console.WriteLine(us.Name);
                                     Console.WriteLine(accounts[us.Id]);
                                 }*/
                                check = false;
                                chk = true;
                                break ;
                            }
                            else if (choice == "N")
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Enter Appropriate values only");
                            }
                            break;
                        case 7:
                            check = false;
                            chk = true;
                            break;
                        default:
                            Console.WriteLine("Enter the appropriate Values");
                            break;

                    }
                }

            }

            foreach (var user in users) {
                Console.WriteLine(user.Gender);
                Console.WriteLine(user.mobileNumber);
                Console.WriteLine(user.AccountNumber);
                Console.WriteLine(user.Email);
                Console.WriteLine(user.Address);
            }

        }
    }
}


