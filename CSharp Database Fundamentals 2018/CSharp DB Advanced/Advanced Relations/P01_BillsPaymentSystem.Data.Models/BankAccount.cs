using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }

        public decimal Balance { get; private set; }

        public string BankName { get; set; }

        public string SwiftCode { get; set; }

        public void Withdraw(decimal amount)
        {
            if ((this.Balance - amount) < 0)
            {
                try
                {
                    throw new InvalidOperationException("Insufficient funds!");
                }
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                this.Balance -= amount;
            }
            
        }

        public void Deposit(decimal amount)
        {
            this.Balance += amount;
        }
    }
}
