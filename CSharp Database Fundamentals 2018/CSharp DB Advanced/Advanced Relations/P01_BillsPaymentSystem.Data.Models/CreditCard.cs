using System;
using System.Collections.Generic;
using System.Text;

namespace P01_BillsPaymentSystem.Data.Models
{
    public class CreditCard
    {
        public int CreditCardId { get; set; }

        public decimal Limit { get; private set; }

        public decimal MoneyOwed { get; private set; }

        public decimal LimitLeft
        {
            get
            {
                return this.LimitLeft;
            }
            private set
            {
                if ((this.Limit - this.MoneyOwed) < 0)
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
                this.LimitLeft = this.Limit - this.MoneyOwed;
            }

        }

        public DateTime ExpirationDate { get; set; }

        public void Withdraw(decimal amount)
        {
            this.MoneyOwed += amount;
        }

        public void Deposit(decimal amount)
        {
            if ((this.MoneyOwed - amount) < 0)
            {
                this.MoneyOwed = 0;
            }
            else
            {
                this.MoneyOwed -= amount;
            }
        }
    }
}
