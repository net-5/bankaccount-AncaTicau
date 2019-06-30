using System;
using System.Security.Cryptography.X509Certificates;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person("John", "Smith");
            Company company1 = new Company("Microsoft");
            BankAccountVersion1 bankAccount1 = new BankAccountVersion1(person1);
            BankAccountVersion1 bankAccount2 = new BankAccountVersion1(company1);

            bankAccount1.Deposit(10);
            bankAccount1.Withdraw(1000);
            bankAccount1.Open();

            bankAccount1.Deposit(20);
            bankAccount1.Deposit(50);
            bankAccount1.ShowBalance();

            bankAccount1.Withdraw(1000);
            bankAccount1.Withdraw(30);

            bankAccount1.ShowBalance();

            bankAccount1.ShowOwner();
            bankAccount2.ShowOwner();

            Console.ReadKey();
        }
    }
}