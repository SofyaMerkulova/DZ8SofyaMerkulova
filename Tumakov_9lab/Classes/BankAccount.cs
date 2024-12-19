using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov_9lab.Classes
{
    internal class BankAccount:IDisposable
    {
        private string accountNumber;
        private decimal balance;
        private AccountType accountType;
        private Queue storage;
        private bool disposed = false;
        public enum AccountType
        {
            Текущий,
            Сберегательный
        }
        public BankAccount()
        {
            this.accountNumber = GenerateAccountNumber();
            this.balance = 0;
            this.accountType = AccountType.Текущий;
            this.storage = new Queue();

        }
        public BankAccount(AccountType accountType)
        {
            this.accountNumber = GenerateAccountNumber();
            this.balance = 0;
            this.accountType = accountType;
            this.storage = new Queue();
        }
        public BankAccount(decimal balance)
        {
            this.accountNumber = GenerateAccountNumber();
            this.balance = balance;
            this.accountType = AccountType.Текущий;
            this.storage = new Queue();
        }
        public BankAccount(decimal balance, AccountType accountType)
        {
            this.accountNumber = GenerateAccountNumber();
            this.balance = balance;
            this.accountType = accountType;
            this.storage = new Queue();
        }
        public BankAccount(string accountNumber, decimal balance, AccountType accountType)
        {
            this.accountNumber = accountNumber;
            this.balance = balance;
            this.accountType = accountType;
            this.storage = new Queue();
        }
        private string GenerateAccountNumber()
        {
            Random rand = new Random();
            string accountNumber = rand.Next(100000, 999999).ToString();
            return accountNumber;
        }
        public string GetAccountNumber()
        {
            return accountNumber;
        }

        public decimal GetBalance()
        {
            return balance;
        }

        public AccountType GetAccountType()
        {
            return accountType;
        }
        public void InfoAccount()
        {
            Console.WriteLine($"Ваш номер счёта: {accountNumber}");
            Console.WriteLine($"Баланс счёта до пополнения, снятия и перевода: {balance}");
            Console.WriteLine($"Тип вашего счёта: {accountType}");
        }
        public void AccountReplenishment(decimal i)
        {
            balance += i;
            BankTransaction transaction = new BankTransaction(i);
            storage.Enqueue(transaction);
            Console.WriteLine($"Баланс после пополнения: {balance}");
            Console.WriteLine($"Пополнение баланса: {transaction.TransactionsInfo()}");
        }
        public void WithdrawalFromTheAccount(decimal i)
        {
            if (i > balance)
            {
                Console.WriteLine("Недостаточно средств, выберите сумму меньше");
                return;
            }

            balance -= i;
            BankTransaction transaction = new BankTransaction(-i);
            storage.Enqueue(transaction);
            Console.WriteLine($"Баланс после снятия: {balance}");
            Console.WriteLine($"Снятие с баланса: {transaction.TransactionsInfo()}");
        }
        public void TransferFromOneAccountToAnother(BankAccount fromAccount, BankAccount toAccount, decimal sum)
        {
            if (sum > fromAccount.balance)
            {
                Console.WriteLine("Недостаточно средств на счете для перевода, выберите сумму меньше");
                return;
            }
            fromAccount.balance -= sum;
            toAccount.balance += sum;
            BankTransaction transactionFrom = new BankTransaction(-sum);
            BankTransaction transactionTo = new BankTransaction(sum);
            fromAccount.storage.Enqueue(transactionFrom);
            toAccount.storage.Enqueue(transactionTo);
            Console.WriteLine($"Баланс после перевода на сумму {sum} с текущего счёта (номер: {fromAccount.accountNumber}) составляет: {fromAccount.balance}");
            Console.WriteLine($"Баланс счёта под номером {toAccount.accountNumber}, на который выполнен перевод: {toAccount.balance}");
            Console.WriteLine($"Перевод от текущего счёта: {transactionFrom.TransactionsInfo()}");
            Console.WriteLine($"Перевод к сберегательному счёту: {transactionTo.TransactionsInfo()}");
        }
        public void GetTransactionStorage()
        {
            foreach (BankTransaction transaction in storage)
            {
                Console.WriteLine(transaction.TransactionsInfo());
            }
        }
        private void WriteTransactionsToFile()
        {
            string fileName = "bankTransaction.txt";
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                foreach (BankTransaction transaction in storage)
                {
                    writer.WriteLine(transaction.TransactionsInfo());
                }
            }
            Console.WriteLine($"Данные о проводках из очереди находятся в указанном файле: {Path.GetFullPath(fileName)}");
        }
        public void Dispose()
        { 
            if (!disposed)
            {
                WriteTransactionsToFile();
                storage.Clear();
                disposed = true;
                GC.SuppressFinalize(this);
            }


        }

    }
}
