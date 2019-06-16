using Newtonsoft.Json;
using System;

namespace BlockchainProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            var startTime = DateTime.Now;

            Blockchain digicoin = new Blockchain();
            digicoin.CreateTransaction(new Transaction("Elon", "Marc", 10));
            digicoin.ProcessPendingTransactions("Bram");

            digicoin.CreateTransaction(new Transaction("Marc", "Elon", 5));
            digicoin.CreateTransaction(new Transaction("Marc", "Elon", 5));
            digicoin.ProcessPendingTransactions("Bram");

            var endTime = DateTime.Now;

            Console.WriteLine($"Duration: {endTime - startTime}");

            Console.WriteLine("=========================");
            Console.WriteLine($"Elon' balance: {digicoin.GetBalance("Elon")}");
            Console.WriteLine($"Marc' balance: {digicoin.GetBalance("Marc")}");
            Console.WriteLine($"Bram' balance: {digicoin.GetBalance("Bram")}");

            Console.WriteLine("=========================");
            Console.WriteLine($"digicoin");
            Console.WriteLine(JsonConvert.SerializeObject(digicoin, Formatting.Indented));

            Console.ReadKey();

            /* Blockchain digicoin = new Blockchain();
            digicoin.Difficulty = 1;

            Participant Elon = new Participant("Elon Musk");
            Participant Marc = new Participant("Marc Benioff");
            Participant Tim = new Participant("Tim Cook");
            Participant Bram = new Participant("Bram Julsing");
            
            var startTime = DateTime.Now;

            digicoin.CreateTransaction(new Transaction(Elon, Marc, 10));
            digicoin.ProcessPendingTransactions(Bram);
            Console.WriteLine(JsonConvert.SerializeObject(digicoin, Formatting.Indented));

            digicoin.CreateTransaction(new Transaction(Marc, Tim, 5));
            digicoin.CreateTransaction(new Transaction(Marc, Tim, 5));
            digicoin.ProcessPendingTransactions(Bram);
            
            var endTime = DateTime.Now;

            Console.WriteLine($"Duration: {endTime - startTime}");
            Console.WriteLine($"Is Chain Valid: {digicoin.IsValid()}");

            Console.WriteLine("=========================");
            Console.WriteLine($"Elon' balance: {Elon.Balance}");
            Console.WriteLine($"Marc' balance: {Marc.Balance}");
            Console.WriteLine($"Tim' balance: {Tim.Balance}");
            Console.WriteLine($"Bram' balance: {Bram.Balance}");
            Console.WriteLine("=========================");

            Console.WriteLine($"digicoin");
            Console.WriteLine(JsonConvert.SerializeObject(digicoin, Formatting.Indented)); */
        }
    }
}