using System;
using System.Collections.Generic;
using System.Text;

namespace BankAccount
{
    // Simulate a bank account supporting opening/closing, withdrawals, and deposits of money.

    // It should be possible to close an account; operations against a closed account must fail.

    // Remember you are working with money so you should use an appropriate data type for it.

    public enum BankAccountStatus
    {
        Open,
        Closed
    }

    public class BankAccountVersion1
    {
        private BankAccountOwner owner;
        private decimal balance;

        public BankAccountStatus Status { get; set; }

        public BankAccountVersion1(BankAccountOwner owner)
        {
            this.owner = owner;
            this.Status = BankAccountStatus.Closed;
        }

        public void Open()
        {
            if (Status == BankAccountStatus.Closed)
            {
                Status = BankAccountStatus.Open;
                Console.WriteLine("The account has been opened.");
            }
        }

        public void Deposit(decimal amount)
        {
            if (Status == BankAccountStatus.Closed)
            {
                Console.WriteLine($"The account is closed, {nameof(Deposit)} operation invalid.");
                return;
            }

            balance += amount;
            Console.WriteLine($"You have deposited '{amount}', current balance = '{balance}'.");
        }

        public void Withdraw(decimal amount)
        {
            if (Status == BankAccountStatus.Closed)
            {
                Console.WriteLine($"The account is closed, {nameof(Withdraw)} operation invalid.");
                return;
            }

            if (amount > balance)
            {
                Console.WriteLine($"Insufficient funds, current balance = '{balance}'.");
                return;
            }

            balance -= amount;
            Console.WriteLine($"You have withdrawn '{amount}', current balance = '{balance}'.");
        }

        public void ShowBalance()
        {
            if (Status == BankAccountStatus.Closed)
            {
                Console.WriteLine($"The account is closed, {nameof(ShowBalance)} operation invalid.");
                return;
            }

            Console.WriteLine($"Current balance = '{balance}'.");
        }

        public void ShowOwner()
        {
            if (owner == null)
            {
                Console.WriteLine("The account doesn't have an owner.");
                return;
            }

            Console.WriteLine($"Account owner = '{owner.Id}'.");
        }
    }

    public abstract class BankAccountOwner
    {
        public string Id { get; set; }
    }

    public class Person : BankAccountOwner
    {
        private string firstName;
        private string lastName;

        public Person(string firstName, string lastName)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.Id = firstName + " " + lastName;
        }
    }

    public class Company : BankAccountOwner
    {
        private string name;

        public Company(string name)
        {
            this.name = name;
            this.Id = name;
        }
    }
}