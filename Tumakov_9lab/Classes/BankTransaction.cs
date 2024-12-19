using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tumakov_9lab.Classes
{
    internal class BankTransaction
    {
        public readonly DateTime TimeandDate;
        public readonly decimal Summ;
        public BankTransaction(decimal summ)
        {
            TimeandDate = DateTime.Now;
            Summ = summ;
        }
        public string TransactionsInfo()
        {
            string transactionType;
            if (Summ >= 0)
            {
                transactionType = "Пополнение баланса";
            }
            else
            {
                transactionType = "Снятие с баланса";
            }
            return $"{TimeandDate}: {transactionType}, {Math.Abs(Summ)}";
        }
    }
}
