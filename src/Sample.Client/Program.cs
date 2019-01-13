using System;
using Akka.Actor;
using Sample.Core;

namespace Sample.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            var system = ActorSystem.Create("MySystem");
            var account01 = system.ActorOf<AccountActor>("01");

            account01.Tell(new CreditMessage
            {
                Amount = 100,
                DateTime = DateTime.Now,
                AccountNumber = "01",
                Sortcode = "01",
                Reference = "01"
            });


            account01.Tell(new DebitMessage
            {
                Amount = 100,
                DateTime = DateTime.Now,
                AccountNumber = "01",
                Sortcode = "01",
                Reference = "01"
            });

            //account01.Ask<>()

            var firstRef = system.ActorOf<PrintMyActorRefActor>("first-actor");

            //var firstRef = Sys.ActorOf(Props.Create<PrintMyActorRefActor>(), "first-actor");
            Console.WriteLine($"First: {firstRef}");
            firstRef.Tell("test");

            firstRef.Tell("printit", ActorRefs.NoSender);

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}
