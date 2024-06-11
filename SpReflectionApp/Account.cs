using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpReflectionApp
{
    public class Account
    {
        public string Name { get; set; }
        public decimal Balance { get; protected set; }

        public Account(string name, decimal balance)
        {
            Name = name;
            Balance = balance;
            Console.WriteLine($"Account {Name} create with balance: {Balance}");
        }

        public Account() : this("Simple", 0m) { }

        public void AddToBalance(decimal amount, double rate = 1.1)
        {
            if(amount > 0)
            {
                if (amount > Balance)
                    amount *= (decimal)rate;
                Balance += amount;
                Console.WriteLine($"Account {Name} add {amount} and balance: {Balance}");
            }
                
        }

        public decimal RemoveFromBalance(decimal amount)
        {
            if(amount > 0)
                Balance -= amount;
            Console.WriteLine($"Account {Name} remove {amount} and balance: {Balance}");
            return Balance;
        }
    }
}
