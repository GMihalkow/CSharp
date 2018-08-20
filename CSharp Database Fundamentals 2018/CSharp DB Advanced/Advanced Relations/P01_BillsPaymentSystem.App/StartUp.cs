using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using P01_BillsPaymentSystem.Data;
using P01_BillsPaymentSystem.Data.Models;

namespace P01_BillsPaymentSystem.App
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //var context = new BillsPaymentSystemContext();
            //var bankAccount = context.BankAccounts.Where(b => b.BankAccountId == 3).First();
            //bankAccount.Deposit(2000);
            //context.SaveChanges();
            PayBills(1, 2000);
        }

        private static void Seed()
        {
            var context = new BillsPaymentSystemContext();

            var paymentMethods =
                context
                .PaymentMethods;

            var paymentMethod1 = new PaymentMethod();
            paymentMethod1.UserId = 1;
            paymentMethod1.Type = Data.Models.Type.BankAccount;
            paymentMethod1.BankAccountId = 3;

            paymentMethods.Add(paymentMethod1);

            context.SaveChanges();
        }

        private static void PayBills(int userId, decimal amount)
        {
            var context = new BillsPaymentSystemContext();

            var userBankAccounts =
                context
                .PaymentMethods
                .Where(p => p.UserId == userId && p.BankAccount != null)
                .Select(p => new
                {
                    p.UserId,
                    p.BankAccountId,
                    p.BankAccount
                })
                .OrderBy(p => p.BankAccountId)
                .ToArray();

            var userCreditCards =
                context
                .PaymentMethods
                .Where(p => p.UserId == userId && p.CreditCard != null)
                .Select(p => new
                {
                    p.UserId,
                    p.CreditCardId,
                    p.CreditCard
                })
                .OrderBy(p => p.CreditCardId)
                .ToArray();

            if (userBankAccounts.Count() == 0)
            {
            }
            else
            {

                foreach (var bankAccount in userBankAccounts)
                {
                    bankAccount.BankAccount.Withdraw(amount);
                }
            }

            if (userCreditCards.Count() == 0)
            {

            }
            else
            {
                foreach (var creditCard in userCreditCards)
                {
                    creditCard.CreditCard.Withdraw(amount);
                }
            }

            context.SaveChanges();
        }
    }
}
