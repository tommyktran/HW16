using System;

namespace HW16
{
    class Program
    {
        static void Main(string[] args)
        {
            var Account1 = new DepositAccount(new Customer("Mary Smith", "individual"), 1231.33, 0.06);
            var Account2 = new DepositAccount(new Customer("Bob's Burgers", "company"), 42842.12, 0.06);

            var Account3 = new LoanAccount(new Customer("Bob Bobbington", "individual"), -13424.21, 2);
            var Account4 = new LoanAccount(new Customer("Company", "company"), -139494.21, 2);

            var Account5 = new MortgageAccount(new Customer("Lily May", "individual"), -166773.13, 3);
            var Account6 = new MortgageAccount(new Customer("Stuff Inc.", "company"), -1342523.45, 3);

            Account1.Deposit(3);
            Account1.Withdraw(134.2);
            Account1.CalculateInterest(5);

            Console.WriteLine();

            Account2.Deposit(30);
            Account2.Withdraw(1340.2);
            Account2.CalculateInterest(13);

            Console.WriteLine();

            Account3.Deposit(453);
            Account3.CalculateInterest(5);

            Console.WriteLine();

            Account4.Deposit(325);
            Account4.CalculateInterest(13);

            Console.WriteLine();

            Account5.Deposit(11);
            Account5.CalculateInterest(5);

            Console.WriteLine();

            Account6.Deposit(253);
            Account6.CalculateInterest(13);


        }
    }
//A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts.
//Each customer has a customer name and can be an individual or a company. 
//All accounts have a customer, balance and interest rate (monthly based). 
//Deposit accounts allow depositing and withdrawing of money. Loan and mortgage accounts allow only depositing. 
//All accounts can calculate their interest for a given period (in months). In the general case, it is calculated as follows: numberOfMonths * interestRate. 
//Loan accounts have no interest rate during the first 3 months if held by individuals and during the first 2 months if held by a company. 
//Deposit accounts have no interest rate if their balance is positive and less than 1000. 
//Mortgage accounts have ½ the interest rate during the first 12 months for companies and no interest rate during the first 6 months for individuals. 
//Your task is to write an object-oriented model of the bank system. 
//When a deposit or withdrawal is made, update the balance, and display the new balance on the console. 
//When an interest calculation is requested, display both the balance and the calculated interest.
//Your main program should test every property or method of every class at least a few times.
    public class Account
    {
        public Customer Customer;
        public double Balance;
        public double MonthlyInterest;

        public Account(Customer customer, double balance, double monthlyInterest)
        {
            Customer = customer;
            Balance = balance;
            MonthlyInterest = monthlyInterest;
        }
        public void Deposit(double amount)
        {
            Balance += amount;
            Console.WriteLine("New balance for " + Customer.Name + ": " + Balance);
        }
    }
    public class Customer
    {
        public string Name;
        public string Type;

        public Customer (string name, string type)
        {
            Name = name;
            Type = type;
        }
    }

    public class DepositAccount : Account
    {
        public DepositAccount(Customer customer, double balance, double monthlyInterest) : base(customer, balance, monthlyInterest)
        {
        }

        public void Withdraw(double amount)
        {
            Balance -= amount;
            Console.WriteLine("New balance for " + Customer.Name + ": " + Balance);
        }

        public double CalculateInterest(int numberOfMonths)
        {
            Console.WriteLine("Balance for account " + Customer.Name + ": " + Balance);
            if (Balance > 0 && Balance < 1000)
            {
                Console.WriteLine("Interest: " + 0);
                return 0;
            } else
            {
                Console.WriteLine("Interest: " + numberOfMonths * MonthlyInterest);
                return numberOfMonths * MonthlyInterest;
            }
        }
    }

    public class LoanAccount : Account
    {
        public LoanAccount(Customer customer, double balance, double monthlyInterest) : base(customer, balance, monthlyInterest)
        {
        }

        public double CalculateInterest(int numberOfMonths)
        {
            Console.WriteLine("Balance for account " + Customer.Name + ": " + Balance);
            if (Customer.Type == "individual" && numberOfMonths <= 3 ||
                Customer.Type == "company" && numberOfMonths <= 2)
            {
                Console.WriteLine("Interest: " + 0);
                return 0;
            }
            else
            {
                Console.WriteLine("Interest: " + numberOfMonths * MonthlyInterest);
                return numberOfMonths * MonthlyInterest;
            }
        }
    }
    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, double balance, double monthlyInterest) : base(customer, balance, monthlyInterest)
        {
        }

        public double CalculateInterest(int numberOfMonths)
        {
            Console.WriteLine("Balance for account " + Customer.Name + ": " + Balance);
            if (Customer.Type == "individual" && numberOfMonths <= 6)
            {
                Console.WriteLine("Interest: " + 0);
                return 0;
            } else if (Customer.Type == "company" && numberOfMonths <= 12)
            {
                Console.WriteLine("Interest: " + numberOfMonths * MonthlyInterest * .5);
                return numberOfMonths * MonthlyInterest * .5;
            }
            else
            {
                Console.WriteLine("Interest: " + numberOfMonths * MonthlyInterest);
                return numberOfMonths * MonthlyInterest;
            }
        }
    }
}
