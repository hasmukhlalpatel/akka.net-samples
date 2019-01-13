using System;

namespace Sample.Core
{
    public class CreditMessage : Transaction
    {
        public CreditMessage()
        {
            Type = TransactionTypeEnum.Credit;
        }
    }

    public class DebitMessage : Transaction
    {
        public DebitMessage()
        {
            Type = TransactionTypeEnum.Debit;
        }
    }

    public enum TransactionTypeEnum
    {
        None = 0,
        Credit = 1,
        Debit = 2
    }

    public class Transaction
    {
        public DateTime DateTime { get; set; }
        public string AccountNumber { get; set; }
        public string Sortcode { get; set; }

        public string Reference { get; set; }

        public decimal Amount { get; set; }

        public TransactionTypeEnum Type { get; protected set; }
    }
}
