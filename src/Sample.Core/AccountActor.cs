using System.Collections.Generic;
using Akka.Actor;
using Akka.Event;

namespace Sample.Core
{
    public class AccountActor : ReceiveActor
    {
        private readonly ILoggingAdapter log = Context.GetLogger();

        private readonly IList<Transaction> _transactions = new List<Transaction>();

        public decimal Balance { get; set; }

        public AccountActor()
        {
            Receive<string>(message =>
            {
                log.Info($"Received message: {message}");
                Sender.Tell(message);
            });

            Receive<CreditMessage>(message =>
            {
                _transactions.Add(message);
                Balance += message.Amount;
            });

            Receive<DebitMessage>(message =>
            {
                _transactions.Add(message);
                Balance -= message.Amount;
            });
        }
    }
}