using Newtonsoft.Json;
using System;

namespace BlockchainProgram
{
    class Program
    {
        static void DisplayActions()
        {
            Console.WriteLine("Select an action:");
            Console.WriteLine("===============================");
            Console.WriteLine("1. Add a transaction");
            Console.WriteLine("2. Process pending transactions");
            Console.WriteLine("3. Display Blockchain");
            Console.WriteLine("4. Display balance");
            Console.WriteLine("5. Exit");
            Console.WriteLine("===============================\n");
        }
        static void Main(string[] args)
        {

            Blockchain digicoin = new Blockchain();
            digicoin.Difficulty = 1;

            Console.WriteLine("\nBlockchain initialized.\n");
            
            int selection = 0;
            while (selection != 5)
            {
                switch (selection)
                {
                    case 1:
                        Console.WriteLine("Please enter the sender's name:");
                        string senderName = Console.ReadLine();
                        Console.WriteLine("Please enter the receiver's name:");
                        string receiverName = Console.ReadLine();
                        Console.WriteLine("Please enter the amount:");
                        string amount = Console.ReadLine();
                        digicoin.SubmitTransaction(new Transaction(senderName, receiverName, int.Parse(amount)));
                        Console.WriteLine("Transaction added.\n");
                        break;
                    case 2:
                        Console.WriteLine("Please enter the miner's name:");
                        string minerName = Console.ReadLine();
                        digicoin.ProcessPendingTransactions(minerName);
                        Console.WriteLine("Transactions processed. New block added to the chain.");
                        Console.WriteLine($"{minerName} rewarded with {digicoin.Reward} digicoin.\n");
                        break;
                    case 3:
                        Console.WriteLine("Blockchain:");
                        Console.WriteLine($"{JsonConvert.SerializeObject(digicoin, Formatting.Indented)}\n");
                        break;
                    case 4:
                        Console.WriteLine("Please enter the participant's name:");
                        string participantName = Console.ReadLine();
                        Console.WriteLine($"{participantName}'s balance: {digicoin.GetBalance(participantName)}.\n");
                        break;
                }

                DisplayActions();
                string action = Console.ReadLine();
                selection = int.Parse(action);
            }

            // var startTime = DateTime.Now;

            // digicoin.SubmitTransaction(new Transaction("Elon", "Marc", 10));
            // digicoin.ProcessPendingTransactions("Bram");

            // digicoin.SubmitTransaction(new Transaction("Marc", "Elon", 5));
            // digicoin.SubmitTransaction(new Transaction("Marc", "Elon", 5));
            // digicoin.ProcessPendingTransactions("Bram");

            // var endTime = DateTime.Now;

            // Console.WriteLine($"Duration: {endTime - startTime}");

            // Console.WriteLine("=========================");
            // Console.WriteLine($"Elon' balance: {digicoin.GetBalance("Elon")}");
            // Console.WriteLine($"Marc' balance: {digicoin.GetBalance("Marc")}");
            // Console.WriteLine($"Bram' balance: {digicoin.GetBalance("Bram")}");

            // Console.WriteLine("=========================");
            // Console.WriteLine($"digicoin");
            // Console.WriteLine(JsonConvert.SerializeObject(digicoin, Formatting.Indented));

            // Console.ReadKey();


            // Participant Elon = new Participant("Elon Musk");
            // Participant Marc = new Participant("Marc Benioff");
            // Participant Tim = new Participant("Tim Cook");
            // Participant Bram = new Participant("Bram Julsing");
            
            // var startTime = DateTime.Now;

            // digicoin.SubmitTransaction(new Transaction(Elon, Marc, 10));
            // digicoin.ExecuteTransactions();
            // digicoin.OrderTransactions(Bram);
            // Console.WriteLine(JsonConvert.SerializeObject(digicoin, Formatting.Indented));

            // digicoin.SubmitTransaction(new Transaction(Marc, Tim, 5));
            // digicoin.SubmitTransaction(new Transaction(Marc, Tim, 5));
            // digicoin.ExecuteTransactions();
            // digicoin.OrderTransactions(Bram);
            
            // var endTime = DateTime.Now;

            // Console.WriteLine($"Duration: {endTime - startTime}");
            // Console.WriteLine($"Is Chain Valid: {digicoin.IsValid()}");

            // Console.WriteLine("=========================");
            // Console.WriteLine($"Elon' balance: {Elon.Balance}");
            // Console.WriteLine($"Marc' balance: {Marc.Balance}");
            // Console.WriteLine($"Tim' balance: {Tim.Balance}");
            // Console.WriteLine($"Bram' balance: {Bram.Balance}");
            // Console.WriteLine("=========================");

            // Console.WriteLine($"digicoin");
            // Console.WriteLine(JsonConvert.SerializeObject(digicoin, Formatting.Indented));
        }
    }
}